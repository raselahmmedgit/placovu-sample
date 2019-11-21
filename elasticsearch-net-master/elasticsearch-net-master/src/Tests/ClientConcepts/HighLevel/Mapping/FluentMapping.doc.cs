﻿using System;
using System.Collections.Generic;
using System.Reflection;
using Nest;
using Newtonsoft.Json;
using Tests.Framework;
using static Tests.Framework.RoundTripper;

namespace Tests.ClientConcepts.HighLevel.Mapping
{
	/**
	* [[fluent-mapping]]
	* === Fluent mapping
	*
	* Fluent mapping POCO properties to fields within an Elasticsearch type mapping
    * offers the most control over the process. With fluent mapping, each property of
    * the POCO is explicitly mapped to an Elasticsearch type field mapping.
	*/

    public class FluentMapping
    {
        /**
		* To demonstrate, we'll define two POCOs
        *
        * - `Company`, which has a name and a collection of Employees
        * - `Employee` which has various properties of different types and has itself a collection of `Employee` types.
		*/
        public class Company
        {
            public string Name { get; set; }
            public List<Employee> Employees { get; set; }
        }

        public class Employee
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Salary { get; set; }
            public DateTime Birthday { get; set; }
            public bool IsManager { get; set; }
            public List<Employee> Employees { get; set; }
            public TimeSpan Hours { get; set; }
        }

        [U]
        public void MappingManually()
        {
            /**==== Manual mapping
			 * To create a mapping for our Company type, we can use the fluent API
			 * and map each property explicitly
			 */
            var descriptor = new CreateIndexDescriptor("myindex")
                .Mappings(ms => ms
                    .Map<Company>(m => m
                        .Properties(ps => ps
                            .Text(s => s
                                .Name(c => c.Name)
                            )
                            .Object<Employee>(o => o
                                .Name(c => c.Employees)
                                .Properties(eps => eps
                                    .Text(s => s
                                        .Name(e => e.FirstName)
                                    )
                                    .Text(s => s
                                        .Name(e => e.LastName)
                                    )
                                    .Number(n => n
                                        .Name(e => e.Salary)
                                        .Type(NumberType.Integer)
                                    )
                                )
                            )
                        )
                    )
                );

            /**
             * Here, the Name property of the `Company` type has been mapped as a {ref_current}/text.html[text datatype] and
             * the `Employees` property mapped as an {ref_current}/object.html[object datatype]. Within this object mapping,
             * only the `FirstName`, `LastName` and `Salary` properties of the `Employee` type have been mapped.
             *
             * The json mapping for this example looks like
			 */
            //json
            var expected = new
            {
                mappings = new
                {
                    company = new
                    {
                        properties = new
                        {
                            name = new
                            {
                                type = "text"
                            },
                            employees = new
                            {
                                type = "object",
                                properties = new
                                {
                                    firstName = new
                                    {
                                        type = "text"
                                    },
                                    lastName = new
                                    {
                                        type = "text"
                                    },
                                    salary = new
                                    {
                                        type = "integer"
                                    }
                                }
                            }
                        }
                    }
                }
            };

            // hide
            Expect(expected).WhenSerializing((ICreateIndexRequest) descriptor);
        }

        /** Manual mapping in this way is powerful but can become verbose and unwieldy for
        * large POCOs. The majority of the time you simply want to map *all* the properties of a POCO in a single go
        * without having to specify the mapping for each property,
        * particularly when there is <<auto-map,inferred mapping>> from CLR types to Elasticsearch types.
        *
        * This is where the fluent mapping in conjunction with auto mapping comes in.
        *
        * [[auto-map-with-overrides]]
        * ==== Auto mapping with fluent overrides
        *
        * In most cases, you'll want to map more than just the vanilla datatypes and also provide
        * various options for your properties, such as the analyzer to use, whether to enable `doc_values`, etc.
        *
        * In this case, it's possible to use `.AutoMap()` in conjunction with explicitly mapped properties.
        */
        [U]
        public void OverridingAutoMappedProperties()
        {
            /**
			* Here we are using `.AutoMap()` to automatically infer the mapping of our `Company` type from the
            * CLR property types, but then we're overriding the `Employees` property to make it a
            * {ref_current}/nested.html[nested datatype], since by default `.AutoMap()` will infer the
            * `List<Employee>` property as an `object` datatype
			*/
            var descriptor = new CreateIndexDescriptor("myindex")
                .Mappings(ms => ms
                    .Map<Company>(m => m
                        .AutoMap()
                        .Properties(ps => ps
                            .Nested<Employee>(n => n
                                .Name(c => c.Employees)
                            )
                        )
                    )
                );

            //json
            var expected = new
            {
                mappings = new
                {
                    company = new
                    {
                        properties = new
                        {
                            name = new
                            {
                                type = "text",
                                fields = new
                                {
                                    keyword = new
                                    {
                                        type = "keyword",
                                        ignore_above = 256
                                    }
                                }
                            },
                            employees = new
                            {
                                type = "nested",
                            }
                        }
                    }
                }
            };

            //hide
            Expect(expected).WhenSerializing((ICreateIndexRequest)descriptor);

            /**
			 * `.AutoMap()` __**is idempotent**__ therefore calling it _before_ or _after_
             * manually mapped properties will still yield the same result. The next example
             * generates the same mapping as the previous
			 */
            descriptor = new CreateIndexDescriptor("myindex")
                .Mappings(ms => ms
                    .Map<Company>(m => m
                        .Properties(ps => ps
                            .Nested<Employee>(n => n
                                .Name(c => c.Employees)
                            )
                        )
                        .AutoMap()
                    )
                );

            //hide
            Expect(expected).WhenSerializing((ICreateIndexRequest)descriptor);
        }

        /**
         * Just as we were able to override the inferred properties from auto mapping in the previous example,
         * fluent mapping also takes precedence over <<attribute-mapping, Attribute Mapping>>.
         * In this way, fluent, attribute and auto mapping can be combined. We'll demonstrate with an example.
         *
         * Consider the following two POCOS
         */
        [ElasticsearchType(Name = "company")]
        public class CompanyWithAttributes
        {
            [Keyword(NullValue = "null", Similarity = "BM25")]
            public string Name { get; set; }

            [Text(Name = "office_hours")]
            public TimeSpan? HeadOfficeHours { get; set; }

            [Object(Store = false)]
            public List<Employee> Employees { get; set; }
        }

        [ElasticsearchType(Name = "employee")]
        public class EmployeeWithAttributes
        {
            [Text(Name = "first_name")]
            public string FirstName { get; set; }

            [Text(Name = "last_name")]
            public string LastName { get; set; }

            [Number(DocValues = false, IgnoreMalformed = true, Coerce = true)]
            public int Salary { get; set; }

            [Date(Format = "MMddyyyy")]
            public DateTime Birthday { get; set; }

            [Boolean(NullValue = false, Store = true)]
            public bool IsManager { get; set; }

            [Nested]
            [JsonProperty("empl")]
            public List<Employee> Employees { get; set; }
        }

        /**
         * Now when mapping, `AutoMap()` is called to infer the mapping from the POCO property types and
         * attributes, and inferred mappings are overridden with fluent mapping
         */
        [U]
        public void OverridingAutoMappedAttributes()
        {
            var descriptor = new CreateIndexDescriptor("myindex")
                .Mappings(ms => ms
                    .Map<CompanyWithAttributes>(m => m
                        .AutoMap() // <1> Automap company
                        .Properties(ps => ps // <2> Override company inferred mappings
                            .Nested<Employee>(n => n
                                .Name(c => c.Employees)
                            )
                        )
                    )
                    .Map<EmployeeWithAttributes>(m => m
                        .AutoMap() // <3> Auto map employee
                        .Properties(ps => ps // <4> Override employee inferred mappings
                            .Text(s => s
                                .Name(e => e.FirstName)
                                .Fields(fs => fs
                                    .Keyword(ss => ss
                                        .Name("firstNameRaw")
                                    )
                                    .TokenCount(t => t
                                        .Name("length")
                                        .Analyzer("standard")
                                    )
                                )
                            )
                            .Number(n => n
                                .Name(e => e.Salary)
                                .Type(NumberType.Double)
                                .IgnoreMalformed(false)
                            )
                            .Date(d => d
                                .Name(e => e.Birthday)
                                .Format("MM-dd-yy")
                            )
                        )
                    )
                );

            //json
            var expected = new
            {
                mappings = new
                {
                    company = new
                    {
                        properties = new
                        {
                            employees = new
                            {
                                type = "nested"
                            },
                            name = new
                            {
                                null_value = "null",
                                similarity = "BM25",
                                type = "keyword"
                            },
                            office_hours = new
                            {
                                type = "text"
                            }
                        }
                    },
                    employee = new
                    {
                        properties = new
                        {
                            birthday = new
                            {
                                format = "MM-dd-yy",
                                type = "date"
                            },
                            empl = new
                            {
                                properties = new
                                {
                                    birthday = new
                                    {
                                        type = "date"
                                    },
                                    employees = new
                                    {
                                        properties = new { },
                                        type = "object"
                                    },
                                    firstName = new
                                    {
                                        fields = new
                                        {
                                            keyword = new
                                            {
                                                type = "keyword",
                                                ignore_above = 256
                                            }
                                        },
                                        type = "text"
                                    },
                                    hours = new
                                    {
                                        type = "long"
                                    },
                                    isManager = new
                                    {
                                        type = "boolean"
                                    },
                                    lastName = new
                                    {
                                        fields = new
                                        {
                                            keyword = new
                                            {
                                                type = "keyword",
                                                ignore_above = 256
                                            }
                                        },
                                        type = "text"
                                    },
                                    salary = new
                                    {
                                        type = "integer"
                                    }
                                },
                                type = "nested"
                            },
                            first_name = new
                            {
                                fields = new
                                {
                                    firstNameRaw = new
                                    {
                                        type = "keyword"
                                    },
                                    length = new
                                    {
                                        analyzer = "standard",
                                        type = "token_count"
                                    }
                                },
                                type = "text"
                            },
                            isManager = new
                            {
                                null_value = false,
                                store = true,
                                type = "boolean"
                            },
                            last_name = new
                            {
                                type = "text"
                            },
                            salary = new
                            {
                                ignore_malformed = false,
                                type = "double"
                            }
                        }
                    }
                }
            };

            // hide
            Expect(expected).WhenSerializing((ICreateIndexRequest)descriptor);
        }


        /**
        * ==== Auto mapping overrides down the object graph
        *
        * You may have noticed in the <<auto-map-with-overrides, Automap with fluent overrides example>>
        * that the properties of the `Employees` property on `Company` were not mapped. This is because the automapping
        * was applied only at the root level of the `Company` mapping.
        *
        * By calling `.AutoMap()` inside of the `.Nested<Employee>` mapping, it is possible to auto map the
        * `Employee` nested properties and again, override any inferred mapping from the automapping process,
        * through manual mapping
        */
        [U]
        public void OverridingDescendingAutoMappedProperties()
        {
            var descriptor = new CreateIndexDescriptor("myindex")
                .Mappings(m => m
                    .Map<Company>(mm => mm
                        .AutoMap() // <1> Automap `Company`
                        .Properties(p => p // <2> Override specific `Company` mappings
                            .Nested<Employee>(n => n
                                .Name(c => c.Employees)
                                .AutoMap() // <3> Automap `Employees` property
                                .Properties(pp => pp // <4> Override specific `Employee` properties
                                    .Text(t => t
                                        .Name(e => e.FirstName)
                                    )
                                    .Text(t => t
                                        .Name(e => e.LastName)
                                    )
                                    .Nested<Employee>(nn => nn
                                        .Name(e => e.Employees)
                                    )
                                )
                            )
                        )
                    )
                );

            //json
            var expected = new
            {
                mappings = new
                {
                    company = new
                    {
                        properties = new
                        {
                            name = new
                            {
                                type = "text",
                                fields = new
                                {
                                    keyword = new
                                    {
                                        type = "keyword",
                                        ignore_above = 256
                                    }
                                }
                            },
                            employees = new
                            {
                                type = "nested",
                                properties = new
                                {
                                    firstName = new
                                    {
                                        type = "text"
                                    },
                                    lastName = new
                                    {
                                        type = "text"
                                    },
                                    salary = new
                                    {
                                        type = "integer"
                                    },
                                    birthday = new
                                    {
                                        type = "date"
                                    },
                                    isManager = new
                                    {
                                        type = "boolean"
                                    },
                                    employees = new
                                    {
                                        type = "nested"
                                    },
                                    hours = new
                                    {
                                        type = "long"
                                    }
                                }
                            }
                        }
                    }
                }
            };

            //hide
            Expect(expected).WhenSerializing((ICreateIndexRequest)descriptor);
        }
    }
}

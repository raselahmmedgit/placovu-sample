﻿using System;
using System.Linq;
using System.Reflection;
using FluentAssertions;
using Nest;
using Newtonsoft.Json;
using Tests.Framework;

namespace Tests.CodeStandards
{
	public class QueriesStandards
	{
		protected static PropertyInfo[] QueryProperties = typeof(IQueryContainer).GetProperties();
		protected static PropertyInfo[] QueryPlaceHolderProperties = typeof(IQueryContainer).GetProperties()
			.Where(a=>!a.GetCustomAttributes<JsonIgnoreAttribute>().Any()).ToArray();

		/*
		* All properties must be either marked with JsonIgnore or JsonProperty
		*/
		[U] public void InterfacePropertiesMustBeMarkedExplicitly()
		{
			var properties = from p in QueryProperties
							 let a = p.GetCustomAttributes<JsonIgnoreAttribute>().Concat<Attribute>(p.GetCustomAttributes<JsonPropertyAttribute>())
							 where a.Count() != 1
							 select p;
			properties.Should().BeEmpty();
		}

		[U] public void StaticQueryExposesAll()
		{
			var staticProperties = from p in typeof(Query<>).GetMethods()
								   let name = p.Name.StartsWith("GeoShape") ? "GeoShape" : p.Name
								   select name;

			var placeHolders = QueryPlaceHolderProperties.Select(p => p.Name.StartsWith("GeoShape") ? "GeoShape" : p.Name);
			staticProperties.Distinct().Should().Contain(placeHolders.Distinct());
		}

		[U] public void FluentDescriptorExposesAll()
		{
			var fluentMethods = from p in typeof(QueryContainerDescriptor<>).GetMethods()
								   let name = p.Name.StartsWith("GeoShape") ? "GeoShape" : p.Name
								   select name;

			var placeHolders = QueryPlaceHolderProperties.Select(p => p.Name.StartsWith("GeoShape") ? "GeoShape" : p.Name);
			fluentMethods.Distinct().Should().Contain(placeHolders.Distinct());
		}

		[U] public void VisitorVisitsAll()
		{
			var skipQueryImplementations = new[] { typeof(IFieldNameQuery), typeof(IFuzzyQuery<,>), typeof(IConditionlessQuery) };
			var queries = typeof(IQuery).Assembly().ExportedTypes
				.Where(t => t.IsInterface() && typeof(IQuery).IsAssignableFrom(t))
				.Where(t => !skipQueryImplementations.Contains(t))
				.ToList();
			queries.Should().NotBeEmpty();

			var visitMethods = typeof(IQueryVisitor).GetMethods().Where(m => m.Name == "Visit");
			visitMethods.Should().NotBeEmpty();
			var missingTypes = from q in queries
							   let visitMethod = visitMethods.FirstOrDefault(m => m.GetParameters().First().ParameterType == q)
							   where visitMethod == null
							   select q;
			missingTypes.Should().BeEmpty();
		}
	}
}

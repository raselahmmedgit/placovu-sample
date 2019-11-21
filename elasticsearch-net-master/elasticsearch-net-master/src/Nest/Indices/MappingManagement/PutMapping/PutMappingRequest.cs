﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nest
{
	[JsonConverter(typeof(ReadAsTypeJsonConverter<PutMappingRequest>))]
	public partial interface IPutMappingRequest : ITypeMapping
	{
	}

	public interface IPutMappingRequest<T> : IPutMappingRequest where T : class { }

	public partial class PutMappingRequest
	{
		// Needed for ReadAsType
		internal PutMappingRequest() { }

		/// <inheritdoc/>
		public IAllField AllField { get; set; }
		/// <inheritdoc/>
		public bool? DateDetection { get; set; }
		/// <inheritdoc/>
		public bool? IncludeInAll { get; set; }
		/// <inheritdoc/>
		public IEnumerable<string> DynamicDateFormats { get; set; }
		/// <inheritdoc/>
		public IDynamicTemplateContainer DynamicTemplates { get; set; }
		/// <inheritdoc/>
		public Union<bool, DynamicMapping> Dynamic { get; set; }
		/// <inheritdoc/>
		public string Analyzer { get; set; }
		/// <inheritdoc/>
		public string SearchAnalyzer { get; set; }
		/// <inheritdoc/>
		public IFieldNamesField FieldNamesField { get; set; }
		/// <inheritdoc/>
		public IIndexField IndexField { get; set; }
		/// <inheritdoc/>
		public IDictionary<string, object> Meta { get; set; }
		/// <inheritdoc/>
		public bool? NumericDetection { get; set; }
		/// <inheritdoc/>
		public IParentField ParentField { get; set; }
		/// <inheritdoc/>
		public IProperties Properties { get; set; }
		/// <inheritdoc/>
		public IRoutingField RoutingField { get; set; }
		/// <inheritdoc/>
		public ISizeField SizeField { get; set; }
		/// <inheritdoc/>
		public ISourceField SourceField { get; set; }
	}

	public partial class PutMappingRequest<T> where T : class
	{
		public PutMappingRequest() : this(typeof(T), typeof(T)) { }

		/// <inheritdoc/>
		public IAllField AllField { get; set; }
		/// <inheritdoc/>
		public bool? DateDetection { get; set; }
		/// <inheritdoc/>
		public bool? IncludeInAll { get; set; }
		/// <inheritdoc/>
		public IEnumerable<string> DynamicDateFormats { get; set; }
		/// <inheritdoc/>
		public IDynamicTemplateContainer DynamicTemplates { get; set; }
		/// <inheritdoc/>
		public Union<bool, DynamicMapping> Dynamic { get; set; }
		/// <inheritdoc/>
		public string Analyzer { get; set; }
		/// <inheritdoc/>
		public string SearchAnalyzer { get; set; }
		/// <inheritdoc/>
		public IFieldNamesField FieldNamesField { get; set; }
		/// <inheritdoc/>
		public IIndexField IndexField { get; set; }
		/// <inheritdoc/>
		public IDictionary<string, object> Meta { get; set; }
		/// <inheritdoc/>
		public bool? NumericDetection { get; set; }
		/// <inheritdoc/>
		public IParentField ParentField { get; set; }
		/// <inheritdoc/>
		public IProperties Properties { get; set; }
		/// <inheritdoc/>
		public IRoutingField RoutingField { get; set; }
		/// <inheritdoc/>
		public ISizeField SizeField { get; set; }
		/// <inheritdoc/>
		public ISourceField SourceField { get; set; }
	}

	[DescriptorFor("IndicesPutMapping")]
	public partial class PutMappingDescriptor<T> where T : class
	{
		public PutMappingDescriptor() : this(typeof(T), typeof(T)) { }
		public PutMappingDescriptor(IndexName index, TypeName type) : base(r=>r.Required("index", index).Required("type", type)) { }

		protected PutMappingDescriptor<T> Assign(Action<ITypeMapping> assigner) => Fluent.Assign(this, assigner);

		IAllField ITypeMapping.AllField { get; set; }
		bool? ITypeMapping.DateDetection { get; set; }
		bool? ITypeMapping.IncludeInAll { get; set; }
		IEnumerable<string> ITypeMapping.DynamicDateFormats { get; set; }
		string ITypeMapping.Analyzer { get; set; }
		string ITypeMapping.SearchAnalyzer { get; set; }
		IDynamicTemplateContainer ITypeMapping.DynamicTemplates { get; set; }
		Union<bool, DynamicMapping> ITypeMapping.Dynamic { get; set; }
		IFieldNamesField ITypeMapping.FieldNamesField { get; set; }
		IIndexField ITypeMapping.IndexField { get; set; }
		IDictionary<string, object> ITypeMapping.Meta { get; set; }
		bool? ITypeMapping.NumericDetection { get; set; }
		IParentField ITypeMapping.ParentField { get; set; }
		IProperties ITypeMapping.Properties { get; set; }
		IRoutingField ITypeMapping.RoutingField { get; set; }
		ISizeField ITypeMapping.SizeField { get; set; }
		ISourceField ITypeMapping.SourceField { get; set; }

		/// <summary>
		/// Convenience method to map as much as it can based on ElasticType attributes set on the type.
		/// <pre>This method also automatically sets up mappings for known values types (int, long, double, datetime, etcetera)</pre>
		/// <pre>Class types default to object and Enums to int</pre>
		/// <pre>Later calls can override whatever is set is by this call.</pre>
		/// </summary>
		public PutMappingDescriptor<T> AutoMap(IPropertyVisitor visitor = null, int maxRecursion = 0) =>
			Assign(a => a.Properties = a.Properties.AutoMap<T>(visitor, maxRecursion));

		/// <inheritdoc/>
		public PutMappingDescriptor<T> AutoMap(int maxRecursion) => AutoMap(null, maxRecursion);

		/// <inheritdoc/>
		public PutMappingDescriptor<T> Dynamic(Union<bool, DynamicMapping> dynamic) => Assign(a => a.Dynamic = dynamic);

		/// <inheritdoc/>
		public PutMappingDescriptor<T> Dynamic(bool dynamic = true) => Assign(a => a.Dynamic = dynamic);

		/// <inheritdoc/>
		public PutMappingDescriptor<T> IncludeInAll(bool include = true) => Assign(a => a.IncludeInAll = include);

		/// <inheritdoc/>
		public PutMappingDescriptor<T> Parent(TypeName parentType) => Assign(a => a.ParentField = new ParentField { Type = parentType });

		/// <inheritdoc/>
		public PutMappingDescriptor<T> Parent<TParent>() where TParent : class => Assign(a => a.ParentField = new ParentField { Type = typeof(TParent) });

#pragma warning disable 618
		/// <inheritdoc/>
		public PutMappingDescriptor<T> Analyzer(string analyzer) => Assign(a => a.Analyzer = analyzer);

		/// <inheritdoc/>
		public PutMappingDescriptor<T> SearchAnalyzer(string searchAnalyzer) => Assign(a => a.SearchAnalyzer = searchAnalyzer);
#pragma warning restore 618

		/// <inheritdoc/>
		public PutMappingDescriptor<T> AllField(Func<AllFieldDescriptor, IAllField> allFieldSelector) => Assign(a => a.AllField = allFieldSelector?.Invoke(new AllFieldDescriptor()));

		/// <inheritdoc/>
		public PutMappingDescriptor<T> IndexField(Func<IndexFieldDescriptor, IIndexField> indexFieldSelector) => Assign(a => a.IndexField = indexFieldSelector?.Invoke(new IndexFieldDescriptor()));

		/// <inheritdoc/>
		public PutMappingDescriptor<T> SizeField(Func<SizeFieldDescriptor, ISizeField> sizeFieldSelector) => Assign(a => a.SizeField = sizeFieldSelector?.Invoke(new SizeFieldDescriptor()));

		/// <inheritdoc/>
		public PutMappingDescriptor<T> DisableSizeField(bool disabled = true) => Assign(a => a.SizeField = new SizeField { Enabled = !disabled });

		/// <inheritdoc/>
		public PutMappingDescriptor<T> DisableIndexField(bool disabled = true) => Assign(a => a.IndexField = new IndexField { Enabled = !disabled });

		/// <inheritdoc/>
		public PutMappingDescriptor<T> DynamicDateFormats(IEnumerable<string> dateFormats) => Assign(a => a.DynamicDateFormats = dateFormats);

		/// <inheritdoc/>
		public PutMappingDescriptor<T> DateDetection(bool detect = true) => Assign(a => a.DateDetection = detect);

		/// <inheritdoc/>
		public PutMappingDescriptor<T> NumericDetection(bool detect = true) => Assign(a => a.NumericDetection = detect);

		/// <inheritdoc/>
		public PutMappingDescriptor<T> SourceField(Func<SourceFieldDescriptor, ISourceField> sourceFieldSelector) => Assign(a => a.SourceField = sourceFieldSelector?.Invoke(new SourceFieldDescriptor()));

		/// <inheritdoc/>
		public PutMappingDescriptor<T> RoutingField(Func<RoutingFieldDescriptor<T>, IRoutingField> routingFieldSelector) => Assign(a => a.RoutingField = routingFieldSelector?.Invoke(new RoutingFieldDescriptor<T>()));

		/// <inheritdoc/>
		public PutMappingDescriptor<T> FieldNamesField(Func<FieldNamesFieldDescriptor<T>, IFieldNamesField> fieldNamesFieldSelector) => Assign(a => a.FieldNamesField = fieldNamesFieldSelector.Invoke(new FieldNamesFieldDescriptor<T>()));

		/// <inheritdoc/>
		public PutMappingDescriptor<T> Meta(Func<FluentDictionary<string, object>, FluentDictionary<string, object>> metaSelector) =>
			Assign(a => a.Meta = metaSelector(new FluentDictionary<string, object>()));

		/// <inheritdoc/>
		public PutMappingDescriptor<T> Meta(Dictionary<string, object> metaDictionary) => Assign(a => a.Meta = metaDictionary);

		/// <inheritdoc/>
		public PutMappingDescriptor<T> Properties(Func<PropertiesDescriptor<T>, IPromise<IProperties>> propertiesSelector) =>
			Assign(a => a.Properties = propertiesSelector?.Invoke(new PropertiesDescriptor<T>(a.Properties))?.Value);

		/// <inheritdoc/>
		public PutMappingDescriptor<T> DynamicTemplates(Func<DynamicTemplateContainerDescriptor<T>, IPromise<IDynamicTemplateContainer>> dynamicTemplatesSelector) =>
			Assign(a => a.DynamicTemplates = dynamicTemplatesSelector?.Invoke(new DynamicTemplateContainerDescriptor<T>())?.Value);
	}
}

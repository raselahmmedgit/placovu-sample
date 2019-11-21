﻿using System;
using Elasticsearch.Net;

namespace Nest
{
	public abstract class CorePropertyDescriptorBase<TDescriptor, TInterface, T>
		: PropertyDescriptorBase<TDescriptor, TInterface, T>, ICoreProperty
		where TDescriptor : CorePropertyDescriptorBase<TDescriptor, TInterface, T>, TInterface
		where TInterface : class, ICoreProperty
		where T : class
	{
		bool? ICoreProperty.Store { get; set; }
		Union<SimilarityOption, string> ICoreProperty.Similarity { get; set; }
		Fields ICoreProperty.CopyTo { get; set; }
		IProperties ICoreProperty.Fields { get; set; }

		[Obsolete("Please use overload taking FieldType")]
		protected CorePropertyDescriptorBase(string type) : base(type) {}

#pragma warning disable 618
		protected CorePropertyDescriptorBase(FieldType type) : this(type.GetStringValue()) {}
#pragma warning restore 618

		public TDescriptor Store(bool store = true) => Assign(a => a.Store = store);

		public TDescriptor Fields(Func<PropertiesDescriptor<T>, IPromise<IProperties>> selector) => Assign(a => a.Fields = selector?.Invoke(new PropertiesDescriptor<T>())?.Value);

		public TDescriptor Similarity(SimilarityOption similarity) => Assign(a => a.Similarity = similarity);

		public TDescriptor Similarity(string similarity) => Assign(a => a.Similarity = similarity);

		public TDescriptor CopyTo(Func<FieldsDescriptor<T>, IPromise<Fields>> fields) => Assign(a => a.CopyTo = fields?.Invoke(new FieldsDescriptor<T>())?.Value);
	}
}

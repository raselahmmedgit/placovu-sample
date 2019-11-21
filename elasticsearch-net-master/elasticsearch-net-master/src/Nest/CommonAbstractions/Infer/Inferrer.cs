﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Elasticsearch.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Nest
{
	public class Inferrer
	{
		private readonly IConnectionSettingsValues _connectionSettings;
		private IdResolver IdResolver { get; }
		private IndexNameResolver IndexNameResolver { get; }
		private TypeNameResolver TypeNameResolver { get; }
		private FieldResolver FieldResolver { get; }

		internal ConcurrentDictionary<Type, JsonContract> Contracts { get; }
		internal ConcurrentDictionary<Type, Action<MultiGetHitJsonConverter.MultiHitTuple, JsonSerializer, ICollection<IMultiGetHit<object>>>> CreateMultiHitDelegates { get; }
		internal ConcurrentDictionary<Type, Action<MultiSearchResponseJsonConverter.SearchHitTuple, JsonSerializer, IDictionary<string, object>>> CreateSearchResponseDelegates { get; }

		public Inferrer(IConnectionSettingsValues connectionSettings)
		{
			connectionSettings.ThrowIfNull(nameof(connectionSettings));
			this._connectionSettings = connectionSettings;
			this.IdResolver = new IdResolver(connectionSettings);
			this.IndexNameResolver = new IndexNameResolver(connectionSettings);
			this.TypeNameResolver = new TypeNameResolver(connectionSettings);
			this.FieldResolver = new FieldResolver(connectionSettings);

			this.Contracts = new ConcurrentDictionary<Type, JsonContract>();
			this.CreateMultiHitDelegates = new ConcurrentDictionary<Type, Action<MultiGetHitJsonConverter.MultiHitTuple, JsonSerializer, ICollection<IMultiGetHit<object>>>>();
			this.CreateSearchResponseDelegates = new ConcurrentDictionary<Type, Action<MultiSearchResponseJsonConverter.SearchHitTuple, JsonSerializer, IDictionary<string, object>>>();
		}
		public string Resolve(IUrlParameter urlParameter) => urlParameter.GetString(this._connectionSettings);

		public string Field(Field field) => this.FieldResolver.Resolve(field);

		public string PropertyName(PropertyName property) => this.FieldResolver.Resolve(property);

		public string IndexName<T>() where T : class => this.IndexNameResolver.Resolve<T>();

		public string IndexName(IndexName index) => this.IndexNameResolver.Resolve(index);

		public string Id<T>(T obj) where T : class => this.IdResolver.Resolve(obj);

		public string Id(Type objType, object obj) => this.IdResolver.Resolve(objType, obj);

		public string TypeName<T>() where T : class => this.TypeNameResolver.Resolve<T>();

		public string TypeName(TypeName type) => this.TypeNameResolver.Resolve(type);
	}
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Elasticsearch.Net;

namespace Tests.Framework
{
	public class VirtualCluster
	{
		private readonly List<Node> _nodes;

		public List<ISniffRule> SniffingRules { get; } = new List<ISniffRule>();
		public List<IRule> PingingRules { get; } = new List<IRule>();
		public List<IClientCallRule> ClientCallRules { get; } = new List<IClientCallRule>();
		public TestableDateTimeProvider DateTimeProvider { get; } = new TestableDateTimeProvider();

		private bool _sniffReturnsFqdn = false;
		internal bool SniffShouldReturnFqnd => _sniffReturnsFqdn;

		private string _publishAddress;
		internal string PublishAddressOverride => _publishAddress;

		public IReadOnlyList<Node> Nodes => _nodes;

		public VirtualCluster(IEnumerable<Node> nodes)
		{
			this._nodes = nodes.ToList();
		}

		public VirtualCluster SniffShouldReturnFqdn()
		{
			_sniffReturnsFqdn = true;
			return this;
		}

		public VirtualCluster PublishAddress(string publishHost)
		{
			_publishAddress = publishHost;
			return this;
		}

		public VirtualCluster MasterEligible(params int[] ports)
		{
			foreach (var node in this._nodes.Where(n => !ports.Contains(n.Uri.Port)))
				node.MasterEligible = false;
			return this;
		}

		public VirtualCluster StoresNoData(params int[] ports)
		{
			foreach (var node in this._nodes.Where(n => ports.Contains(n.Uri.Port)))
				node.HoldsData = false;
			return this;
		}
		public VirtualCluster HasSetting(string key, string value, params int[] ports)
		{
			foreach (var node in this._nodes.Where(n => ports.Contains(n.Uri.Port)))
				node.Settings = new ReadOnlyDictionary<string, string>(new Dictionary<string, string>{{key, value}});
			return this;
		}
		public VirtualCluster HttpDisabled(params int[] ports)
		{
			foreach (var node in this._nodes.Where(n => ports.Contains(n.Uri.Port)))
				node.HttpEnabled = false;
			return this;
		}

		public VirtualCluster Ping(Func<PingRule, IRule> selector)
		{
			this.PingingRules.Add(selector(new PingRule()));
			return this;
		}

		public VirtualCluster Sniff(Func<SniffRule, ISniffRule> selector)
		{
			this.SniffingRules.Add(selector(new SniffRule()));
			return this;
		}
		public VirtualCluster ClientCalls(Func<ClientCallRule, IClientCallRule> selector)
		{
			this.ClientCallRules.Add(selector(new ClientCallRule()));
			return this;
		}

		public SealedVirtualCluster SingleNodeConnection(Func<IList<Node>, IEnumerable<Node>> seedNodesSelector = null)
		{
			var nodes = seedNodesSelector?.Invoke(this._nodes) ?? this._nodes;
			return new SealedVirtualCluster(this, new SingleNodeConnectionPool(nodes.First().Uri), this.DateTimeProvider);
		}
		public SealedVirtualCluster StaticConnectionPool(Func<IList<Node>, IEnumerable<Node>> seedNodesSelector = null)
		{
			var nodes = seedNodesSelector?.Invoke(this._nodes) ?? this._nodes;
			return new SealedVirtualCluster(this, new StaticConnectionPool(nodes, randomize: false, dateTimeProvider: this.DateTimeProvider), this.DateTimeProvider);
		}

		public SealedVirtualCluster SniffingConnectionPool(Func<IList<Node>, IEnumerable<Node>> seedNodesSelector = null)
		{
			var nodes = seedNodesSelector?.Invoke(this._nodes) ?? this._nodes;
			return new SealedVirtualCluster(this, new SniffingConnectionPool(nodes, randomize: false, dateTimeProvider: this.DateTimeProvider), this.DateTimeProvider);
		}

		public SealedVirtualCluster StickyConnectionPool(Func<IList<Node>, IEnumerable<Node>> seedNodesSelector = null)
		{
			var nodes = seedNodesSelector?.Invoke(this._nodes) ?? this._nodes;
			return new SealedVirtualCluster(this, new StickyConnectionPool(nodes, dateTimeProvider: this.DateTimeProvider), this.DateTimeProvider);
		}

		public SealedVirtualCluster StickySniffingConnectionPool(Func<Node, float> sorter = null, Func<IList<Node>,  IEnumerable<Node>> seedNodesSelector = null)
		{
			var nodes = seedNodesSelector?.Invoke(this._nodes) ?? this._nodes;
			return new SealedVirtualCluster(this, new StickySniffingConnectionPool(nodes, sorter ,dateTimeProvider: this.DateTimeProvider), this.DateTimeProvider);
		}
	}

}

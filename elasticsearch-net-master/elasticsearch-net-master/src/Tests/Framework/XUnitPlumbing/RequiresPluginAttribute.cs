using System;
using System.Collections.Generic;
using System.Linq;
using Tests.Framework.Integration;
using Tests.Framework.ManagedElasticsearch;
using Tests.Framework.ManagedElasticsearch.Plugins;

namespace Tests.Framework
{
	public class RequiresPluginAttribute : Attribute
	{
		public IList<ElasticsearchPlugin> Plugins { get; }

		public RequiresPluginAttribute(params ElasticsearchPlugin[] plugins)
		{
			if (plugins == null)
				throw new ArgumentNullException(nameof(plugins));

			this.Plugins = plugins.ToList();
		}
	}
}

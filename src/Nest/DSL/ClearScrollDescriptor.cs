﻿using Elasticsearch.Net;

namespace Nest
{
	[DescriptorFor("ClearScroll")]
	public partial class ClearScrollDescriptor : BasePathDescriptor<ClearScrollDescriptor, ClearScrollRequestParameters>
	{
		internal string _ScrollId { get; set; }

		/// <summary>
		/// Specify the {name} part of the operation
		/// </summary>
		public ClearScrollDescriptor ScrollId(string scrollId)
		{
			this._ScrollId = scrollId;
			return this;
		}

		protected override void UpdatePathInfo(IConnectionSettingsValues settings, ElasticsearchPathInfo<ClearScrollRequestParameters> pathInfo)
		{
			if (this._ScrollId.IsNullOrEmpty())
				throw new DslException("missing ScrollId()");

			pathInfo.ScrollId = this._ScrollId;
			pathInfo.HttpMethod = PathInfoHttpMethod.DELETE;
			
		}
	}
}

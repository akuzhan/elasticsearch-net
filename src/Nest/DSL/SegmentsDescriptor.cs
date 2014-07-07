﻿using Elasticsearch.Net;

namespace Nest
{
	[DescriptorFor("IndicesSegments")]
	public partial class SegmentsDescriptor : IndicesOptionalPathDescriptor<SegmentsDescriptor, SegmentsRequestParameters>
	{
		protected override void UpdatePathInfo(IConnectionSettingsValues settings, ElasticsearchPathInfo<SegmentsRequestParameters> pathInfo)
		{
			pathInfo.HttpMethod = PathInfoHttpMethod.GET;
		}
	}
}

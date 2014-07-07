using NUnit.Framework;


namespace Elasticsearch.Net.Integration.Yaml.Create11
{
	public partial class Create11YamlTests
	{	


		[NCrunch.Framework.ExclusivelyUses("ElasticsearchYamlTests")]
		public class Timestamp1Tests : YamlTestsBase
		{
			[Test]
			public void Timestamp1Test()
			{	

				//do indices.create 
				_body = new {
					mappings= new {
						test= new {
							_timestamp= new {
								enabled= "1",
								store= "yes"
							}
						}
					}
				};
				this.Do(()=> _client.IndicesCreate("test_1", _body));

				//do cluster.health 
				this.Do(()=> _client.ClusterHealth(nv=>nv
					.AddQueryString("wait_for_status", @"yellow")
				));

				//do create 
				_body = new {
					foo= "bar"
				};
				this.Do(()=> _client.Index("test_1", "test", "1", _body, nv=>nv
					.AddQueryString("op_type", @"create")
				));

				//do get 
				this.Do(()=> _client.Get("test_1", "test", "1", nv=>nv
					.AddQueryString("fields", @"_timestamp")
				));

				//is_true _response.fields._timestamp; 
				this.IsTrue(_response.fields._timestamp);

				//do delete 
				this.Do(()=> _client.Delete("test_1", "test", "1"));

				//do create 
				_body = new {
					foo= "bar"
				};
				this.Do(()=> _client.Index("test_1", "test", "1", _body, nv=>nv
					.AddQueryString("timestamp", @"1372011280000")
					.AddQueryString("op_type", @"create")
				));

				//do get 
				this.Do(()=> _client.Get("test_1", "test", "1", nv=>nv
					.AddQueryString("fields", @"_timestamp")
				));

				//match _response.fields._timestamp: 
				this.IsMatch(_response.fields._timestamp, @"1372011280000");

				//do delete 
				this.Do(()=> _client.Delete("test_1", "test", "1"));

				//do create 
				_body = new {
					foo= "bar"
				};
				this.Do(()=> _client.Index("test_1", "test", "1", _body, nv=>nv
					.AddQueryString("timestamp", @"2013-06-23T18:14:40")
					.AddQueryString("op_type", @"create")
				));

				//do get 
				this.Do(()=> _client.Get("test_1", "test", "1", nv=>nv
					.AddQueryString("fields", @"_timestamp")
				));

				//match _response.fields._timestamp: 
				this.IsMatch(_response.fields._timestamp, @"1372011280000");

			}
		}
	}
}


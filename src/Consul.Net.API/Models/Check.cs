using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace Consul.Net
{
	//TODO: Fully implement check format from https://www.consul.io/api/agent/check.html
	[GeneratedCode("quicktype.io", "7.0.0")]
	public partial class Check
	{
		[JsonProperty("DeregisterCriticalServiceAfter")]
		public string DeregisterCriticalServiceAfter { get; set; }

		[JsonProperty("Args")]
		public string[] Args { get; set; }

		[JsonProperty("HTTP")]
		public string Http { get; set; }

		[JsonProperty("Interval")]
		public string Interval { get; set; }

		[JsonProperty("TTL")]
		public string Ttl { get; set; }
	}
}
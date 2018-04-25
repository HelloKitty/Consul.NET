using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace Consul.Net
{
	/// <summary>
	/// JSON Model for Lan and wan pairs.
	/// </summary>
	[GeneratedCode("quicktype.io", "7.0.0")]
	public partial class TaggedAddresses
	{
		[JsonProperty("lan")]
		public string Lan { get; set; }

		[JsonProperty("wan")]
		public string Wan { get; set; }
	}
}
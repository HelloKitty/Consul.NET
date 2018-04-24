using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Consul.Net
{
	/// <summary>
	/// JSON model format for the Agent service registeration API.
	/// See: https://www.consul.io/api/agent/service.html
	/// </summary>
	[GeneratedCode("quicktype.io", "7.0.0")]
	public partial class AgentServiceRegisterationRequest
	{
		/// <summary>
		/// Specifies a unique ID for this service. This must be unique per agent. 
		/// This defaults to the Name parameter if not provided.
		/// </summary>
		[JsonProperty("ID")]
		public string Id { get; set; }

		/// <summary>
		/// Specifies the logical name of the service. 
		/// Many service instances may share the same logical service name.
		/// </summary>
		[JsonProperty("Name")]
		public string Name { get; set; }

		/// <summary>
		/// Specifies a list of tags to assign to the service. 
		/// These tags can be used for later filtering and are exposed via the APIs.
		/// </summary>
		[JsonProperty("Tags")]
		public string[] Tags { get; set; }

		/// <summary>
		/// Specifies the address of the service. 
		/// If not provided, the agent's address is used as the address for the service during DNS queries.
		/// </summary>
		[JsonProperty("Address")]
		public string Address { get; set; }
			
		//We only use int because Consul API uses int. Should be short imo
		/// <summary>
		/// Specifies the port of the service.
		/// </summary>
		[JsonProperty("Port")]
		public int Port { get; set; }

		/// <summary>
		/// Specifies arbitrary KV metadata linked to the service instance.
		/// </summary>
		[JsonProperty("Meta")]
		public Dictionary<string, string> Meta { get; set; }

		[JsonProperty("EnableTagOverride")]
		public bool EnableTagOverride { get; set; }
		
		//Optional
		/// <summary>
		/// Specifies a check.
		/// If you don't provide a name or id for the check then they will be generated. 
		/// To provide a custom id and/or name set the CheckID and/or Name field.
		/// See: https://www.consul.io/api/agent/check.html
		/// </summary>
		[JsonProperty("Check")]
		public Check[] Check { get; set; }

		/// <inheritdoc />
		public AgentServiceRegisterationRequest()
		{
			
		}
	}
}
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Consul.Net
{
	/// <summary>
	/// Consumer model that represents a service registeration.
	/// Based on model: https://github.com/hashicorp/consul/blob/master/api/agent.go#L62
	/// </summary>
	[GeneratedCode("quicktype.io", "7.0.0")]
	public partial class AgentServiceEntry
	{
		/// <summary>
		/// Unique identifier.
		/// </summary>
		[JsonProperty("ID")]
		public string Id { get; set; }

		/// <summary>
		/// Service name.
		/// </summary>
		[JsonProperty("Service")]
		public string Service { get; set; }

		/// <summary>
		/// Optional tags attached to the service.
		/// </summary>
		[JsonProperty("Tags")]
		public string[] Tags { get; set; }

		/// <summary>
		/// Service endpoint address.
		/// </summary>
		[JsonProperty("Address")]
		public string Address { get; set; }
		
		/// <summary>
		/// Metadata dictionary associated with the service.
		/// </summary>
		[JsonProperty("Meta")]
		public Dictionary<string, string> Meta { get; set; }

		//We use int only because original API uses int for model. Should be short though.
		[JsonProperty("Port")]
		public int Port { get; set; }

		/// <inheritdoc />
		public override string ToString()
		{
			return $"Id: {Id} Service: {Service} Address: {Address} Port: {Port} Tags: {Tags?.Aggregate("", (s, o) => $"{s} {o}")}";
		}
	}
}
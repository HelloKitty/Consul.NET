using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Consul.Net
{
	/// <summary>
	/// JSON Model returned by the Catalog API when querying for services on a node.
	/// </summary>
	[GeneratedCode("quicktype.io", "7.0.0")]
	public partial class CatalogServiceNodeEntry
	{
		//TODO: Doc?
		[JsonProperty("ID")]
		public string Id { get; set; }

		/// <summary>
		/// Is the name of the Consul node on which the service is registered
		/// </summary>
		[JsonProperty("Node")]
		public string Node { get; set; }

		/// <summary>
		/// Is the IP address of the Consul node on which the service is registered.
		/// </summary>
		[JsonProperty("Address")]
		public string Address { get; set; }

		/// <summary>
		/// Is the data center of the Consul node on which the service is registered.
		/// </summary>
		[JsonProperty("Datacenter")]
		public string Datacenter { get; set; }

		/// <summary>
		/// Is the list of explicit LAN and WAN IP addresses for the agent
		/// </summary>
		[JsonProperty("TaggedAddresses")]
		public TaggedAddresses TaggedAddresses { get; set; }

		/// <summary>
		/// Is a list of user-defined metadata key/value pairs for the node
		/// </summary>
		[JsonProperty("NodeMeta")]
		public Dictionary<string, string> NodeMeta { get; set; }

		//TODO: What should size be?
		/// <summary>
		/// Is an internal index value representing when the service was created
		/// </summary>
		[JsonProperty("CreateIndex")]
		public long CreateIndex { get; set; }

		//TODO: What should size be?
		/// <summary>
		/// Is the last index that modified the service
		/// </summary>
		[JsonProperty("ModifyIndex")]
		public long ModifyIndex { get; set; }

		/// <summary>
		/// Is the IP address of the service host — if empty, node address should be used
		/// </summary>
		[JsonProperty("ServiceAddress")]
		public string ServiceAddress { get; set; }

		/// <summary>
		/// Indicates whether service tags can be overridden on this service
		/// </summary>
		[JsonProperty("ServiceEnableTagOverride")]
		public bool ServiceEnableTagOverride { get; set; }

		/// <summary>
		/// Is a unique service instance identifier
		/// </summary>
		[JsonProperty("ServiceID")]
		public string ServiceId { get; set; }

		/// <summary>
		/// Is the name of the service
		/// </summary>
		[JsonProperty("ServiceName")]
		public string ServiceName { get; set; }

		//We only use int because Consul uses int. Imo should be short.
		/// <summary>
		/// Is the port number of the service
		/// </summary>
		[JsonProperty("ServicePort")]
		public int ServicePort { get; set; }

		[JsonProperty("ServiceMeta")]
		public Dictionary<string, string> ServiceMeta { get; set; }

		[JsonProperty("ServiceTags")]
		public string[] ServiceTags { get; set; }
	}
}
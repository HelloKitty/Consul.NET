using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TypeSafe.Http.Net;

namespace Consul.Net
{
	//Implementation of Consul Agent API: https://www.consul.io/api/agent/service.html
	/// <summary>
	/// Service contract/interface for API associated with /agent/services.
	/// (This is not the full agent API)
	/// See: https://www.consul.io/api/agent/service.html
	/// </summary>
	[ConsulUserAgentHeader]
	public interface IConsulAgentServiceHttpApiService
	{
		/// See: https://github.com/hashicorp/consul/blob/master/api/agent.go#L252
		/// <summary>
		/// Queries the Consul API agent for registered services.
		/// See: https://www.consul.io/api/agent/service.html
		/// </summary>
		/// <returns></returns>
		[Get("/v1/agent/services")]
		Task<Dictionary<string, AgentServiceEntry>> GetServices();

		/// <summary>
		/// Attempts to register a service based on the provided <see cref="AgentServiceRegisterationRequest"/>
		/// model.
		/// </summary>
		/// <exception cref="Exception">Throws if the request failed.</exception>
		/// <param name="registerationRequest">The registeration data.</param>
		[Put("/v1/agent/service/register")]
		Task RegisterService([JsonBody] AgentServiceRegisterationRequest registerationRequest);
	}
}

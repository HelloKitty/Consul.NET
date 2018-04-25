using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TypeSafe.Http.Net;

namespace Consul.Net
{
	/// <summary>
	/// Service interface/contract for the Consul Catalog API.
	/// </summary>
	[ConsulUserAgentHeader]
	public interface IConsulCatalogServiceHttpApiService
	{
		//As of right now catalog register/deregister API will not be implemented
		//This is mostly because for most use-cases you should register through agents and not with the catalog

		//TODO: Implement the rest of the catalog API
		/// <summary>
		/// Returns a map of all service entries with their corresponding array of tags.
		/// "The keys are the service names, and the array values provide all known tags for a given service."
		/// See: https://www.consul.io/api/catalog.html
		/// </summary>
		/// <returns>A map of service entries and their tags.</returns>
		[Get("/v1/catalog/services")]
		Task<Dictionary<string, string[]>> GetServices();

		//TODO: Impelment metadata included overload

		/// <summary>
		/// Returns a map of all service entries with their corresponding array of tags.
		/// "The keys are the service names, and the array values provide all known tags for a given service."
		/// See: https://www.consul.io/api/catalog.html
		/// </summary>
		/// <param name="datacenter"> Specifies the datacenter to query. 
		/// This will default to the datacenter of the agent being queried. 
		/// This is specified as part of the URL as a query parameter.</param>
		/// <returns>A map of service entries and their tags.</returns>
		[Get("/v1/catalog/services")]
		Task<Dictionary<string, string[]>> GetServices([QueryStringParameter, AliasAs("dc")] string datacenter);

		/// <summary>
		/// Returns a collection of all services of the specified <see cref="service"/> type
		/// with full node information.
		/// </summary>
		/// <param name="service">The name of the service.</param>
		/// <returns>Collection of registered services on the node.</returns>
		[Get("/v1/catalog/service/{service}")]
		Task<CatalogServiceNodeEntry[]> GetServiceNodes(string service);

		/// <summary>
		/// Returns a collection of all services of the specified <see cref="service"/> type
		/// with full node information.
		/// Will filter based on the provided <see cref="tagFilter"/>
		/// </summary>
		/// <param name="service">The name of the service.</param>
		/// <param name="tagFilter">The tags to filter for.</param>
		/// <returns>Collection of registered services on the node.</returns>
		[Get("/v1/catalog/service/{service}")]
		Task<CatalogServiceNodeEntry[]> GetServiceNodes(string service, [QueryStringParameter, AliasAs("tag")] string tagFilter);
	}
}

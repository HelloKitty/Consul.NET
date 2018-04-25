using System;
using System.Collections.Generic;
using System.Text;

namespace Consul.Net
{
	/// <summary>
	/// Contract for all Consul clients provided by the Consul.Net library.
	/// </summary>
	/// <typeparam name="TConsulServiceType">The type of service to expose. (Ex. <see cref="IConsulAgentServiceHttpApiService"/>)</typeparam>
	public interface IConsulClient<out TConsulServiceType>
	{
		/// <summary>
		/// The specific Consul service.
		/// </summary>
		TConsulServiceType Service { get; }
	}
}

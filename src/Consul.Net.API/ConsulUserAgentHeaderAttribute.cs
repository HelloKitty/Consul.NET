using System;
using System.Collections.Generic;
using System.Text;
using TypeSafe.Http.Net;

namespace Consul.Net
{
	/// <summary>
	/// <see cref="HeaderAttribute"/> that adds a User-Agent for the Consul client.
	/// </summary>
	public sealed class ConsulUserAgentHeaderAttribute : HeaderAttribute
	{
		/// <inheritdoc />
		public ConsulUserAgentHeaderAttribute() 
			: base("User-Agent", ConsulConstants.UserAgent)
		{

		}
	}
}

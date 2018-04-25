using System;
using System.Net.Http;
using TypeSafe.Http.Net;

namespace Consul.Net
{
	/// <summary>
	/// .NET <see cref="HttpClient"/> implementation of the <see cref="IConsulClient{TConsulServiceType}"/>.
	/// Services the API requests over the .NET <see cref="HttpClient"/>.
	/// (Other implementations can exists)
	/// </summary>
	/// <typeparam name="TConsulServiceType">The type of the consul service.</typeparam>
	public sealed class ConsulDotNetHttpClient<TConsulServiceType> : IConsulClient<TConsulServiceType> 
		where TConsulServiceType : class
	{
		/// <inheritdoc />
		public TConsulServiceType Service { get; }

		public ConsulDotNetHttpClient(string endpoint)
		{
			if(string.IsNullOrWhiteSpace(endpoint)) throw new ArgumentException("Value cannot be null or whitespace.", nameof(endpoint));

			Service = TypeSafeHttpBuilder<TConsulServiceType>
				.Create()
				.RegisterDefaultSerializers()
				.RegisterDotNetHttpClient(endpoint)
				.RegisterJsonNetSerializer()
				.Build();

			if(Service == null)
				throw new InvalidOperationException($"Failed to build {nameof(Service)} for Type: {typeof(TConsulServiceType).Name}");
		}
	}
}

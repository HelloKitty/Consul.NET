using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TypeSafe.Http.Net;

namespace Consul.Net.Manual.Test
{
	class Program
	{
		static async Task Main(string[] args)
		{
			IConsulAgentServiceHttpApiService consulAgentService = TypeSafeHttpBuilder<IConsulAgentServiceHttpApiService>
				.Create()
				.RegisterDefaultSerializers()
				.RegisterJsonNetSerializer()
				.RegisterDotNetHttpClient("http://localhost.fiddler:8500")
				.Build();

			IConsulCatalogServiceHttpApiService consulCatalogService = TypeSafeHttpBuilder<IConsulCatalogServiceHttpApiService>
				.Create()
				.RegisterDefaultSerializers()
				.RegisterJsonNetSerializer()
				.RegisterDotNetHttpClient("http://localhost.fiddler:8500")
				.Build();

			//Manually tests registeration
			await consulAgentService.RegisterService(new AgentServiceRegisterationRequest()
			{
				Address = "127.0.0.1",
				Name = "TestService2",
				Id = Guid.NewGuid().ToString(),
				Port = 5001,
				Tags = new []{"CN"}
			});

			Dictionary<string, AgentServiceEntry> servicesResponse = await consulAgentService.GetServices();

			foreach(var entry in servicesResponse)
			{
				Console.WriteLine(entry.Value.ToString());
			}

			//Manual testing for catalog API
			Dictionary<string, string[]> serviceEntries = await consulCatalogService.GetServices();

			foreach(var kvp in serviceEntries)
			{
				Console.WriteLine($"{kvp.Key} Tags: {kvp.Value.Aggregate("", (s, s1) => $"{s} {s1}")}");
			}

			CatalogServiceNodeEntry[] entries = await consulCatalogService.GetServiceNodes("TestService2");

			foreach(CatalogServiceNodeEntry entry in entries)
			{
				//Convert to JSON for easier logging
				string o = JsonConvert.SerializeObject(entry);
				Console.WriteLine(o);
			}

			CatalogServiceNodeEntry[] entries2 = await consulCatalogService.GetServiceNodes("TestService2", "NA");

			Console.WriteLine("\n\n\n");

			foreach(CatalogServiceNodeEntry entry in entries)
			{
				//Convert to JSON for easier logging
				string o = JsonConvert.SerializeObject(entry);
				Console.WriteLine(o);
			}

			Console.ReadKey();
		}
	}
}

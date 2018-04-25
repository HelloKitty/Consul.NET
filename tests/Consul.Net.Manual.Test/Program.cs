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
			IConsulClient<IConsulAgentServiceHttpApiService> consulAgentService = 
				new ConsulDotNetHttpClient<IConsulAgentServiceHttpApiService>(@"http://localhost.fiddler:8500");

			IConsulClient<IConsulCatalogServiceHttpApiService> consulCatalogService =
				new ConsulDotNetHttpClient<IConsulCatalogServiceHttpApiService>(@"http://localhost.fiddler:8500");

			//Manually tests registeration
			await consulAgentService.Service.RegisterService(new AgentServiceRegisterationRequest()
			{
				Address = "127.0.0.1",
				Name = "TestService2",
				Id = Guid.NewGuid().ToString(),
				Port = 5001,
				Tags = new []{"CN"}
			});

			Dictionary<string, AgentServiceEntry> servicesResponse = await consulAgentService.Service.GetServices();

			foreach(var entry in servicesResponse)
			{
				Console.WriteLine(entry.Value.ToString());
			}

			//Manual testing for catalog API
			Dictionary<string, string[]> serviceEntries = await consulCatalogService.Service.GetServices();

			foreach(var kvp in serviceEntries)
			{
				Console.WriteLine($"{kvp.Key} Tags: {kvp.Value.Aggregate("", (s, s1) => $"{s} {s1}")}");
			}

			CatalogServiceNodeEntry[] entries = await consulCatalogService.Service.GetServiceNodes("TestService2");

			foreach(CatalogServiceNodeEntry entry in entries)
			{
				//Convert to JSON for easier logging
				string o = JsonConvert.SerializeObject(entry);
				Console.WriteLine(o);
			}

			CatalogServiceNodeEntry[] entries2 = await consulCatalogService.Service.GetServiceNodes("TestService2", "NA");

			Console.WriteLine("\n\n\n");

			foreach(CatalogServiceNodeEntry entry in entries2)
			{
				//Convert to JSON for easier logging
				string o = JsonConvert.SerializeObject(entry);
				Console.WriteLine(o);
			}

			Console.ReadKey();
		}
	}
}

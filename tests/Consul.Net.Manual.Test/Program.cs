using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

			//Manually tests registeration
			await consulAgentService.RegisterService(new AgentServiceRegisterationRequest()
			{
				Address = "127.0.0.1",
				Name = "TestService2",
				Port = 5001,
			});

			Dictionary<string, AgentServiceEntry> servicesResponse = await consulAgentService.GetServices();

			foreach(var entry in servicesResponse)
			{
				Console.WriteLine(entry.Value.ToString());
			}

			Console.ReadKey();
		}
	}
}

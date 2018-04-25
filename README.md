# Consul.NET

.NET C# API client for Consul (http://www.consul.io/)

* Consul API: [v1.0.7](https://github.com/hashicorp/consul/tree/v1.0.7/api)
* .NET: >= 4.5 - .NETStandard >= 1.4

Consul.NET is an implementation of the Consul API for .NET. It is built on top of [TypeSafe.Http.Net](https://github.com/HelloKitty/TypeSafe.Http.Net) which is a typesafe automatic HTTP/REST client library based on Refit/Retrofit. This means that the Consul API implementation in this library provides a rich set of service interfaces with strongly typed JSON models where possible. Supports task-based async service calls and multiple HttpClient implementations are possible meaning if you or your company has their own HttpClient that must be used it can be implemented simply with [TypeSafe.Http.Net](https://github.com/HelloKitty/TypeSafe.Http.Net).

## Features

TODO

## Getting Started

1. Reference NuGet [Consul.Net.API](TODO) for projects that need to reference IConsul\<T\> or that require the Consul service interfaces as dependencies.

2. Reference NuGet for client implementation. (Ex. [Consul.Net.Client.DotNetHttpClient](TODO))

3. Create a IConsul\<T\> client where T is the service interface you're interested in. (Ex IConsul\<IConsulCatalogServiceHttpApiService\>) **see examples**

4. Make service calls with the client or register the Service field from IConsul<\T\> with your IoC/DI container.

## Examples

These examples assumes you're already running Consul and are already familiar with it. See the official [Consul](https://www.consul.io/intro/getting-started/install.html) guide on getting started if you're not.

These examples will also assume you're using the [Consul.Net.Client.DotNetHttpClient](TODO) package.

You can reuse the created client. You do not need to create one per service call. Though the examples will show this behavior so that they
are runnable.


#### Querying Consul Catalog API for Registered Services
The below example will query the Consul Catalog API for nodes that provide the service specified.

```csharp
//Create the DotNetHttpClient Consul client for the Consul Catalog service interface
IConsulClient<IConsulCatalogServiceHttpApiService> consulCatalogService =
				new ConsulDotNetHttpClient<IConsulCatalogServiceHttpApiService>(@"http://localhost:8500");
        
CatalogServiceNodeEntry[] entries = await consulCatalogService.Service.GetServiceNodes("TestService");
```

# Under Development

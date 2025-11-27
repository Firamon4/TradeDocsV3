using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TradeDocs.Service;

IHost host = Host.CreateDefaultBuilder(args)
    .UseWindowsService(options =>
    {
        options.ServiceName = "TradeDocsService";
    })
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
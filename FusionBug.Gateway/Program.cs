using HotChocolate.Fusion.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
var services = builder.Services;
services.AddGraphQLGatewayServer()
    .AddConfigurationProvider(x => new FileSystemFusionConfigurationProvider("./gateway.far"));
var app = builder.Build();

app.MapDefaultEndpoints();
app.MapGraphQL();
app.Run();
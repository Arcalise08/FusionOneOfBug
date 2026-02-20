using FusionBug.Downstream.Graph;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
var services = builder.Services;

services.AddGraphQLServer()
    .ModifyOptions(o => o.EnableOneOf = true)
    .AddQueryType<FooGraph>(d => d.Name("Query"));

var app = builder.Build();

app.MapDefaultEndpoints();

app.MapGraphQL();
await app.RunWithGraphQLCommandsAsync(args);
using FusionBug.Downstream.Graph;
using FusionBug.Downstream.Models;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
var services = builder.Services;

services.AddGraphQLServer()
    .ModifyOptions(o => o.EnableOneOf = true)
    .AddQueryType<FooGraph>();

var app = builder.Build();

app.MapDefaultEndpoints();

app.MapGraphQL();
await app.RunWithGraphQLCommandsAsync(args);
using FusionBug.Downstream.Graph;
using FusionBug.Downstream.Models;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddGraphQLServer()
    .ModifyOptions(o => o.EnableOneOf = true)
    .AddQueryType<FooGraph>();

var app = builder.Build();

app.MapGraphQL();
await app.RunWithGraphQLCommandsAsync(args);
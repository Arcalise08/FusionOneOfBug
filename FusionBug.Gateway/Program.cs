var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
var services = builder.Services;
services.AddFusionGatewayServer()
    .ConfigureFromFile("./gateway.fgp");
var app = builder.Build();

app.MapDefaultEndpoints();
app.MapGraphQL();
app.Run();
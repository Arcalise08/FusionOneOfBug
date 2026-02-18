var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
services.AddFusionGatewayServer()
    .ConfigureFromFile("./gateway.fgp");
var app = builder.Build();
app.MapGraphQL();
app.Run();
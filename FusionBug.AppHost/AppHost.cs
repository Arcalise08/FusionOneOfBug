var builder = DistributedApplication.CreateBuilder(args);

var downstream = builder.AddProject<Projects.FusionBug_Downstream>("fusionbug-downstream");

builder.AddProject<Projects.FusionBug_Gateway>("fusionbug-gateway")
    .WithReference(downstream);

builder.Build().Run();

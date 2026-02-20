var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.FusionBug_Downstream>("fusionbug-downstream");

builder.AddProject<Projects.FusionBug_Gateway>("fusionbug-gateway");

builder.Build().Run();

var builder = DistributedApplication.CreateBuilder(args);

var discordToken = builder.AddParameter("discord-token", secret: true);

// laya priority classifier — bot falls back gracefully when this is down
builder.AddPythonApp("laya-classifier", "../../../../../laya-playground", "server.py")
    .WithVirtualEnvironment(".venv");

builder.AddProject("bot-discord", "../../../../DotNet/Bot.Discord/src/Bot.Discord.csproj")
    .WithEnvironment("Discord__Token", discordToken);

builder.Build().Run();

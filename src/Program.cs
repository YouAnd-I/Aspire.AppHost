var builder = DistributedApplication.CreateBuilder(args);

var discordToken = builder.AddParameter("discord-token", secret: true);

builder.AddProject("bot-discord", "../../../../DotNet/Bot.Discord/src/Bot.Discord.csproj")
    .WithEnvironment("Discord__Token", discordToken);

builder.Build().Run();

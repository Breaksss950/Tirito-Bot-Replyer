using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using DotNetEnv;

class Program
{
    private DiscordSocketClient _client;

    static Task Main() => new Program().MainAsync();

    public async Task MainAsync()
    {
        Env.Load();
        string token = Environment.GetEnvironmentVariable("DISCORD_TOKEN");

        _client = new DiscordSocketClient();
        _client.Log += LogAsync;
        _client.MessageReceived += MessageReceivedAsync;

        await _client.LoginAsync(TokenType.Bot, token);
        await _client.StartAsync();

        await Task.Delay(-1);
    }

    private Task LogAsync(LogMessage msg)
    {
        Console.WriteLine(msg.ToString());
        return Task.CompletedTask;
    }

    private async Task MessageReceivedAsync(SocketMessage message)
    {
        if (message.Author.IsBot) return;
        if ((message.Channel as SocketGuildChannel)?.Guild.Id != 1112009067808964721) return;
        await message.AddReactionAsync(new Emoji("<:emoji:1472007413874819226>"));
    }
}

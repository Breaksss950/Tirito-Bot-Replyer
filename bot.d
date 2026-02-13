import DSharp;
import std.process;
import std.env;

void main() {
    auto token = getEnv("DISCORD_TOKEN");
    auto client = new DiscordClient(token);

    client.onMessageCreate = (msg) {
        if(msg.author.bot) return;
        if(msg.guildId != 1112009067808964721) return;
        msg.addReaction("<:emoji:1472007413874819226>");
    };

    client.connect();
}

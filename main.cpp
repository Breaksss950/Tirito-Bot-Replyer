#include <dpp/dpp.h>
#include <cstdlib>

int main() {
    const char* token = std::getenv("DISCORD_TOKEN");
    dpp::cluster bot(token);

    bot.on_log(dpp::utility::cout_logger());

    bot.on_message_create([&bot](const dpp::message_create_t& event) {
        if (event.msg.guild_id != 1112009067808964721 || event.msg.author.is_bot())
            return;
        bot.message_add_reaction(event.msg.channel_id, event.msg.id, "1472007413874819226");
    });

    bot.start(dpp::st_wait);
}

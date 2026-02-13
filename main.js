require('dotenv').config();
const { Client, GatewayIntentBits } = require('discord.js');

const client = new Client({ intents: [GatewayIntentBits.Guilds, GatewayIntentBits.GuildMessages, GatewayIntentBits.MessageContent] });

client.on('messageCreate', message => {
    if (message.guildId !== '1112009067808964721' || message.author.bot) return;
    message.react('<:emoji:1472007413874819226>');
});

client.login(process.env.DISCORD_TOKEN);

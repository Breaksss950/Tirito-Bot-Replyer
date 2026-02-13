import os
import discord
from dotenv import load_dotenv

load_dotenv()
TOKEN = os.getenv("DISCORD_TOKEN")

intents = discord.Intents.default()
intents.messages = True
intents.guilds = True

client = discord.Client(intents=intents)

@client.event
async def on_message(message):
    if message.guild is None or message.guild.id != 1112009067808964721 or message.author.bot:
        return
    await message.add_reaction("<:emoji:1472007413874819226>")

client.run(TOKEN)

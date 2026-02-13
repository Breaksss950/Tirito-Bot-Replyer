package main

import (
	"os"
	"os/signal"
	"syscall"

	"github.com/bwmarrin/discordgo"
	"github.com/joho/godotenv"
)

func main() {
	godotenv.Load()
	dg, _ := discordgo.New("Bot " + os.Getenv("DISCORD_TOKEN"))

	dg.AddHandler(func(s *discordgo.Session, m *discordgo.MessageCreate) {
		if m.GuildID != "1112009067808964721" || m.Author.Bot {
			return
		}
		s.MessageReactionAdd(m.ChannelID, m.ID, "<:emoji:1472007413874819226>")
	})

	dg.Open()
	defer dg.Close()
	stop := make(chan os.Signal, 1)
	signal.Notify(stop, syscall.SIGINT, syscall.SIGTERM, os.Interrupt)
	<-stop
}

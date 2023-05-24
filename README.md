# Farming Simulator 22 Discord Bot

[![Build](https://github.com/acesyde/fs22_discord_bot/actions/workflows/build.yaml/badge.svg)](https://github.com/acesyde/fs22_discord_bot/actions/workflows/build.yaml)

## Create a bot

1. Create : https://discordjs.guide/preparations/setting-up-a-bot-application.html#creating-your-bot
2. Invite : https://discordjs.guide/preparations/adding-your-bot-to-servers.html#bot-invite-links

## Environment variables

| Name                | Description              |
| ------------------- | ------------------------ |
| DISCORDBOT\_\_TOKEN | Discord bot token        |
| VERYGAME\_\_URL     | Verygame FS22 server url |

## Installation

Use the docker image from the docker github repository.

```sh
docker pull ghcr.io/acesyde/fs22_discord_bot:latest

docker run --name fs22-bot -d ghcr.io/acesyde/fs22_discord_bot:latest
```

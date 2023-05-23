# Farming Simulator 22 Discord Bot

[![Build](https://github.com/acesyde/fs22_discord_bot/actions/workflows/build.yaml/badge.svg)](https://github.com/acesyde/fs22_discord_bot/actions/workflows/build.yaml)

## Create a bot

1) Create : https://discordjs.guide/preparations/setting-up-a-bot-application.html#creating-your-bot
2) Invite : https://discordjs.guide/preparations/adding-your-bot-to-servers.html#bot-invite-links

## Configuration

Create and environment file `.env` with the following content:

```env
DISCORDBOT_TOKEN=my-discord-token
VERYGAME_URL=my-verygame-fs22-url
```

## Installation

Use the docker image from the docker github repository.

```sh
docker pull ghcr.io/acesyde/fs22_discord_bot:latest

docker run --name fs22-bot --env-file .env -d ghcr.io/acesyde/fs22_discord_bot:latest
```
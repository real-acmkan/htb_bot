# HTB Updates

A Discord bot that announces your members Hack The Box solves.

This is a continuation of the original project by `https://github.com/Et3rnos/HTB_Updates`. Refactoring the code is currently a WIP.

There are 2 steps to setup up this bot: creating your own instance of it and then inviting it to your server.

## Creating your own instance

### Clone this repository

Just run `git clone https://github.com/real-acmkan/htb_bot`.

### Creating the configuration

There are 3 configuration files that you must edit: the docker-compose.yml, the appsettings.json configuration for the discord bot and the appsettings.json for the website backend.

These files can be found at `docker-compose.yml` `./HTB Updates Discord Bot/appsettings.json` and `./htb_updates_backend/appsettings.json`.


### Launching the application

This step requires you to have docker installed.

Simply run `docker compose up -d`.

The frontend will be available on `127.0.0.1:8000` so you can set up a reverse proxy in front of it.

__This is the recommended setup as you should manage your domain/SSL certs outside of the docker container__. 


## Invite the bot

To invite the bot to your server all you need to do is follow modify the link below once you have set things up with discord:

`https://discord.com/api/oauth2/authorize?client_id=YOUR_CLIENT_ID&permissions=2048&scope=bot`
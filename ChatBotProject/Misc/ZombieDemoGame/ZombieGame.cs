using AIMLbot;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Unosquare.Swan.Formatters;

namespace ChatBotProject.Misc.ZombieDemoGame
{
    public class ZombieGame : Game
    {
        DiscordUser userStart;
        bool gameRunning = false;
        public List<PlayerSave_Zombie> savesInGame = new List<PlayerSave_Zombie>();

        public ZombieGame() : base("Zombie") { }
        public async override Task StartGame(CommandContext ctx)
        {
            await base.StartGame(ctx);
            PlayerSave_Zombie save = pickupPlayerSave_Zombie(savesInGame, ctx.Message.Author.Id);
            if (!save.running) {
            Task<DiscordMessage> message = ctx.Message.RespondAsync("Starting Zombie Game!!!");
            Console.WriteLine("Someone is playing the zombie bot game!");
            //Start the zombie game!
                save.running = true;
            }
            else
            {
                //Not running
                Console.WriteLine("Game is already running! exclaim stop in the game message to stop the game!");
                await ctx.Message.RespondAsync("Game is already running! exclaim stop to stop the game from running!");
            }
        }

        public override void UpdateChatGame(MessageCreateEventArgs e)
        {
            base.UpdateChatGame(e);
            //Chat line has been operated
            string previousMessage = "";
            //While the game is running!
            if (!e.Author.IsBot)
            {
                PlayerSave_Zombie save = pickupPlayerSave_Zombie(savesInGame, e.Author.Id);
                if (save.running == true)
                {
                    if (save.dead == false)
                    {
                        //Console.WriteLine("Someone is playing the zombie bot game!");
                        if (e.Message.IsEdited || previousMessage != e.Message.Content)
                        {
                            //Rerun the test
                            Zombie closestZombie = getClosestZombie(e.Author.Id);
                            switch (e.Message.Content.ToLower())
                            {
                                case "shoot":
                                    //Shoot the zombie ahead
                                    Random shootChance = new Random();
                                    int finalResult = shootChance.Next(25);
                                    if (finalResult == 10)
                                    {
                                        //Shoot
                                        Random randomHealthClose = new Random();
                                        int healthDeduct = randomHealthClose.Next(5);
                                        closestZombie.health -= healthDeduct;
                                        save.ammo--;
                                        e.Message.ModifyAsync("You have hit the zombie! and have deducted " + healthDeduct);

                                        if (closestZombie.health <= 0)
                                        {
                                            //Show that the zombie died!
                                            e.Message.ModifyAsync("You have killed a zombie!");
                                        }
                                    }
                                    else
                                    {
                                        e.Message.ModifyAsync("You have missed the zombie, and have made no damage!");
                                    }
                                    break;
                                case "stomp":
                                    //Stomp the zombie down
                                    Random stompChance = new Random();
                                    int stompResult = stompChance.Next(1);
                                    closestZombie.health -= stompResult;
                                    e.Message.ModifyAsync("You have stomped the zombie! and have deducted " + stompResult);
                                    if (closestZombie.health <= 0)
                                    {
                                        e.Message.ModifyAsync("I would stop since that zombie you are hitting is already dead!!");
                                    }
                                    break;
                                case "kick":
                                    //Kick the zombie infront down!
                                    e.Message.ModifyAsync("You have tried to kick the zombie down!");
                                    break;
                                case "zombies":
                                    //Checks if theres any zombies ahead
                                    e.Message.ModifyAsync("There is " + save.zombiesAhead.Count + " zombies ahead! the closest zombie is about " + getClosestZombie(e.Author.Id).position + "m away..");
                                    break;
                                case "ammo":
                                    e.Message.ModifyAsync("You have " + save.ammo + " left!");
                                    break;
                            }

                            Random randPickup = new Random();
                            if (randPickup.Next(25) == 12)
                            {
                                Console.WriteLine("Picked up ammo " + e.Author.Username);
                                e.Message.ModifyAsync("You have picked up ammo!");
                            }
                        }

                        Zombie getClosest = getClosestZombie(e.Author.Id);
                        if (getClosest.position <= 1)
                        {
                            //heres the closest zombie!
                            getClosest.attack = true;
                            if (getClosest.attack == true)
                            {
                                getClosest.attackTimer++;
                                if (getClosest.attackTimer > 100)
                                {
                                    save.health--;
                                    getClosest.attackTimer = 0;
                                }
                            }
                        }

                        foreach (Zombie zombieDead in save.zombiesAhead)
                        {
                            if (zombieDead.health <= 0)
                            {
                                save.zombiesAhead.Remove(zombieDead);
                                Console.WriteLine("Removed Zombie because it was dead!!!");
                            }
                            else
                            {
                                if (zombieDead.position >= 1)
                                {
                                    //Move all the zombies closer one by one
                                    while (zombieDead.timerMove <= 100)
                                    {
                                        zombieDead.timerMove++;
                                    }

                                    while (zombieDead.timerMove >= 100)
                                    {
                                        zombieDead.position++;
                                        zombieDead.timerMove = 0;
                                    }
                                }
                            }
                        }

                        //Run ahead to mark how many zombies are head!
                        Random randPickZombies = new Random();
                        if (randPickZombies.Next(10) == 5)
                        {
                            //If at 25 spawn some zombies!
                            Random newRndZombieCount = new Random();
                            //Create a new zombie
                            for (int i = 0; i < newRndZombieCount.Next(10); i++)
                            {
                                Zombie newZombie = new Zombie();
                                newZombie.position = 50;
                                newZombie.health = 5;
                                save.zombiesAhead.Add(newZombie);
                                Console.WriteLine("Added a new zombie to player: " + e.Author.Username);
                            }
                        }
                    }
                    else
                    {
                        //Show that the player is dead! and the game has ended in the other chat!
                    }
                }
                else
                {
                    e.Message.RespondAsync("Game is not currently running! please use <;;game zombie> to run the game!");
                }
            }
            else
            {
                return;
            }
            previousMessage = e.Message.Content;
        }

        public Zombie getClosestZombie(ulong userID)
        {
            //If the zombie is close report
            PlayerSave_Zombie save = pickupPlayerSave_Zombie(savesInGame, userID);
            int closestRange = 50;
            Zombie zombiePicked = null;
            foreach(Zombie saves in save.zombiesAhead)
            {
                if(saves.position <= closestRange)
                {
                    zombiePicked = saves;
                    closestRange = saves.position;
                }
            }
            return zombiePicked;
        }

        public override void InitialiseGame(string gameName, List<GameSaveData> data)
        {
            gameName = "Zombie Game";
            base.InitialiseGame(gameName, data);
            //convert it back bitch
            //savesInGame.AddRange(data);
        }

        public override void DestroyGame(string gameName)
        {
            gameName = "Zombie Game";
            base.DestroyGame(gameName);
        }

        public bool CheckPlayerExists(List<PlayerSave_Zombie> saves, ulong userID)
        {
            //Check if the player exists if so return true if not return false
            bool returnable = false;
            if (saves != null)
            {
                foreach (PlayerSave_Zombie save in saves)
                {
                    if (save.userID == userID)
                    {
                        returnable = true;
                    }
                }
            }
            return returnable;
        }

        public PlayerSave_Zombie pickupPlayerSave_Zombie(List<PlayerSave_Zombie> saves, ulong userID)
        {
            PlayerSave_Zombie pickedSave = null;
            if (saves != null)
            {
                foreach (PlayerSave_Zombie save in saves)
                {
                    if (save.userID == userID)
                    {
                        //Found the user return it!
                        pickedSave = save;
                    }
                }
            }

            if(pickedSave == null)
            {
                //Create a new profile!
                //Create the player in the database!
                PlayerSave_Zombie newSave = new PlayerSave_Zombie();
                newSave.userID = userID;
                newSave.health = 30;
                newSave.ammo = 30;
                saves.Add(newSave);
                pickedSave = newSave;
            }

            return pickedSave;
        }
    }
}

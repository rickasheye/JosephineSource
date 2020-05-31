using AIMLbot.AIMLTagHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBotProject.Misc.ZombieDemoGame
{
    public class PlayerSave_Zombie : GameSaveData
    {
        //Store all types of things in here!
        public int health = 30;
        public int ammo = 30;
        public bool dead = false;
        public List<Zombie> zombiesAhead = new List<Zombie>();
    }
}

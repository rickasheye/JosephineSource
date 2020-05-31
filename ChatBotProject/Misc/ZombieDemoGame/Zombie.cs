using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBotProject.Misc.ZombieDemoGame
{
    public class Zombie
    {
        public int position;
        public int health;
        public int timerMove;

        public bool attack = false;
        public int attackTimer = 0;
    }
}

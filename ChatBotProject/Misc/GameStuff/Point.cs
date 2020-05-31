using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBotProject.Misc.GameStuff
{
    public class Point
    {
        //stores something simmilar too a Vector2 just a littl different
        public float x, y;
        
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Point(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public Point(float value)
        {
            this.x = value;
            this.y = value;
        }

        public Point(int value)
        {
            this.x = value;
            this.y = value;
        }
    }
}

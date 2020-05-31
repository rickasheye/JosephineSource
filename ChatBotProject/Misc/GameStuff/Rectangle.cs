using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBotProject.Misc.GameStuff
{
    public class Rectangle
    {
        public float x1, y1, x2, y2;

        public Rectangle(int x, int y, int size_x, int size_y)
        {
            x1 = x;
            y1 = y;
            x2 = size_x;
            y2 = size_y;
        }

        public Rectangle(float x, float y, float size_x, float size_y)
        {
            x1 = x;
            y1 = y;
            x2 = size_x;
            y2 = size_y;
        }
    }
}

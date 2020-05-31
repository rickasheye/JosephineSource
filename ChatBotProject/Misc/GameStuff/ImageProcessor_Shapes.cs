using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBotProject.Misc.GameStuff
{
    public class ImageProcessor_Shapes : ImageProcessor
    {
        //A whole class that draws shapes all day!
        public static void DrawRectange(Bitmap image, Rectangle rect, Color32 color)
        {
            //Draw a rectangle
            for (int rectx = 0; rectx < rect.x2; rectx++)
            {
                for (int recty = 0; recty < rect.y2; recty++)
                {
                    int xPos = (int)rect.x1 + rectx;
                    int yPos = (int)rect.y1 + recty;
                    if (xPos <= image.Width && xPos >= 0 && yPos >= 0 && yPos <= image.Height)
                    {
                        System.Drawing.Color colorConv = Color.FromArgb(color.R, color.G, color.B);
                        image.SetPixel(xPos, yPos, colorConv); 
                    }
                }
            }
        }

        public static void DrawPixel(Bitmap image, Vector2 point, Color32 color)
        {
            if (point.x <= image.Width && point.x >= 0 && point.y <= image.Height && point.y >= 0)
            {
                System.Drawing.Color colorConv = Color.FromArgb(color.R, color.G, color.B);
                image.SetPixel((int)point.x, (int)point.y, colorConv);
            }
        }
    }
}

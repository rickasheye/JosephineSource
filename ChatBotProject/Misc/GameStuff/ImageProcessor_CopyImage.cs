using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace ChatBotProject.Misc.GameStuff
{
    public class ImageProcessor_CopyImage : ImageProcessor
    {
        //Set or copy image on the top of this!
        public void DuplicateImage(Bitmap originalImage, Bitmap destinationImage, Vector2 position)
        {
            for(int x = 0; x < destinationImage.Width; x++)
            {
                for(int y = 0; y < destinationImage.Height; y++)
                {
                    originalImage.SetPixel((int)position.x + x, (int)position.y + y, destinationImage.GetPixel(x, y));
                }
            }
        }
    }
}

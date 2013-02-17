using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace MCPixelArt
{
    class ImageLogic
    {
        public Image image;
        public List<int> lastWoolIndeces;

        public ImageLogic(Image newImage)
        {
            this.image = newImage;
        }

        public Image CreatePreview(int width, int height)
        {
            if (this.image == null) return null;
            Bitmap imageMap = new Bitmap(this.image, width, height);
            Bitmap woolImage = new Bitmap(width, height);
            WoolColors wool = new WoolColors();
            List<int> woolIndeces = new List<int>();

            for (int y = 0; y < imageMap.Height; y++)
            {
                for (int x = 0; x < imageMap.Width; x++)
                {
                    Color color = imageMap.GetPixel(x, y);
                    int index = wool.IndexOfClosestColor(color);
                    Color newColor = wool.woolArray[index];
                    woolIndeces.Add(index);
                    woolImage.SetPixel(x, y, newColor);
                }
            }
            woolIndeces.Reverse();
            this.lastWoolIndeces = woolIndeces;

            return (Image)woolImage;
        }
    }
}

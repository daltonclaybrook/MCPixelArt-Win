using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MCPixelArt
{
    class WoolColors
    {
        public List<Color> woolArray = new List<Color>();

        public WoolColors()
        {
            this.woolArray.Add(Color.FromArgb(221, 221, 221));  //White         0
            this.woolArray.Add(Color.FromArgb(219, 125, 62));   //Orange        1
            this.woolArray.Add(Color.FromArgb(179, 80, 188));   //Magenta       2
            this.woolArray.Add(Color.FromArgb(107, 138, 201));  //Light Blue    3
            this.woolArray.Add(Color.FromArgb(177, 166, 39));   //Yellow        4
            this.woolArray.Add(Color.FromArgb(65, 174, 56));    //Lime          5
            this.woolArray.Add(Color.FromArgb(208, 132, 153));  //Pink          6
            this.woolArray.Add(Color.FromArgb(64, 64, 64));     //Gray          7
            this.woolArray.Add(Color.FromArgb(154, 161, 161));  //Light Gray    8
            this.woolArray.Add(Color.FromArgb(46, 110, 137));   //Cyan          9
            this.woolArray.Add(Color.FromArgb(126, 61, 181));   //Purple        10
            this.woolArray.Add(Color.FromArgb(46, 56, 141));    //Blue          11
            this.woolArray.Add(Color.FromArgb(79, 50, 31));     //Brown         12
            this.woolArray.Add(Color.FromArgb(53, 70, 27));     //Green         13
            this.woolArray.Add(Color.FromArgb(150, 52, 48));    //Red           14
            this.woolArray.Add(Color.FromArgb(25, 22, 22));     //Black         15
        }

        public int IndexOfClosestColor(Color color)
        {
            if (color.A < 255) return 0;
            float smallAverage = 1000.0F;    //A High Float
            int closestIndex = 0; 
            for (int i = 0; i < woolArray.Count; i++)
            {
                int redDif = Math.Abs(color.R - woolArray[i].R);
                int greenDif = Math.Abs(color.G - woolArray[i].G);
                int blueDif = Math.Abs(color.B - woolArray[i].B);
                float average = (redDif + greenDif + blueDif) / 3.0F;
                if (average < smallAverage)
                {
                    closestIndex = i;
                    smallAverage = average;
                }
            }

            return closestIndex;
        }
    }
}

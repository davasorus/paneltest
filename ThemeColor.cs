using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paneltest
{
    public static class ThemeColor
    {
        public static Color PrimaryColor {  get; set; }
        public static Color SecondaryColor {  get; set; }


       public static List<string> colorList = new List<string>()
        {
            "#89bbcd",
            "#8eced9",
            "#3e5490",
            "#5aabc4",
            "#434e6d",
            "#3a91b8",
            "#7090cc",
            "#a6b289",
            "#a9b2ce",
            "#8d98bd",
            "#8e9b4a",
            "#7481af",
            "#bcc28c",
            "#6b7ca4"
        };

        public static Color ChangeColorBrightness(Color color, double correctionFaction)
        {
            double red = color.R;
            double green = color.G;
            double blue = color.B;

            //if correction factor is less than 0, darken color
            if(correctionFaction < 0)
            {
                correctionFaction = 1 + correctionFaction; 
                red *= correctionFaction;
                green *= correctionFaction;
                blue *= correctionFaction;
            }
            //if correction factor is greater than 0, lighten color
            else
            {
                red = (255 - red) * correctionFaction + red;
                green = (255 - green) * correctionFaction + green;
                blue = (255 - blue) * correctionFaction + blue;
            }

            return Color.FromArgb(color.A, (byte)red, (byte)green, (byte)blue);
        }
    }
}

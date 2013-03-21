using System;
using System.Linq;
using Microsoft.Xna.Framework;

namespace Space_Defender.Library
{
    public class DisplaySetting
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        public bool FullScreen { get; private set; }
        public Rectangle ViewPort { get; private set; }

        public DisplaySetting(int width, int height, bool fullScreen)
        {
            Width = width;
            Height = height;
            FullScreen = fullScreen;
            ViewPort = new Rectangle(0,0,Width,Height);
        }
    }
}

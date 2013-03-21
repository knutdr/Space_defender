using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Space_Defender.Library
{
    public class Background : Sprite
    {
        public Background(Texture2D texture) : base(texture)
        {
        }

        public override SpriteType SpriteType
        {
            get
            {
                return SpriteType.Background;
            }
        }
    }
}

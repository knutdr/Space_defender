using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Space_Defender.Library
{
    [Flags]
    public enum SpriteType
    {
        Generic = 1 << 0,
        Background = 1 << 1,
        Player = 1 << 2,
        Alien = 1 << 3,
        Weapon = 1 << 4,
        Bullet = 1 << 5
    }
}

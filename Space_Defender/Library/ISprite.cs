using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Space_Defender.Library
{
    public interface ISprite : IInteractive
    {
        int Width { get; }
        int Height { get; }
        float X { get; }
        float Y { get;  }
        bool doesCollideWith(ISprite otherSprite);
        void handleCollisionWith(ISprite otherSprite);
        Rectangle GetBoundingBox();
        SpriteType SpriteType { get; }
    }
}

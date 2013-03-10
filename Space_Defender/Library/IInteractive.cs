using System;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;

namespace Space_Defender.Library
{
    public interface IInteractive
    {
        void Update(float elapsedTime);
        void Draw(SpriteBatch spriteBatch);
    }
}

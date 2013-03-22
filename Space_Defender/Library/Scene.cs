using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Space_Defender.Library
{
    public class Scene : IInteractive
    {
        public virtual void Update(float elapsedTime)
        {
        }

        public virtual void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
        }
    }
}

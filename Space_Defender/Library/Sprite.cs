using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Space_Defender.Library
{
    public class Sprite
    {
        public Texture2D Texture { get; private set; }
        public Vector2 Position;
        public Vector2 Vector;

        public int Width { get; private set; }
        public int Height { get; private set; }

        public Sprite(Texture2D texture)
        {
            Texture = texture;
            Width = Texture.Width;
            Height = Texture.Height;
        }
        public virtual void Update(float elapsedTime)
        {
            Position += (Vector*elapsedTime);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture,Position,Color.White);
        }
    }
}

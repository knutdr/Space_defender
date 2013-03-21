using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Space_Defender.Library
{
    public class Sprite : ISprite
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

        public Sprite(Texture2D texture, Vector2 position, Vector2 vector) : this(texture)
        {
            Position = position;
            Vector = vector;
        }

        // Todo: Possible optimization here by creating floating point rectangle struct?
        public virtual Rectangle GetBoundingBox()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, Width, Height);
        }

        public virtual void Update(float elapsedTime)
        {
            Position += (Vector * elapsedTime);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }

        public virtual bool doesCollideWith(ISprite otherSprite)
        {
            // no collision with self.
            if (Equals(otherSprite))
                return false;

            return GetBoundingBox().Intersects(otherSprite.GetBoundingBox());
        }

        public virtual void handleCollisionWith(ISprite otherSprite)
        {
            throw new NotImplementedException();
        }


        public float X
        {
            get { return Position.X; }
        }

        public float Y
        {
            get { return Position.Y; }
        }


        public virtual SpriteType SpriteType
        {
            get { return SpriteType.Generic; }
        }
    }
}

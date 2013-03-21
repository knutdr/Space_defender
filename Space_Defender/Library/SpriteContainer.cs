using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;

namespace Space_Defender.Library
{
    public static class SpriteContainer
    {
        private static readonly Dictionary<SpriteType, List<ISprite>> _sprites = new Dictionary<SpriteType, List<ISprite>>();
        
        static SpriteContainer ()
        {
            initialize();
        }
        
        public static void Add(ISprite sprite)
        {
            _sprites[sprite.SpriteType].Add(sprite);
        }

        public static void Remove(ISprite sprite)
        {
            _sprites[sprite.SpriteType].Remove(sprite);
        }

        private static void initialize()
        {
            var spriteTypes = (SpriteType[]) Enum.GetValues(typeof (SpriteType));
            foreach (var spriteType in spriteTypes)
                _sprites[spriteType] = new List<ISprite>();
        }

        public static void Draw(SpriteType spriteType, SpriteBatch spriteBatch)
        {
            var count = _sprites[spriteType].Count;
            for(int i = 0; i < count; i++)
                _sprites[spriteType][i].Draw(spriteBatch);
        }

        public static void Update(SpriteType spriteType, float elapsedTime)
        {
            var count = _sprites[spriteType].Count;
            for(int i = count - 1; i >= 0; i--)
                _sprites[spriteType][i].Update(elapsedTime);
        }

        public static void CheckCollisionsBetween(SpriteType spriteType, SpriteType otherSpriteType)
        {
            var sprites = _sprites[spriteType];
            var otherSprites = _sprites[otherSpriteType];
            for (var i = sprites.Count - 1; i >= 0; i--)
            {
                for (var j = otherSprites.Count - 1; j >= 0; j--)
                {
                    if(sprites[i].doesCollideWith(otherSprites[j]))
                        sprites[i].handleCollisionWith(otherSprites[j]);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;

namespace Space_Defender.Library
{
    public static class SpriteContainer
    {
        private static readonly Dictionary<SpriteType, List<ISprite>> _sprites = new Dictionary<SpriteType, List<ISprite>>();
        private static readonly SpriteType[] spriteTypes = (SpriteType[]) Enum.GetValues(typeof (SpriteType));
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
            foreach (var spriteType in spriteTypes)
                _sprites[spriteType] = new List<ISprite>();
        }

        public static void Draw(SpriteType bitmaskedSpriteType, SpriteBatch spriteBatch)
        {
            var relevantSpriteTypes = findSpriteTypesFromBitmask(bitmaskedSpriteType);
            for (int i = 0; i < relevantSpriteTypes.Count; i++)
            {
                var spriteType = relevantSpriteTypes[i];
                var count = _sprites[spriteType].Count;
                for (int j = 0; j < count; j++)
                    _sprites[spriteType][j].Draw(spriteBatch);    
            }
            
        }

        public static void Update(SpriteType bitmaskedSpriteType, float elapsedTime)
        {
            var relevantSpriteTypes = findSpriteTypesFromBitmask(bitmaskedSpriteType);
            for (int i = 0; i < relevantSpriteTypes.Count; i++)
            {
                var spriteType = relevantSpriteTypes[i];
                var count = _sprites[spriteType].Count;
                for (int j = count - 1; j >= 0; j--)
                    _sprites[spriteType][j].Update(elapsedTime);
            }
        }

        private static List<SpriteType> findSpriteTypesFromBitmask(SpriteType bitmaskedSpriteType)
        {
            var resultList = new List<SpriteType>();
            for (int i = 0; i < spriteTypes.Length; i++)
            {
                var spriteType = spriteTypes[i];
                if ((bitmaskedSpriteType & spriteType) == spriteType)
                    resultList.Add(spriteType);
            }
            return resultList;
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

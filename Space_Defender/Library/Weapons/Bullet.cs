using System;
using System.Linq;
using Microsoft.Xna.Framework;

namespace Space_Defender.Library.Weapons
{
    public abstract class Bullet : Sprite
    {
        protected Bullet(Weapon weapon, Vector2 position, Vector2 vector) : base(weapon.Texture, position, vector)
        {
            Weapon = weapon;
        }

        public Weapon Weapon { get; private set; }
        public abstract bool IsStillValid();
        
        public override SpriteType SpriteType
        {
            get { return SpriteType.Bullet; }
        }

        public override void Update(float elapsedTime)
        {
            base.Update(elapsedTime);
            if (!IsStillValid())
                SpriteContainer.Remove(this);
        }

        public override void handleCollisionWith(ISprite otherSprite)
        {
            Weapon.notifyHit(this, otherSprite);
        }
    }
}

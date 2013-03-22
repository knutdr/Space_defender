using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;

namespace Space_Defender.Library.Weapons
{
    public abstract class Weapon : Sprite
    {
        public double Damage { get; set; }
        public float FireIntervalInMilliseconds { get; set; }
        public float MillisecondsElapsedSinceLastFire { get; protected set; }

        public ISprite Owner { get; set; }
        protected Weapon(Texture2D texture) : base(texture)
        {
            MillisecondsElapsedSinceLastFire = float.MaxValue;
        }
        
        protected abstract Bullet createBulletWhenFiring(ISprite sprite);
        
        public virtual void FireIfPossible(ISprite sprite)
        {
            if (!CanFire(sprite))
                return;

            MillisecondsElapsedSinceLastFire = 0f;
            var bullet = createBulletWhenFiring(sprite);
            if(bullet != null)
                SpriteContainer.Add(bullet);
        }

        public virtual bool CanFire(ISprite sprite)
        {
            return MillisecondsElapsedSinceLastFire > FireIntervalInMilliseconds;
        }

        public override void Update(float elapsedTime)
        {
            MillisecondsElapsedSinceLastFire += elapsedTime;
            base.Update(elapsedTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
        }

        public override SpriteType SpriteType
        {
            get { return SpriteType.Weapon; }
        }

        public void CheckHit(Bullet bullet, ISprite sprite)
        {
            if (sprite.Equals(Owner))
                return;

            if (!(sprite is Living))
                return;

            var livingSprite = sprite as Living;
            HandleHit(bullet, livingSprite);
        }

        public virtual void HandleHit(Bullet bullet, Living sprite)
        {
            sprite.ApplyDamage(Damage);
            SpriteContainer.Remove(bullet);
            if (!sprite.IsAlive())
                SpriteContainer.Remove(sprite);
            afterSuccessfulHit(bullet, sprite);
        }

        protected abstract void afterSuccessfulHit(Bullet bullet, Living sprite);
    }
}

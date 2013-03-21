using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Space_Defender.Library.Weapons
{
    public class Laser : Weapon
    {
        public Laser(Texture2D texture) : base(texture)
        {
            Damage = 20.0;
            FireIntervalInMilliseconds = 200f;
        }

        protected override Bullet createBulletWhenFiring(ISprite sprite)
        {
            var initialBulletPosition = new Vector2(sprite.X + (sprite.Width*0.5f) - (Texture.Width * 0.5f), sprite.Y - Texture.Height);
            var bulletVector = new Vector2(0f, -0.8f);
            return new LaserBullet(this, initialBulletPosition, bulletVector);
        }

        public override void notifyHit(Bullet bullet, ISprite sprite)
        {
            if (!(sprite is Living))
                return;

            var livingSprite = sprite as Living;
            livingSprite.ApplyDamage(Damage);
            SpriteContainer.Remove(bullet);
            if (!livingSprite.IsAlive())
                SpriteContainer.Remove(sprite);
        }
    }

    public class LaserBullet : Bullet
    {
        public LaserBullet(Weapon weapon, Vector2 position, Vector2 vector) : base(weapon, position, vector){}

        public override bool IsStillValid()
        {
            return GameBase.DisplaySetting.ViewPort.Contains(GetBoundingBox());
        }
    }
}

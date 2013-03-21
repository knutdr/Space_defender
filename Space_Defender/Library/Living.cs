using Microsoft.Xna.Framework.Graphics;
using Space_Defender.Library.Weapons;

namespace Space_Defender.Library
{
    public class Living : Sprite
    {
        public Health Health { get; private set; }
        public WeaponSet WeaponSet { get; private set; }
        public Weapon Weapon { get { return WeaponSet.Weapon; } }

        public Living(Texture2D texture, WeaponSet weaponSet, Health health) : this(texture, weaponSet)
        {
            Health = health;
        }

        public Living(Texture2D texture, WeaponSet weaponSet) : base(texture)
        {
            Health = Health.Default100;
            WeaponSet = weaponSet;
        }

        public void ApplyDamage(double amount)
        {
            Health.ApplyDamage(amount);
        }

        public void ApplyHealing(double amount)
        {
            Health.ApplyHealing(amount);
        }

        public virtual bool IsAlive()
        {
            return Health.Current > 0;
        }

        public void AddWeapon(Weapon weapon)
        {
            WeaponSet.AddWeapon(weapon);
        }

        public void RemoveWeapon(Weapon weapon)
        {
            WeaponSet.RemoveWeapon(weapon);
        }

        public void ChooseNextWeapon()
        {
            WeaponSet.ChooseNextWeapon();
        }

        public void ChoosePreviousWeapon()
        {
            WeaponSet.ChoosePreviousWeapon();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Space_Defender.Library.Weapons;

namespace Space_Defender.Library
{
    public class WeaponSet
    {
        private readonly List<Weapon> weapons = new List<Weapon>();
        public Weapon Weapon { get { return weapons[currentWeaponIndex]; } }
        private int currentWeaponIndex;
        public ISprite Owner { get; set; }

        public WeaponSet(Weapon defaultWeapon)
        {
            AddWeapon(defaultWeapon);
        }

        public void AddWeapon(Weapon weapon)
        {
            weapons.Add(weapon);
            SpriteContainer.Add(weapon);
        }

        public void RemoveWeapon(Weapon weapon)
        {
            if (weapons.Count <= 1)
                return;

            if (Weapon == weapon)
            {
                currentWeaponIndex = 0;
                updateWeaponOwner();
            }
            weapons.Remove(weapon);
            SpriteContainer.Remove(weapon);
        }

        public void ChooseNextWeapon()
        {
            currentWeaponIndex++;
            if (currentWeaponIndex >= weapons.Count - 1)
                currentWeaponIndex = 0;
            updateWeaponOwner();
        }

        public void ChoosePreviousWeapon()
        {
            if (currentWeaponIndex == 0)
                currentWeaponIndex = weapons.Count - 1;
            else currentWeaponIndex--;
            updateWeaponOwner();
        }

        private void updateWeaponOwner()
        {
            Weapon.Owner = Owner;
        }
    }
}

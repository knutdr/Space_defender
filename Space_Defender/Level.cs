using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Space_Defender.Library;

namespace Space_Defender
{
    public class Level : IInteractive
    {
        public string Name { get; private set; }

        private readonly List<Alien> aliens;
        private readonly Texture2D alienTexture;

        public Level(int numberOfAliens, Texture2D alienTexture)
        {
            this.alienTexture = alienTexture;
            aliens = new List<Alien>(numberOfAliens);
            addAliens(numberOfAliens);
        }

        private void addAliens(int numberOfAliens)
        {
            var xinterval = SpaceDefender.DisplaySetting.Width/numberOfAliens;
            for(int i  = 0 ; i < numberOfAliens; i++)
                aliens.Add( new Alien(alienTexture)
                { Position = new Vector2(i * xinterval, 40) });
        }
       
        public void Update(float elapsedTime)
        {
            foreach (var sprite in aliens)
            {
                sprite.Update(elapsedTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var sprite in aliens)
            {
                sprite.Draw(spriteBatch);
            }
        }

    }
}

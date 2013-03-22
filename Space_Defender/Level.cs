using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Space_Defender.Library;

namespace Space_Defender
{
    public class Level : Scene
    {
        public string Name { get; private set; }

        private readonly Texture2D alienTexture;

        public Level(int numberOfAliens, Texture2D alienTexture)
        {
            this.alienTexture = alienTexture;
            SpriteContainer.Add(new Background(GameBase.Textures["Background1"]));
            SpriteContainer.Add(new Library.Player(GameBase.Textures["Player"],Players.Player1));
            addAliens(numberOfAliens);
        }

        private void addAliens(int numberOfAliens)
        {
            var xinterval = GameBase.DisplaySetting.Width / numberOfAliens;
            for (int i = 0; i < numberOfAliens; i++)
                SpriteContainer.Add(new Alien(alienTexture, 10) { Position = new Vector2(i * xinterval, 40) });
        }

        public override void Update(float elapsedTime)
        {
            SpriteContainer.Update(SpriteType.Player | SpriteType.Alien | SpriteType.Weapon | SpriteType.Bullet, elapsedTime);
            SpriteContainer.CheckCollisionsBetween(SpriteType.Bullet, SpriteType.Alien);

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied);

            SpriteContainer.Draw(SpriteType.Background | SpriteType.Player | SpriteType.Alien | SpriteType.Bullet, spriteBatch);
            //SpriteContainer.Draw(SpriteType.Background, spriteBatch);
            //SpriteContainer.Draw(SpriteType.Player, spriteBatch);
            //SpriteContainer.Draw(SpriteType.Alien, spriteBatch);
            //SpriteContainer.Draw(SpriteType.Bullet, spriteBatch);

            spriteBatch.End();
        }

    }
}

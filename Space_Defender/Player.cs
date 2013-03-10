using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Space_Defender.Library;

namespace Space_Defender
{
	public class Player : Sprite
	{

		private List<Sprite> bulletList = new List<Sprite>();
		private float shotTimer = 300;
		private float shotCounter = 0;

		public Player(Texture2D texture) : base(texture)
		{
			this.Vector = new Vector2(0f, 0f);
			this.Position = new Vector2(SpaceDefender.DisplaySetting.Width / 2, SpaceDefender.DisplaySetting.Height - 150);
		}

		public override void Update(float gameTimer)
		{
			if (shotCounter > shotTimer)
				shotCounter = 0;
			if (shotCounter > 0)
				shotCounter += gameTimer;
			bool canShoot = shotCounter == 0;
			
			Vector2 movement;
			if (Keyboard.GetState().IsKeyDown(Keys.Left))
				movement = new Vector2(-1, 0);
			else if (Keyboard.GetState().IsKeyDown(Keys.Right))
				movement = new Vector2(1, 0);
			else
				movement = new Vector2(0, 0);
			this.Vector = movement;

			if (Keyboard.GetState().IsKeyDown(Keys.Space) && canShoot)
			{
				shotCounter += gameTimer;
				Sprite shotSprite = new Sprite(GameBase.Textures["bullet0"]);
				shotSprite.Position = this.Position;
				shotSprite.Position.X += this.Texture.Width / 2.5f;
				shotSprite.Vector = new Vector2(0, -2);
				bulletList.Add(shotSprite);
			}

			for (int i = bulletList.Count - 1; i >= 0; i--)
			{
				Sprite bullet = bulletList[i];
				bullet.Update(gameTimer);
				if (bullet.Position.Y < 0)
					bulletList.Remove(bullet);
			}
			base.Update(gameTimer);
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			foreach (Sprite bullet in bulletList)
				bullet.Draw(spriteBatch);
			base.Draw(spriteBatch);
		}
	}
}

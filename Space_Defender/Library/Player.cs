using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Space_Defender.Library.Weapons;

namespace Space_Defender.Library
{
    public enum Players
    {
        Player1,
        Player2
    }

    public enum PlayerMovement
    {
        Still,
        Left,
        Right
    }

    public class Player : Living
    {
        private PlayerMovement playerMovement;
        private const float speed = 0.8f;

        public Players PlayerIndex { get; private set; }

        public Player(Texture2D texture, Players playerIndex)
            : base(texture, new WeaponSet(new Laser(GameBase.Textures["Laser"])))
        {
            Position = new Vector2(GameBase.DisplaySetting.Width * 0.5f - (Width * 0.5f), GameBase.DisplaySetting.Height - Height);
            Vector = Vector2.Zero;
            PlayerIndex = playerIndex;
        }

        public override SpriteType SpriteType
        {
            get { return SpriteType.Player; }
        }

        public override void Update(float elapsedTime)
        {
            if(Keyboard.GetState().IsKeyDown(Keys.Space))
                Weapon.FireIfPossible(this);

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                if(playerMovement != PlayerMovement.Left)
                left();
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                if(playerMovement != PlayerMovement.Right)
                right();   
            }
            else
            {
                still();   
            }
            base.Update(elapsedTime);

            ensurePositionIsWithinViewport();
        }

        private void ensurePositionIsWithinViewport()
        {
            if (Position.X < 0) Position.X = 0;
            if ((Position.X + Width) >= GameBase.DisplaySetting.Width)
                Position.X = GameBase.DisplaySetting.Width - Width;
        }

        private void left()
        {
            Vector = new Vector2(-speed, 0f);
            playerMovement = PlayerMovement.Left;
        }

        private void right()
        {
            Vector = new Vector2(speed, 0f);
            playerMovement = PlayerMovement.Right;
        }

        private void still()
        {
            Vector = Vector2.Zero;
            playerMovement = PlayerMovement.Still;
        }
    }
}

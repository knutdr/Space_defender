using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Space_Defender.Library;
using Space_Defender.Library.Weapons;

namespace Space_Defender
{
    public enum AlienMovement
    {
        MoveRight,
        MoveDown,
        MoveLeft
    }

    public class Alien : Living
    {
        private float yPositionWhenStartedMovingDownwards;
        private AlienMovement currentMovementStatus;
        private AlienMovement previousMovementStatus;
        
        public Alien(Texture2D texture, double scoreValue) : base(texture, new WeaponSet(new Laser(GameBase.Textures["Laser"])))
        {
            setVector();
            ScoreValue = scoreValue;
        }

        public override SpriteType SpriteType
        {
            get { return SpriteType.Alien; }
        }

        public override void Update(float elapsedTime)
        {
            base.Update(elapsedTime);

            if (currentMovementStatus == AlienMovement.MoveRight)
            {
                if (Position.X + Width >= SpaceDefender.DisplaySetting.Width)
                {
                    Position.X = SpaceDefender.DisplaySetting.Width - Width;
                    yPositionWhenStartedMovingDownwards = Position.Y;
                    currentMovementStatus = AlienMovement.MoveDown;
                    previousMovementStatus = AlienMovement.MoveRight;
                    setVector();
                }
            }
            else if (currentMovementStatus == AlienMovement.MoveDown)
            {
                if (Position.Y > (yPositionWhenStartedMovingDownwards + Height))
                {
                    Position.Y = yPositionWhenStartedMovingDownwards + Height;
                    currentMovementStatus = previousMovementStatus == AlienMovement.MoveLeft ? AlienMovement.MoveRight : AlienMovement.MoveLeft;
                    setVector();
                }
                   
            }
            else if (currentMovementStatus == AlienMovement.MoveLeft)
            {
                if (Position.X < 0)
                {
                    Position.X = 0;
                    yPositionWhenStartedMovingDownwards = Position.Y;
                    currentMovementStatus = AlienMovement.MoveDown;
                    previousMovementStatus = AlienMovement.MoveLeft;
                    setVector();
                }
            }

            
        }

        private void setVector()
        {
            if(currentMovementStatus == AlienMovement.MoveRight)
                Vector = new Vector2(0.25f, 0);
            else if(currentMovementStatus == AlienMovement.MoveLeft)
                Vector = new Vector2(-0.25f, 0);
            else if(currentMovementStatus == AlienMovement.MoveDown)
                Vector = new Vector2(0, 0.25f);
        }
    }
}

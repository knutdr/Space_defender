using Microsoft.Xna.Framework;

namespace Space_Defender.Library.Particles
{
    public class Particle
    {
        public Vector2 Position;
        public Vector2 Vector;
        public float TotalTimeAlive;
        public float TimeAliveLeft;

        public float Alpha()
        {
            return TimeAliveLeft/TotalTimeAlive;
        }
    }
}

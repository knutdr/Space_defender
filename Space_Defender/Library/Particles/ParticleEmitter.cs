using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Space_Defender.Library.Particles
{
    public class ParticleEmitter : IInteractive
    {
        public readonly Vector2 Position;
        public readonly Vector2 Vector;
        private readonly SpriteBatch spriteBatch;
        private readonly Texture2D particleTexture;

        private const int MAX_PARTICLES = 10000;
        private Random randomizer = new Random();
        private List<Particle> particles = new List<Particle>(); 
        public ParticleEmitter(SpriteBatch spriteBatch, Texture2D particleTexture, Vector2 position, Vector2 vector)
        {
            Position = position;
            Vector = vector;
            this.spriteBatch = spriteBatch;
            this.particleTexture = particleTexture;
        }

        public void Update(float elapsedTime)
        {
            if (particles.Count < MAX_PARTICLES)
                particles.Add(new Particle {TotalTimeAlive = 2000, TimeAliveLeft = 500 + randomizer.Next(1500), Position = Position, Vector = createNewParticleVector()});

            for (int i = particles.Count - 1; i >= 0; i--)
                updateParticle(i, elapsedTime);


        }

        protected virtual Vector2 createNewParticleVector()
        {
            return new Vector2(-0.1f + (float)randomizer.NextDouble() * 0.2f, -(float)randomizer.NextDouble() * 0.2f);
        }

        public void Draw(SpriteBatch sb)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Additive);
            for (int i = 0; i < particles.Count; i++)
                spriteBatch.Draw(particleTexture, particles[i].Position, new Color(randomizer.Next(255),randomizer.Next(255),randomizer.Next(255)) * particles[i].Alpha());//*particles[i].Alpha);
            spriteBatch.End();
        }

        private void updateParticle(int particleIndex, float elapsedTime)
        {
            var particle = particles[particleIndex];
            particle.Position += particle.Vector*elapsedTime;
            particle.TimeAliveLeft -= elapsedTime;
            if (particle.Alpha() <= 0)
                particles.RemoveAt(particleIndex);
        }
    }
}

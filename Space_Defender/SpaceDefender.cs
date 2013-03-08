﻿#region Using Statements
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using Space_Defender.Library;
using Space_Defender.Repositories;
using Space_Defender.Utility;

#endregion

namespace Space_Defender
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class SpaceDefender : GameBase
    {
        public const double PreferrableFps = 60.0;
        public const double UpdateInterval = 1000.0/PreferrableFps;
        private static readonly DisplaySetting displaySetting = new DisplaySetting(1280, 720, false);

        private Sprite testSprite;

        
        SpriteBatch spriteBatch;
        private Texture2D testTexture;
        Vector2 textureVector = new Vector2(0,0);

        public SpaceDefender()
            : base(displaySetting)
        {}

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            base.LoadContent();

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            testSprite = new Sprite(Textures["test"]);
            testSprite.Vector = new Vector2(0.01f, 0f);
            testSprite.Position = new Vector2(0f,0f);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            Content.Dispose();
            
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            Fps.Update(gameTime.ElapsedGameTime.TotalMilliseconds);

            testSprite.Update( (float)gameTime.ElapsedGameTime.TotalMilliseconds);
            
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                    Keyboard.GetState().IsKeyDown(Keys.Escape))
                    Exit();

                // TODO: Add your update logic here

                base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Beige);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            testSprite.Draw(spriteBatch);
            //spriteBatch.Draw(testTexture, new Vector2(0,0), new Rectangle(0, 0, 1500, 1500), Color.White,0f,textureVector,new Vector2(1,1),SpriteEffects.None, 1f);
            spriteBatch.End();
            base.Draw(gameTime);
        }

      
    }
}

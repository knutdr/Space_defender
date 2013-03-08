using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Space_Defender.Repositories;
using Space_Defender.Utility;

namespace Space_Defender.Library
{
    public abstract class GameBase : Game, IFpsHandler
    {
        public DisplaySetting DisplayMode { get; private set; }
        public static TextureRepository Textures { get; private set; }
        protected GraphicsDeviceManager Graphics { get; private set; }


        protected GameBase(DisplaySetting displayMode)
        {
            DisplayMode = displayMode;
            Graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = DisplayMode.Width,
                PreferredBackBufferHeight = DisplayMode.Height,
                IsFullScreen = DisplayMode.FullScreen
            };
        }

        protected override void Initialize()
        {
            IsFixedTimeStep = false;
            Fps.AttachTo(this);
            Content.RootDirectory = "Content";
            Textures = new TextureRepository();
            base.Initialize();
        }

        public bool Vsync
        {
            get { return Graphics.SynchronizeWithVerticalRetrace; }
            set { Graphics.SynchronizeWithVerticalRetrace = value; }
        }

        protected override void Update(GameTime gameTime)
        {
            Fps.Update(gameTime.ElapsedGameTime.TotalMilliseconds);
            base.Update(gameTime);
        }

        protected override void LoadContent()
        {
            Textures.Load(Content);
            base.LoadContent();
        }
        public virtual void FpsChanged(int fps)
        {
            Window.Title = "Fps: " + fps;
        }
    }
}

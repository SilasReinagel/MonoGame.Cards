using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoDragons.Core.Graphics;
using MonoDragons.Core.Inputs;
using MonoDragons.Core.Memory;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.Render;
using MonoDragons.Core.UserInterface;
using System;
using Microsoft.Xna.Framework.Input;
using MonoDragons.Core.Entities;
using MonoDragons.Core.Navigation;

namespace MonoDragons.Core.Engine
{
    public class NeedlesslyComplexMainGame : Game, INavigation
    {
        private readonly string _startingViewName;
        private readonly GraphicsDeviceManager _graphics;
        private readonly SceneFactory _sceneFactory;
        private readonly IController _controller;
        private readonly Metrics _metrics;
        private readonly EntitySystem _ecs;
        private readonly bool _areScreenSettingsPreCalculated;

        private IScene _currentScene;

        private SpriteBatch _sprites;
        private Display _display;
        private Size2 _defaultScreenSize;
        private Texture2D _black;


        // @todo #1 fix this so we config everything before the game
        public NeedlesslyComplexMainGame(string title, string startingViewName, Size2 defaultGameSize, SceneFactory sceneFactory, IController controller)
            : this(title, startingViewName, sceneFactory, controller)
        {
            _areScreenSettingsPreCalculated = false;
            _defaultScreenSize = defaultGameSize;
        }

        public NeedlesslyComplexMainGame(string title, string startingViewName, Display screenSettings, SceneFactory sceneFactory, IController controller)
            : this(title, startingViewName, sceneFactory, controller)
        {
            _areScreenSettingsPreCalculated = true;
            _display = screenSettings;
        }

        private NeedlesslyComplexMainGame(string title, string startingViewName, SceneFactory sceneFactory, IController controller)
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            _startingViewName = startingViewName;
            _sceneFactory = sceneFactory;
            _controller = controller;
            _metrics = new Metrics();
            _ecs = Entity.System;
            Renderers.RegisterAll(_ecs);
            PhysicsSystems.RegisterAll(_ecs);
            Window.Title = title;
        }

        protected override void Initialize()
        {
            InitDisplayIfNeeded();
            // @todo #1 Bug: Update the GraphicsDeviceManager in the constructor, to avoid the window being mispositioned and visibly changing size
            _display.Apply(_graphics);
            Window.Position = new Point(0, 0); // Delete this once the above issue is fixed 
            IsMouseVisible = true;
            _sprites = new SpriteBatch(GraphicsDevice);
            Resources.Init(this);
            Hack.TheGame = this;
            Input.SetController(_controller);
            _ecs.Register(new ControlHandler());
            _ecs.Register(new DirectionHandler());
            _black = new RectangleTexture(new Rectangle(new Point(0, 0), new Point(1, 1)), Color.Black).Create();
            World.Init(this, this, _sprites, _display);
            UI.Init(this, _sprites, _display);
            base.Initialize();
        }

        private void InitDisplayIfNeeded()
        {
            if (!_areScreenSettingsPreCalculated)
            {
                var widthScale = (float)GraphicsDevice.DisplayMode.Width / _defaultScreenSize.Width;
                var heightScale = (float)GraphicsDevice.DisplayMode.Height / _defaultScreenSize.Height;
                var scale = widthScale > heightScale ? heightScale : widthScale;
                _display = new Display((int)Math.Round(_defaultScreenSize.Width * scale), (int)Math.Round(_defaultScreenSize.Height * scale),
                    true, scale);
            }
            CurrentDisplay.Init(_display);
        }

        protected override void LoadContent()
        {
            NavigateTo(_startingViewName);
        }

        protected override void UnloadContent()
        {
            Content.Unload();
        }

        protected override void Update(GameTime gameTime)
        {
            CheckForEscape();
            _metrics.Update(gameTime.ElapsedGameTime);
            _controller.Update(gameTime.ElapsedGameTime);
            _ecs.Update(gameTime.ElapsedGameTime);
            _currentScene?.Update(gameTime.ElapsedGameTime);
            new Physics().Resolve();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            _sprites.Begin(SpriteSortMode.Deferred, null, SamplerState.AnisotropicClamp);
            World.DrawBackgroundColor(Color.Black);
            _currentScene?.Draw();
            _ecs.Draw();
            _metrics.Draw(Transform2.Zero);
            HideExternals();
            _sprites.End();
            base.Draw(gameTime);
        }

        private void HideExternals()
        {
            _sprites.Draw(_black, new Rectangle(new Point(_display.GameWidth, 0),
                new Point(_display.ProgramWidth - _display.GameWidth, _display.ProgramHeight)), Color.Black);
            _sprites.Draw(_black, new Rectangle(new Point(0, _display.GameHeight),
                new Point(_display.ProgramWidth, _display.ProgramHeight - _display.GameHeight)), Color.Black);
        }

        public void NavigateTo(string sceneName)
        {
            var scene = _sceneFactory.Create(sceneName);
            scene.Init();
            _currentScene = scene;
        }

        // TODO: This is only for development. Remove this when re're ready to release to production!!
        private void CheckForEscape()
        {
#if DEBUG  
            var state = Keyboard.GetState();
            if(state.IsKeyDown(Keys.Escape))
                Hack.TheGame.Exit();
#endif
        }
    }
}

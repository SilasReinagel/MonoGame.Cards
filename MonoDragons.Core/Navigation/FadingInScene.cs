using System;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;

namespace MonoDragons.Core.Navigation
{
    public sealed class FadingInScene : IScene
    {
        private readonly TimeSpan _duration;
        private readonly Func<IScene> _sceneFactory;
        
        private double _transitionElapsedMillis;
        private bool _transitionComplete;

        private ColoredRectangle _fade = new ColoredRectangle { Transform = new Transform2(new Size2(1920, 1080)) };

        private IScene _scene;

        public FadingInScene(IScene scene)
            : this (TimeSpan.FromMilliseconds(2000), scene) { }

        public FadingInScene(TimeSpan duration, IScene scene)
            : this (duration, () => scene) { }

        public FadingInScene(TimeSpan duration, Func<IScene> sceneFactory)
        {
            _duration = duration;
            _sceneFactory = sceneFactory;
        }

        public void Init()
        {
            _scene = _sceneFactory.Invoke();
            _scene.Init();
        }

        public void Update(TimeSpan delta)
        {
            if (!_transitionComplete)
            {
                _transitionElapsedMillis += delta.TotalMilliseconds;
                _transitionComplete = _transitionElapsedMillis > _duration.TotalMilliseconds;
                _fade.Color = Color.FromNonPremultiplied(0, 0, 0, (int)(255 - 255 * (_transitionElapsedMillis / _duration.TotalMilliseconds)));
                return;
            }

            _scene.Update(delta);
        }

        public void Draw()
        {
            _scene.Draw();

            if (!_transitionComplete)
                _fade.Draw(Transform2.Zero);
        }
    }
}

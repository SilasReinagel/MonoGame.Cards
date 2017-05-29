using System;
using MonoDragons.Core.Engine;
using MonoDragons.Core.PhysicsEngine;

namespace MonoDragons.Core.Render
{
    public class Animation
    {
        private readonly string[] _spriteNames;
        private readonly int _msPerFrame;

        private int _currentFrame = 0;
        private double _msForCurrentFrame;

        public Animation(string sprite)
            : this(0, sprite) { }

        public Animation(int msPerFrame, params string[] spriteNames)
        {
            _msPerFrame = msPerFrame;
            _spriteNames = spriteNames;
        }

        public void Update(TimeSpan delta)
        {
            _msForCurrentFrame += delta.TotalMilliseconds;
            UpdateCurrentFrame();
        }

        public void Reset()
        {
            _msForCurrentFrame = 0;
            _currentFrame = 0;
        }

        private void UpdateCurrentFrame()
        {
            if (_msForCurrentFrame < _msPerFrame)
                return;

            if (_currentFrame + 1 == _spriteNames.Length)
                _currentFrame = 0;
            else
                _currentFrame += 1;

            _msForCurrentFrame = 0;
        }

        public string CurrentSprite => _spriteNames[_currentFrame];

        public void Draw(Transform2 transform)
        {
            // TODO: TileSize needs to be supplied externally
            World.Draw(CurrentSprite, transform.WithSize(new Size2(32, 32)));
        }
    }
}

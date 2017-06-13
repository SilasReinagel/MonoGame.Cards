using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using MonoDragons.Core.Common;
using MonoDragons.Core.Engine;
using MonoDragons.Core.Entities;

namespace MonoDragons.Core.MouseControls
{
    public sealed class MouseClicking : ISystem
    {
        private readonly List<GameObject> _targets;
        private readonly Timer _timer;

        private bool _leftWasPressed;

        public MouseClicking()
        {
            _targets = new List<GameObject>();
            _timer = new Timer(() => _targets.Clear(), 150);
        }

        public void Update(IEntities entities, TimeSpan delta)
        {
            // @todo #1 Add support for other Mouse Button Clicks
            var leftIsPressed = Mouse.GetState().LeftButton == ButtonState.Pressed;
            var pos = Mouse.GetState().Position;

            if (!_leftWasPressed && leftIsPressed)
            {
                entities.ForEach(e => e.With<ClickAction>(t => e.Transform.If(x => x.Intersects(pos), () => _targets.Add(e))));
                _timer.Reset();
            }
            if (_leftWasPressed && !leftIsPressed)
            {
                _targets.ForEach(e => e.With<ClickAction>(t => e.Transform.If(x => x.Intersects(pos), () => t.Action())));
                _targets.Clear();
            }

            _leftWasPressed = leftIsPressed;
            _timer.Update(delta);
        }
    }
}

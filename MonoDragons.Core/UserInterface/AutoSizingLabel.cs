using System;
using Microsoft.Xna.Framework.Graphics;
using MonoDragons.Core.Engine;
using MonoDragons.Core.Memory;
using MonoDragons.Core.PhysicsEngine;

namespace MonoDragons.Core.UserInterface
{
    public class AutoSizingLabel : IVisual
    {
        private readonly Label _label;

        public AutoSizingLabel(Label label)
        {
            _label = label;
        }

        public void Draw(Transform2 parentTransform)
        {
            var size = Resources.Load<SpriteFont>(_label.Font).MeasureString(_label.RawText);
            _label.Transform = new Transform2(_label.Transform.Location, new Size2((int)size.X, (int)size.Y));
            _label.Draw(parentTransform);
        }
    }
}

using System;
using Microsoft.Xna.Framework;

namespace MonoDragons.Core.UserInterface
{
    public sealed class SimpleClickable : ClickableUIElement
    {
        private readonly Action _onClick;

        public SimpleClickable(Rectangle area, Action onClick, float scale = 1) : base(area, true, scale)
        {
            _onClick = onClick;
        }

        public override void OnEntered()
        {
        }

        public override void OnExitted()
        {
        }

        public override void OnPressed()
        {
        }

        public override void OnReleased()
        {
            _onClick();
        }
    }
}

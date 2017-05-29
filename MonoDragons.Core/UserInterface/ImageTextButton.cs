using System;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using MonoDragons.Core.PhysicsEngine;

namespace MonoDragons.Core.UserInterface
{
    public class ImageTextButton : ClickableUIElement, IVisual
    {
        private readonly ImageButton _button;
        private readonly Label _label;
        private readonly Func<bool> _isVisible;

        public string Text { set { _label.Text = value; } }

        public ImageTextButton(string text, string basic, string hover, string press, Transform2 transform, Action onClick)
            : this(text, basic, hover, press, transform, onClick, () => true) { }

        public ImageTextButton(string text, string basic, string hover, string press, Transform2 transform, Action onClick, Func<bool> isVisible)
            : base(transform.ToRectangle())
        {
            _isVisible = isVisible;
            _button = new ImageButton(basic, hover, press, transform, onClick, _isVisible);
            _label = new Label { BackgroundColor = Color.Transparent, Text = text, Transform = transform.WithPadding(8, 8), TextColor = Color.White };
        }

        public override void OnEntered()
        {
            _button.OnEntered();
        }

        public override void OnExitted()
        {
            _button.OnExitted();
        }

        public override void OnPressed()
        {
            _button.OnPressed();
        }

        public override void OnReleased()
        {
            _button.OnReleased();
        }

        public void Draw(Transform2 parentTransform)
        {
            if (_isVisible())
            {
                _button.Draw(parentTransform);
                _label.Draw(parentTransform);
            }
        }
    }
}

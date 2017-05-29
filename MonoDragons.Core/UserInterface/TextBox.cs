using System;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.Text;

namespace MonoDragons.Core.UserInterface
{
    public sealed class TextBox : ClickableUIElement, IVisual, IDisposable
    {
        private readonly ColoredRectangle _bg;
        private readonly string _font;
        private readonly Color _textColor;

        public string Text { get; set; } = "";

        public TextBox() : this(new ColoredRectangle(), DefaultFont.Name, Color.White) {}
        public TextBox(ColoredRectangle bg) : this(bg, DefaultFont.Name, Color.White) {}
        public TextBox(ColoredRectangle bg, string font) : this(bg, font, Color.White) {}

        public TextBox(ColoredRectangle bg, string font, Color textColor) : base(bg.Transform.ToRectangle())
        {
            _bg = bg;
            _font = font;
            _textColor = textColor;
        }

        public override void OnEntered()
        {
            throw new NotImplementedException();
        }

        public override void OnExitted()
        {
            throw new NotImplementedException();
        }

        public override void OnPressed()
        {
            throw new NotImplementedException();
        }

        public override void OnReleased()
        {
            throw new NotImplementedException();
        }

        public void Draw(Transform2 parentTransform)
        {
            _bg.Draw(parentTransform);
        }

        public void Dispose()
        {
            _bg.Dispose();
        }
    }
}

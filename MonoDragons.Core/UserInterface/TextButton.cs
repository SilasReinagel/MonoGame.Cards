using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoDragons.Core.Engine;
using MonoDragons.Core.Graphics;
using MonoDragons.Core.PhysicsEngine;

namespace MonoDragons.Core.UserInterface
{
    public class TextButton : ClickableUIElement, IVisual
    {
        private readonly Action _onClick;
        private readonly string _text;
        private readonly Color _defaultColor;
        private readonly Color _hover;
        private readonly Color _press;
        private Color _currentColor;
        private readonly Texture2D _rect;
        private readonly Func<bool> _isVisible;


        public TextButton(Rectangle area, Action onClick, string text, Color defaultColor, Color hover, Color press)
            : this(area, onClick, text, defaultColor, hover, press, () => true) { }
        public TextButton(Rectangle area, Action onClick, string text, Color defaultColor, Color hover, Color press, Func<bool> isvisible) : base(area)
        {
            _onClick = onClick;
            _text = text;
            _defaultColor = defaultColor;
            _hover = hover;
            _press = press;
            _currentColor = _defaultColor;
            _rect = new RectangleTexture(Area.Width, Area.Height, _currentColor).Create();
            _isVisible = isvisible;
        }

        public override void OnEntered()
        {
            _currentColor = _hover;
        }

        public override void OnExitted()
        {
            _currentColor = _defaultColor;
        }

        public override void OnPressed()
        {
            _currentColor = _press;
        }

        public override void OnReleased()
        {
            _currentColor = _defaultColor;
            _onClick();
        }

        public void Draw(Transform2 parentTransform)
        {
            if (_isVisible())
            {
                World.Draw(_rect, parentTransform.Location + Area.Location.ToVector2());
                UI.DrawTextCentered(_text, new Rectangle(Area.Location + parentTransform.Location.ToPoint(), Area.Size), Color.White);
            }
        }
    }
}

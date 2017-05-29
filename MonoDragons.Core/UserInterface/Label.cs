using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using MonoDragons.Core.PhysicsEngine;
using System;
using Microsoft.Xna.Framework.Graphics;
using MonoDragons.Core.Memory;
using MonoDragons.Core.Text;

namespace MonoDragons.Core.UserInterface
{
    public sealed class Label : IVisual, IDisposable
    {
        private readonly ColoredRectangle _background = new ColoredRectangle();
        private readonly IWrapText _textWrapper;

        public string Font { get; set; } = DefaultFont.Name;
        public Color TextColor { get; set; } = Color.White;
        public HorizontalAlignment HorizontalAlignment { get; set; } = HorizontalAlignment.Center;

        public Transform2 Transform
        {
            get { return _background.Transform; }
            set { _background.Transform = value; }
        }
        public Color BackgroundColor
        {
            get { return _background.Color; }
            set { _background.Color = value; }
        }

        public string Text
        {
            get { return _textWrapper.Wrap(RawText); } //TODO: cache?
            set { RawText = value; }
        }

        public string RawText { get; set; } = "";

        public Label()
        {
            _textWrapper = new WrappingText(() => Resources.Load<SpriteFont>(Font), () => _background.Transform.Size.Width);
        }

        public void Draw(Transform2 parentTransform)
        {
            _background.Draw(parentTransform);
            UI.DrawTextAligned(Text, new Rectangle((parentTransform.Location + Transform.Location).ToPoint(), Transform.Size.ToPoint()), TextColor, Font, HorizontalAlignment);
        }

        public void Dispose()
        {
            _background.Dispose();
        }
    }
}

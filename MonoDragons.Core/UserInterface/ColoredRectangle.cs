using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoDragons.Core.Engine;
using MonoDragons.Core.Graphics;
using MonoDragons.Core.Memory;
using MonoDragons.Core.PhysicsEngine;
using System;

namespace MonoDragons.Core.UserInterface
{
    public sealed class ColoredRectangle : IVisual, IDisposable
    {
        private Texture2D _background;

        private Color color;
        public Color Color { get { return color; } set { color = value; GenerateTexture(); } }
        private Transform2 transform;
        public Transform2 Transform { get { return transform; } set { transform = value; GenerateTexture(); } }

        public ColoredRectangle()
        {
            color = Color.Orange;
            transform = new Transform2(new Size2(400, 100));
            _background = new RectangleTexture(transform.ToRectangle(), Color).Create();
        }

        public void Draw(Transform2 parentTransform)
        {
            var position = parentTransform + Transform;
            World.Draw(_background, position.ToRectangle());
        }

        private void GenerateTexture()
        {
            Resources.Dispose(_background);
            _background = new RectangleTexture(transform.ToRectangle(), Color).Create();
        }

        public void Dispose()
        {
            Resources.Dispose(_background);
        }
    }
}

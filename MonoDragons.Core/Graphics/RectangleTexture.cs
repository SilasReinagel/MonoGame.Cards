using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoDragons.Core.Engine;
using MonoDragons.Core.PhysicsEngine;

namespace MonoDragons.Core.Graphics
{
    public class RectangleTexture
    {
        private readonly int _width;
        private readonly int _height;
        private readonly Color _color;

        public RectangleTexture(Rectangle rect, Color color) : this (rect.Size.X, rect.Size.Y, color) { }
        public RectangleTexture(Size2 size, Color color) : this(size.Width, size.Height, color) { }

        public RectangleTexture(int width, int height, Color color)
        {
            _width = width;
            _height = height;
            _color = color;
        }

        public Texture2D Create()
        {
            var data = new Color[_width * _height];
            for (var i = 0; i < data.Length; ++i)
                data[i] = _color;

            var texture = new Texture2D(Hack.TheGame.GraphicsDevice, _width, _height);
            texture.SetData(data);
            return texture;
        }
    }
}

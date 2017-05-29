using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoDragons.Core.Engine;

namespace MonoDragons.Core.Graphics
{
    public class CircleTexture
    {
        private readonly int _diam;
        private readonly Color _color;

        public CircleTexture(int radius, Color color)
        {
            _diam = radius;
            _color = color;
        }

        public Texture2D Create()
        {
            var colorData = new Color[(_diam + 1) * (_diam + 1)];

            var radius = _diam / 2f;
            var radiusSq = radius * radius;

            for (var x = 0; x < _diam + 1; x++)
                for (var y = 0; y < _diam + 1; y++)
                {
                    var index = x * _diam + y;
                    var pos = new Vector2(x - radius, y - radius);
                    if (pos.LengthSquared() <= radiusSq)
                        colorData[index] = _color;
                    else
                        colorData[index] = Color.Transparent;
                }

            var texture = new Texture2D(Hack.TheGame.GraphicsDevice, _diam, _diam);
            texture.SetData(colorData);
            return texture;
        }
    }
}

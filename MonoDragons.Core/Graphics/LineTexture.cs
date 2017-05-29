using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoDragons.Core.Engine;

namespace MonoDragons.Core.Graphics
{
    public sealed class LineTexture
    {
        private readonly Color _color;

        public LineTexture(Color color)
        {
            _color = color;
        }

        public Texture2D Create()
        {
            var data = new[] { _color };
            var result = new Texture2D(Hack.TheGame.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            result.SetData(data, 0, result.Width * result.Height);
            return result;
        }
    }
}


using Microsoft.Xna.Framework;
using MonoDragons.Core.Common;

namespace MonoDragons.Core.Graphics
{
    public class RandomColor
    {
        public Color Next()
        {
            return new Color(Rng.Int(256), Rng.Int(256), Rng.Int(256));
        }
    }
}

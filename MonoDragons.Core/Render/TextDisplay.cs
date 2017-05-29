using System;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Text;

namespace MonoDragons.Core.Render
{
    public class TextDisplay
    {
        public string Font { get; set; } = DefaultFont.Name;
        public Color Color { get; set; } = Color.White;
        public Func<string> Text { get; set; } = () => "";
    }
}

using System;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace MonoDragons.Core.Text
{
    public class WrappingText : IWrapText
    {
        private readonly Func<SpriteFont> _font;
        private readonly Func<int> _maxWidth;

        public WrappingText(Func<SpriteFont> font, Func<int> maxWidth)
        {
            _font = font;
            _maxWidth = maxWidth;
        }

        public string Wrap(string text)
        {
            var font = _font();
            var maxWidth = _maxWidth();
            var result = Wrapped(text, font, maxWidth);
            return result;
        }

        private string Wrapped(string text, SpriteFont font, int maxWidth)
        {
            var sb = new StringBuilder();
            var lineWidth = 0f;
            var words = text.Split().Where(x => !x.Equals(""));
            foreach (var word in words)
            {
                var wordAndSpace = word + " ";
                var wordAndSpaceWidth = font.MeasureString(wordAndSpace).X;

                if (lineWidth + wordAndSpaceWidth <= maxWidth) //TODO: is this off by one?
                {
                    sb.Append(wordAndSpace);
                    lineWidth += wordAndSpaceWidth;
                }
                else
                {
                    sb.AppendLine();
                    sb.Append(wordAndSpace);
                    lineWidth = wordAndSpaceWidth;
                }
            }
            var result = sb.ToString().Trim();
            return result;
        }
    }
}

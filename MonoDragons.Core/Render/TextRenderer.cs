using MonoDragons.Core.Entities;
using MonoDragons.Core.UserInterface;

namespace MonoDragons.Core.Render
{
    public sealed class TextRenderer : IRenderer
    {
        public void Draw(IEntities entities)
        {
            entities.ForEach(
                e => e.With<TextDisplay>(
                    text => UI.DrawTextCentered(text.Text(), e.Transform.ToRectangle(), text.Color, text.Font)));
        }
    }
}

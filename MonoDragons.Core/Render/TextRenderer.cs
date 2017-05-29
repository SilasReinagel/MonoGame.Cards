using MonoDragons.Core.Entities;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;

namespace MonoDragons.Core.Render
{
    public sealed class TextRenderer : IRenderer
    {
        public void Draw(IEntities entities)
        {
            entities.ForEach(
                e => e.With<TextDisplay>(
                    text => e.With<Spatial2>(
                        spatial => UI.DrawTextCentered(text.Text(), spatial.Transform.ToRectangle(), text.Color, text.Font))));
        }
    }
}

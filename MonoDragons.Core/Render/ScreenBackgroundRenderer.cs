using MonoDragons.Core.Engine;
using MonoDragons.Core.Entities;

namespace MonoDragons.Core.Render
{
    public sealed class ScreenBackgroundRenderer : IRenderer
    {
        public void Draw(IEntities entities)
        {
            entities.ForEach(x => x.With<ScreenBackgroundColor>(
                e => World.DrawBackgroundColor(e.Color)));
        }
    }
}

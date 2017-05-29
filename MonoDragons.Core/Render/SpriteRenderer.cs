using MonoDragons.Core.Engine;
using MonoDragons.Core.Entities;
using MonoDragons.Core.PhysicsEngine;

namespace MonoDragons.Core.Render
{
    public sealed class SpriteRenderer : IRenderer
    {
        public void Draw(IEntities entities)
        {
            entities.ForEach(x => x.With<Spatial2>(
                spatial => x.With<Sprite>(
                    sprite => World.Draw(sprite.Name, spatial.Transform))));
        }
    }
}

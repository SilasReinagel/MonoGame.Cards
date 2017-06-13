using System;
using MonoDragons.Core.Entities;

namespace MonoDragons.Core.PhysicsEngine
{
    public class MotionSystem : ISystem
    {
        public void Update(IEntities entities, TimeSpan delta)
        {
            entities.ForEach(e => e.With<Motion2>(
                x => e.Transform.Location = e.Transform.Location + x.Velocity.GetDelta(delta)));
        }
    }
}

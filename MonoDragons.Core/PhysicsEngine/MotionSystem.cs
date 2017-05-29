using System;
using MonoDragons.Core.Entities;

namespace MonoDragons.Core.PhysicsEngine
{
    public class MotionSystem : ISystem
    {
        public void Update(IEntities entities, TimeSpan delta)
        {
            entities.ForEach(x => x.With<Spatial2>(
                spatial => x.With<Motion2>(
                    motion => spatial.Transform.Location = spatial.Transform.Location + motion.Velocity.GetDelta(delta))));
        }
    }
}

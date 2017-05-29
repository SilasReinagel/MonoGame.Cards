using System;
using System.Collections.Generic;
using System.Linq;
using MonoDragons.Core.Common;
using MonoDragons.Core.Entities;

namespace MonoDragons.Core.PhysicsEngine
{
    public sealed class BoxCollision : ISystem
    {
        public void Update(IEntities entities, TimeSpan delta)
        {
            var moving = GetMoving(entities);
            if (!moving.Any())
                return;
            entities.ForEach(
                e => e.With<BoxCollider>(
                    collider => moving.ForEach(x => x.If(!e.Equals(x), 
                        () => StopIfWouldCollide(x, collider, delta)))));
        }

        private List<GameObject> GetMoving(IEntities entities)
        {
            var result = new List<GameObject>();
            entities.ForEach(
                e => e.With<BoxCollider>(
                    solid => e.With<Motion2>(
                        motion => motion.If(motion.Velocity.Speed > 0,
                            () => result.Add(e)))));
            return result;
        }

        // @todo: Evolve this to teleport to last possible location
        private void StopIfWouldCollide(GameObject o, BoxCollider c, TimeSpan time)
        {
            if(c.IsBlocking && c.Transform.Intersects(GetProposedMotion(o, time)))
                o.Get<Motion2>().Velocity.Speed = 0;
        }

        private Transform2 GetProposedMotion(GameObject o, TimeSpan time)
        {
            return o.Get<Spatial2>().Transform + o.Get<Motion2>().Velocity.GetDelta(time);
        }
    }
}

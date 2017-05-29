using MonoDragons.Core.Entities;
using System;

namespace MonoDragons.Core.Characters
{
    public sealed class Reaper : ISystem
    {
        public void Update(IEntities entities, TimeSpan delta)
        {
            entities.ForEach(
                (entity) => entity.With<Mortal>(
                    (mortal) => entity.With<Health>(
                        (health) => { if (health.HP < 1) mortal.OnDeath(); })));
        }
    }
}

using System;
using System.Collections.Generic;

namespace MonoDragons.Core.Entities
{
    public sealed class EntitySystem : IEntitySystemRegistration
    {
        private readonly List<ISystem> _systems = new List<ISystem>();
        private readonly List<IRenderer> _renderers = new List<IRenderer>();
        private readonly IEntities _entities;

        public EntitySystem(IEntities entities)
        {
            _entities = entities;
        }

        public void Register(ISystem system)
        {
            _systems.Add(system);
        }

        public void Register(IRenderer renderer)
        {
            _renderers.Add(renderer);
        }

        public void Update(TimeSpan delta)
        {
            _systems.ForEach(x => x.Update(_entities, delta));
        }

        public void Draw()
        {
            _renderers.ForEach(x => x.Draw(_entities));
        }
    }
}

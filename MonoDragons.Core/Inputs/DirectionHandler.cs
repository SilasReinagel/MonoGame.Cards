using MonoDragons.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoDragons.Core.Inputs
{
    public sealed class DirectionHandler : ISystem
    {
        private Direction _unprocessedDirection = Direction.None;

        public DirectionHandler()
        {
            Input.OnDirection(DirectionChanged);
        }

        public void Update(IEntities entities, TimeSpan delta)
        {
            entities.ForEach(
                (e) => e.With<Directable>(
                    (d) => d.Binding(_unprocessedDirection)));
        }

        private void DirectionChanged(Direction direction)
        {
            _unprocessedDirection = direction;
        }
    }
}

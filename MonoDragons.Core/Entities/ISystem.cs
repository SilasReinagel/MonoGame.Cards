using System;

namespace MonoDragons.Core.Entities
{
    public interface ISystem
    {
        void Update(IEntities entities, TimeSpan delta);
    }
}

using System;

namespace MonoDragons.Core.Engine
{
    public interface IAutomaton
    {
        void Update(TimeSpan delta);
    }
}

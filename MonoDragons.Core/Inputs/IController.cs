using MonoDragons.Core.Common;
using MonoDragons.Core.Engine;

namespace MonoDragons.Core.Inputs
{
    public interface IController : ISubject<ControlChange, Direction>, IAutomaton
    {
        void ClearBindings();
    }
}

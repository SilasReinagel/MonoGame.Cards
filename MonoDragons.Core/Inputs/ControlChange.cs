
namespace MonoDragons.Core.Inputs
{
    public struct ControlChange
    {
        public Control Control { get; }
        public ControlState State { get; }

        public ControlChange(Control control, ControlState state)
        {
            Control = control;
            State = state;
        }
    }
}

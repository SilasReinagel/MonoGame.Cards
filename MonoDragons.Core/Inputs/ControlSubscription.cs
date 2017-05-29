using System;
using MonoDragons.Core.Common;

namespace MonoDragons.Core.Inputs
{
    public class ControlSubscription : ISubscription<ControlChange>
    {
        private readonly Control _control;
        private readonly Action _onActive;
        private readonly Action _onInactive;

        public ControlSubscription(Control control, Action onActive) 
            : this (control, onActive, () => { }) { }

        public ControlSubscription(Control control, Action onActive, Action onInactive)
        {
            _control = control;
            _onActive = onActive;
            _onInactive = onInactive;
        }

        public void Update(ControlChange change)
        {
            if (!change.Control.Equals(_control))
                return;
            if (change.State.Equals(ControlState.Active))
                _onActive();
            if (change.State.Equals(ControlState.Inactive))
                _onInactive();
        }
    }
}

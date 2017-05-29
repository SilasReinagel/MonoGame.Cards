using System;
using MonoDragons.Core.Entities;
using System.Collections.Generic;
using MonoDragons.Core.Characters;

namespace MonoDragons.Core.Inputs
{
    public sealed class ControlHandler : ISystem
    {
        private List<Control> _unprocessedControls = new List<Control>();

        public ControlHandler()
        {
            foreach(Control control in Enum.GetValues(typeof(Control)))
                Input.On(control, () => ControlPressed(control));
        }

        public void Update(IEntities entities, TimeSpan delta)
        {
            _unprocessedControls.ForEach(
                ctrl => entities.ForEach(
                    e => e.With<Controls>(
                        ctrls => ctrls.OnControl(ctrl))));
            _unprocessedControls.Clear();
        }

        private void ControlPressed(Control control)
        {
            _unprocessedControls.Add(control);
        }
    }
}

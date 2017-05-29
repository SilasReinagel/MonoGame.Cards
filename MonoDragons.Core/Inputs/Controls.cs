using MonoDragons.Core.Engine;
using MonoDragons.Core.Inputs;
using System;

namespace MonoDragons.Core.Characters
{
    public sealed class Controls
    {
        public Map<Control, Action> Bindings { get; set; }

        public Controls(Map<Control, Action> bindings)
        {
            Bindings = bindings;
        }

        public void OnControl(Control control)
        {
            if (Bindings.ContainsKey(control))
                Bindings[control]();
        }
    }
}

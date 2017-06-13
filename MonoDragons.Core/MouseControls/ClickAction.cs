using System;

namespace MonoDragons.Core.MouseControls
{
    public sealed class ClickAction
    {
        public Action Action { get; }
        public MouseButton Button { get; }

        public ClickAction(Action action, MouseButton button = MouseButton.Left)
        {
            Action = action;
            Button = button;
        }
    }
}

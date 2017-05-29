using System;
using MonoDragons.Core.Common;

namespace MonoDragons.Core.Inputs
{
    public static class Input
    {
        private static IController _controller;

        public static void SetController(IController controller)
        {
            _controller = controller;
        }

        public static void On(Control control, Action onPress)
        {
            _controller.Subscribe(new ControlSubscription(control, onPress));
        }

        public static void On(Control control, Action onPress, Action onRelease)
        {
            _controller.Subscribe(new ControlSubscription(control, onPress, onRelease));
        }

        public static void OnDirection(Action<Direction> onDirection)
        {
            _controller.Subscribe((SubscriptionAction<Direction>)onDirection);
        }

        public static void ClearBindings()
        {
            _controller.ClearBindings();
        }
    }
}

using System;

namespace MonoDragons.Core.Common
{
    public class SubscriptionAction<T> : ISubscription<T>
    {
        private readonly Action<T> _action;

        private SubscriptionAction(Action<T> action)
        {
            _action = action;
        }

        public void Update(T change)
        {
            _action(change);
        }

        public static implicit operator SubscriptionAction<T>(Action<T> action)
        {
            return new SubscriptionAction<T>(action);
        }
    }
}

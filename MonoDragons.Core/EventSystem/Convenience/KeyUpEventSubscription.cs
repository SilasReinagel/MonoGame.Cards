using System;
using Microsoft.Xna.Framework.Input;
using MonoDragons.Core.Engine;
using MonoDragons.Core.EventSystem.EventTypes;

namespace MonoDragons.Core.EventSystem.Convenience
{
    public class KeyUpEventSubscription
    {
        private readonly Keys _key;
        private readonly Action<KeyUpEvent> _onEvent;
        private readonly object _owner;

        public KeyUpEventSubscription(Action<KeyUpEvent> onEvent, object owner, Keys key)
        {
            _onEvent = onEvent;
            _key = key;
            _owner = owner;
        }

        public void Subscribe()
        {
            World.Subscribe(EventSubscription.Create<KeyUpEvent>(TriggerActionOnProperKey, _owner));
        }

        private void TriggerActionOnProperKey(KeyUpEvent eventt)
        {
            if (eventt.Key.Equals(_key))
                _onEvent(eventt);
        }
    }
}

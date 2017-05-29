using MonoDragons.Core.Engine;
using System;
using System.Collections.Generic;

namespace MonoDragons.Core.EventSystem
{
    public class EventPipe
    {
        private readonly List<Action> _actions = new List<Action>();
        public bool HasNext => _actions.Count > 0;

        public void Subscribe<T>(Action<T> act)
        {
            World.Subscribe(EventSubscription.Create<T>((e) => _actions.Add(() => act(e)), this));
        }

        public void Dequeue()
        {
            _actions[0]();
            _actions.RemoveAt(0);
        }
    }
}

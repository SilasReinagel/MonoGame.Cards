using System;
using System.Collections.Generic;

namespace MonoDragons.Core.Entities
{
    public sealed class GameObjects : IEntities
    {
        private readonly List<GameObject> _entities = new List<GameObject>();

        private int _nextId;
        
        public GameObject Create()
        {
            var obj = new GameObject(_nextId++);
            _entities.Add(obj);
            return obj;
        }

        public void ForEach(Action<GameObject> action)
        {
            _entities.ForEach(action);
        }
    }
}

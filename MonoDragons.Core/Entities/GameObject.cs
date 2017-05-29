
using System;
using MonoDragons.Core.Engine;

namespace MonoDragons.Core.Entities
{
    public sealed class GameObject
    {
        private readonly Map<Type, object> _components = new Map<Type, object>();

        public int Id { get; }

        internal GameObject(int id)
        {
            Id = id;
        }

        public override bool Equals(object obj)
        {
            return obj is GameObject && obj.GetHashCode().Equals(GetHashCode());
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public GameObject Add(object component)
        {
            var type = component.GetType();
            if (_components.ContainsKey(type))
                throw new InvalidOperationException($"Cannot add more than one {type.Name} component.");
            _components.Add(component.GetType(), component);
            return this;
        }
        
        public GameObject Add(Func<GameObject, object> componentBuilder)
        {
            Add(componentBuilder(this));
            return this;
        }

        public T Get<T>()
        {
            return (T)_components[typeof(T)];
        }

        public void With<T>(Action<T> action)
        {
            var type = typeof(T);
            if (_components.ContainsKey(type))
                action((T)_components[type]);
        }
    }
}

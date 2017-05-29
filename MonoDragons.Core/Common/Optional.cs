using System;

namespace MonoDragons.Core.Common
{
    public sealed class Optional<T>
    {
        private readonly T _value;

        public bool HasValue { get; }

        public T Value
        {
            get
            {
                if (!HasValue)
                    throw new InvalidOperationException($"Optional {typeof(T).Name} has no value.");
                return _value;
            }
        }

        public Optional() { }

        public Optional(T value)
        {
            _value = value;
            HasValue = value != null;
        }
    }
}

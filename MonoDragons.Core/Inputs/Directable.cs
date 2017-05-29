
using System;

namespace MonoDragons.Core.Inputs
{
    public sealed class Directable
    {
        public Action<Direction> Binding { get; set; }

        public Directable(Action<Direction> binding)
        {
            Binding = binding;
        }
    }
}

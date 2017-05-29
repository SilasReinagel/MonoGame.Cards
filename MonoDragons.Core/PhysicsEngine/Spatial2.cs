using Microsoft.Xna.Framework;

namespace MonoDragons.Core.PhysicsEngine
{
    public sealed class Spatial2
    {
        public Transform2 Transform { get; }

        public Spatial2(int xPos, int yPos, Size2 size)
            : this (new Transform2(new Vector2(xPos, yPos), size)) { }

        public Spatial2(Transform2 transform)
        {
            Transform = transform;
        }
    }
}

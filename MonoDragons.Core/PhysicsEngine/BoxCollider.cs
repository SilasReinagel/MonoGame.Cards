
namespace MonoDragons.Core.PhysicsEngine
{
    public sealed class BoxCollider
    {
        public bool IsBlocking { get; set; } = true;
        public Transform2 Transform { get; set; }

        public BoxCollider(Transform2 transform)
        {
            Transform = transform;
        }
    }
}

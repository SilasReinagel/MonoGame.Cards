using MonoDragons.Core.Entities;

namespace MonoDragons.Core.PhysicsEngine
{
    public static class PhysicsSystems
    {
        public static void RegisterAll(EntitySystem system)
        {
            system.Register(new BoxCollision());
            system.Register(new MotionSystem());
        }
    }
}

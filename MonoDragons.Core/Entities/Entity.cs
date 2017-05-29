namespace MonoDragons.Core.Entities
{
    public static class Entity
    {
        internal static readonly GameObjects Objs = new GameObjects();
        internal static readonly EntitySystem System = new EntitySystem(Objs);

        public static IEntitySystemRegistration GetSystem()
        {
            return System;
        }

        public static GameObject Create()
        {
            return Objs.Create();
        }
    }
}

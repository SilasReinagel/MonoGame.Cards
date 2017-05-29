using MonoDragons.Core.Entities;

namespace MonoDragons.Core.Render
{
    public static class Renderers
    {
        public static void RegisterAll(EntitySystem system)
        {
            system.Register(new ScreenBackgroundRenderer());
            system.Register(new SpriteRenderer());
            system.Register(new TextRenderer());
        }
    }
}

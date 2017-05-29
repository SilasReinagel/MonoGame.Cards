using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;

namespace MonoDragons.Core.Render
{
    public class Display
    {
        public readonly int ProgramWidth;
        public readonly int ProgramHeight;
        public readonly int GameWidth;
        public readonly int GameHeight;
        public readonly bool FullScreen;
        public readonly float Scale;

        public Display(int width, int height, bool fullScreen, float scale = 1)
        {
            Scale = scale;
            GameWidth = width;
            GameHeight = height;
            FullScreen = fullScreen;
            if (FullScreen)
            {
                ProgramWidth = Hack.TheGame.GraphicsDevice.DisplayMode.Width;
                ProgramHeight = Hack.TheGame.GraphicsDevice.DisplayMode.Height;
            }
            else
            {
                ProgramWidth = GameWidth;
                ProgramHeight = GameHeight;
            }
        }

        public void Apply(GraphicsDeviceManager device)
        {
            device.PreferredBackBufferWidth = ProgramWidth;
            device.PreferredBackBufferHeight = ProgramHeight;
            device.IsFullScreen = FullScreen;
            device.ApplyChanges();
        }
    }
}

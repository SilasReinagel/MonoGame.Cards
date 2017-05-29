using Microsoft.Xna.Framework.Input;

namespace MonoDragons.Core.EventSystem.EventTypes
{
    public class KeyUpEvent
    {
        public Keys Key { get; }

        public KeyUpEvent(Keys key)
        {
            Key = key;
        }
    }
}

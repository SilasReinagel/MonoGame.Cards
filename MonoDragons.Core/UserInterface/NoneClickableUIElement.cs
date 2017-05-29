using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;

namespace MonoDragons.Core.UserInterface
{
    public sealed class NoneClickableUIElement : ClickableUIElement
    {
        public NoneClickableUIElement() : base(new Rectangle(0, 0, 1920, 1080))
        {
        }

        public override void OnEntered()
        {
        }

        public override void OnExitted()
        {
        }

        public override void OnPressed()
        {
        }

        public override void OnReleased()
        {
        }
    }
}

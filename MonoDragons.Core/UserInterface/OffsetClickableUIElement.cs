using Microsoft.Xna.Framework;

namespace MonoDragons.Core.UserInterface
{
    public sealed class OffsetClickableUIElement : ClickableUIElement
    {
        private readonly ClickableUIElement _element;

        public OffsetClickableUIElement(ClickableUIElement element, Point offset) 
            : base(new Rectangle(element.Area.Location + offset, element.Area.Size))
        {
            _element = element;
        }

        public override void OnEntered()
        {
            _element.OnEntered();
        }

        public override void OnExitted()
        {
            _element.OnExitted();
        }

        public override void OnPressed()
        {
            _element.OnPressed();
        }

        public override void OnReleased()
        {
            _element.OnReleased();
        }
    }
}

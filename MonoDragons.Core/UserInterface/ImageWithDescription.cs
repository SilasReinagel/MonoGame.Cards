using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using MonoDragons.Core.PhysicsEngine;

namespace MonoDragons.Core.UserInterface
{
    public class ImageWithDescription : ClickableUIElement, IVisual
    {
        private readonly string _image;
        private readonly Label _label;
        private readonly Transform2 _transform;

        private bool _isDescriptionVisible = false;

        public ImageWithDescription(string image, string description, Transform2 transform) : base(transform.ToRectangle(), true, 1)
        {
            _image = image;
            _label = new Label
            {
                BackgroundColor = Color.FromNonPremultiplied(32, 32, 32, 150),
                TextColor = Color.White,
                Transform = transform,
                Font = "Fonts/12",
                Text = description
            };
            _transform = transform;
        }

        public override void OnEntered()
        {
            _isDescriptionVisible = true;
        }

        public override void OnExitted()
        {
            _isDescriptionVisible = false;
        }

        public override void OnPressed()
        {
            _isDescriptionVisible = !_isDescriptionVisible;
        }

        public override void OnReleased()
        {
        }

        public void Draw(Transform2 parentTransform)
        {
            World.Draw(_image, parentTransform + _transform);
            if (_isDescriptionVisible)
                _label.Draw(parentTransform);
        }
    }
}

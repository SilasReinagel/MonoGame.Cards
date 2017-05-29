using System;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using MonoDragons.Core.PhysicsEngine;

namespace MonoDragons.Core.UserInterface
{
    public class ImageLabel : IVisual, IDisposable
    {
        private readonly Label _label;
        private readonly string _imageName;

        public string Text { set { _label.Text = value; } }

        public ImageLabel(string text, string imageName, Transform2 transform)
        {
            _label = new Label { BackgroundColor = Color.Transparent, TextColor = Color.White, Text = text, Transform = transform };
            _imageName = imageName;
        }

        public void Draw(Transform2 parentTransform)
        {
            World.Draw(_imageName, parentTransform + _label.Transform);
            _label.Draw(parentTransform);
        }

        public void Dispose()
        {
            _label.Dispose();
        }
    }
}

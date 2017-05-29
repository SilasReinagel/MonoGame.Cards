using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoDragons.Core.Engine;
using MonoDragons.Core.Memory;
using MonoDragons.Core.PhysicsEngine;
using System;

namespace MonoDragons.Core.UserInterface
{
    public sealed class ColoredCone : IVisual, IDisposable
    {
        private Texture2D _background;

        private Color color;
        public Color Color { get { return color; } set { color = value; GenerateTexture(); } }
        private Transform2 transform;
        public Transform2 Transform { get { return transform; } set { transform = value; GenerateTexture(); } }
        private Rotation2 angle;
        public Rotation2 Angle { get { return angle; } set { angle = value; GenerateTexture(); } }

        public ColoredCone()
        {
            color = Color.Orange;
            transform = new Transform2(new Size2(400, 400));
            angle = new Rotation2(90);
        }

        public void Draw(Transform2 parentTransform)
        {
            var position = parentTransform + Transform;
            World.DrawRotatedFromCenter(_background, position.ToRectangle(), Transform.Rotation);
        }

        private void GenerateTexture()
        {
            Resources.Dispose(_background);
            _background = new ConeTexture(Transform.Size.Height / 2, Angle, Color).Create();
        }

        public void Dispose()
        {
            Resources.Dispose(_background);
        }
    }
}

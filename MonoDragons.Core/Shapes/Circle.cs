using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoDragons.Core.Shapes
{
    public class Circle
    {
        private readonly float _radius;
        private readonly Color _color;
        private readonly GraphicsDevice _device;

        public Circle(float radius, Color color, GraphicsDevice device)
        {
            _radius = radius;
            _color = color;
            _device = device;
        }

        public Texture2D Get()
        {
            var outerRadius = (int)(_radius * 2 + 2);
            var texture = new Texture2D(_device, outerRadius, outerRadius);

            var data = new Color[outerRadius * outerRadius];

            for (var i = 0; i < data.Length; i++)
                data[i] = Color.Transparent;

            double angleStep = 1f / _radius;

            for (double angle = 0; angle < Math.PI * 2; angle += angleStep)
            {
                var x = (int)Math.Round(_radius + _radius * Math.Cos(angle));
                var y = (int)Math.Round(_radius + _radius * Math.Sin(angle));
                data[y * outerRadius + x + 1] = _color;
            }

            texture.SetData(data);
            return texture;
        }
    }
}

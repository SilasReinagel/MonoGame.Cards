using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.Engine;
using MonoDragons.Core.Common;
using System.Linq;

namespace MonoDragons.Core.UserInterface
{
    public class ConeTexture
    {
        private readonly Color _color;
        private readonly int _range;
        private readonly Rotation2 _angle;

        public ConeTexture(int range, Rotation2 angle, Color color)
        {
            _range = range;
            _color = color;
            _angle = angle;
        }

        public Texture2D Create()
        {
            var radius = _range;
            var radiusSq = radius * radius;
            var diam = radius * 2;
            var colorData = new Color[(diam + 1) * (diam + 1)];

            float perLayerAmount = _angle.Value / 45;
            var baseRequirement = 6 * radius;
            var index = -1;
            var y = 0;
            for (; y < radius; y++)
            {
                var yDistanceAway = radius - y;
                var inverseYDistanceAway = radius - yDistanceAway;
                var radiusPlusYDistanceAway = radius + yDistanceAway;
                var layer = radius;
                var requirement = baseRequirement - 2 * y;
                index++;
                var posa = new Vector2(0 - radius, y - radius);
                if (posa.LengthSquared() <= radiusSq && layer * perLayerAmount >= requirement)
                    colorData[index] = _color;
                else
                    colorData[index] = Color.Transparent;
                var x = 1;
                for (; x <= inverseYDistanceAway; x++)
                {
                    requirement -= 4;
                    layer--;
                    index++;
                    var pos = new Vector2(x - radius, y - radius);
                    if (pos.LengthSquared() <= radiusSq && layer * perLayerAmount >= requirement)
                        colorData[index] = _color;
                    else
                        colorData[index] = Color.Transparent;
                }
                for (; x <= radius; x++)
                {
                    requirement += 2;
                    index++;
                    var pos = new Vector2(x - radius, y - radius);
                    if (pos.LengthSquared() <= radiusSq && layer * perLayerAmount >= requirement)
                        colorData[index] = _color;
                    else
                        colorData[index] = Color.Transparent;
                }
                for (; x <= radiusPlusYDistanceAway; x++)
                {
                    requirement -= 2;
                    index++;
                    var pos = new Vector2(x - radius, y - radius);
                    if (pos.LengthSquared() <= radiusSq && layer * perLayerAmount >= requirement)
                        colorData[index] = _color;
                    else
                        colorData[index] = Color.Transparent;
                }
                for (; x < diam + 1; x++)
                {
                    layer++;
                    requirement += 4;
                    index++;
                    var pos = new Vector2(x - radius, y - radius);
                    if (pos.LengthSquared() <= radiusSq && layer * perLayerAmount >= requirement)
                        colorData[index] = _color;
                    else
                        colorData[index] = Color.Transparent;
                }
            }

            for (; y < diam + 1; y++)
            {
                var yDistanceAway = y - radius;
                var inverseYDistanceAway = radius - yDistanceAway;
                var radiusPlusYDistanceAway = radius + yDistanceAway;
                var layer = radius;
                var requirement = baseRequirement - 2 * y;
                index++;
                var posa = new Vector2(0 - radius, y - radius);
                if (posa.LengthSquared() <= radiusSq && layer * perLayerAmount >= requirement)
                    colorData[index] = _color;
                else
                    colorData[index] = Color.Transparent;
                var x = 1;
                for (; x <= inverseYDistanceAway; x++)
                {
                    requirement -= 4;
                    layer--;
                    index++;
                    var pos = new Vector2(x - radius, y - radius);
                    if (pos.LengthSquared() <= radiusSq && layer * perLayerAmount >= requirement)
                        colorData[index] = _color;
                    else
                        colorData[index] = Color.Transparent;
                }
                for (; x <= radius; x++)
                {
                    requirement -= 2;
                    index++;
                    var pos = new Vector2(x - radius, y - radius);
                    if (pos.LengthSquared() <= radiusSq && layer * perLayerAmount >= requirement)
                        colorData[index] = _color;
                    else
                        colorData[index] = Color.Transparent;
                }
                for (; x <= radiusPlusYDistanceAway; x++)
                {
                    requirement += 2;
                    index++;
                    var pos = new Vector2(x - radius, y - radius);
                    if (pos.LengthSquared() <= radiusSq && layer * perLayerAmount >= requirement)
                        colorData[index] = _color;
                    else
                        colorData[index] = Color.Transparent;
                }
                for (; x < diam + 1; x++)
                {
                    layer++;
                    requirement += 4;
                    index++;
                    var pos = new Vector2(x - radius, y - radius);
                    if (pos.LengthSquared() <= radiusSq && layer * perLayerAmount >= requirement)
                        colorData[index] = _color;
                    else
                        colorData[index] = Color.Transparent;
                }
            }
            var texture = new Texture2D(Hack.TheGame.GraphicsDevice, diam + 1, diam + 1);
            texture.SetData(colorData);
            return texture;
        }
    }
}
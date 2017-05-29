using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoDragons.Core.Engine;
using MonoDragons.Core.PhysicsEngine;
using System.Linq;
using MonoDragons.Core.Common;

namespace MonoDragons.Core.UserInterface
{
    public class ScrollableElements : ClickableUIElement, IVisualAutomaton
    {
        private const decimal ScrollSpeed = 1;

        private readonly Rectangle _area;
        private readonly List<ISpatialVisual> _items;
        private readonly int _margin;

        private bool _isFocused = false;
        private int _pixelOffset = 0;
        private int _totalScrolls = 0;

        public ScrollableElements(Rectangle area, List<ISpatialVisual> items, int margin) : base(area)
        {
            _area = area;
            _items = items;
            _margin = margin;
        }


        public override void OnEntered()
        {
            _isFocused = true;
        }

        public override void OnExitted()
        {
            _isFocused = false;
        }

        public override void OnPressed()
        {
        }

        public override void OnReleased()
        {
        }

        public void Update(TimeSpan delta)
        {
            var scrollsSinceLastUpdate = Mouse.GetState().ScrollWheelValue - _totalScrolls;
            if (_isFocused)
                _pixelOffset = WithinBounds(_pixelOffset + (int)(scrollsSinceLastUpdate * ScrollSpeed));
            _totalScrolls += scrollsSinceLastUpdate;
        }

        public void Draw(Transform2 parentTransform)
        {
            var offset = -_pixelOffset;
            foreach (var item in _items)
            {
                var offsetTransform = new Transform2(new Vector2(0, offset));
                if (offsetTransform.Location.Y >= 0 && offsetTransform.Location.Y + item.Transform.Size.Height <= _area.Height) 
                    item.Draw(offsetTransform + parentTransform + new Transform2(new Vector2(Area.X, Area.Y)));
                offset += item.Transform.Size.Height + _margin;
            }
        }

        public int WithinBounds(int value)
        {
            return Math.Max(0, Math.Min(_items.Sum(x => x.Transform.Size.Height + _margin) - _area.Height, value));
        }
    }
}

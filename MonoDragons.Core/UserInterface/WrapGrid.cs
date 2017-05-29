using Microsoft.Xna.Framework;
using System.Collections.Generic;
using MonoDragons.Core.Engine;
using MonoDragons.Core.PhysicsEngine;

namespace MonoDragons.Core.UserInterface
{
    public class WrapGrid : IVisual
    {
        private List<IVisual> _items = new List<IVisual>();

        public Vector2 Location { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int ColumnWidth { get; set; }
        public int RowHeight { get; set; }
        public bool UseHorizontalOrientation { get; set; }

        public WrapGrid(Vector2 location, int rows, int columns, int columnWidth, int rowHeight, bool useHorizontalOrientation = true)
        {
            Location = location;
            Rows = rows;
            Columns = columns;
            ColumnWidth = columnWidth;
            RowHeight = rowHeight;
            UseHorizontalOrientation = useHorizontalOrientation;
        }

        public void Add(IVisual element)
        {
            _items.Add(element);
        }

        public void Remove(IVisual element)
        {
            _items.Remove(element);
        }

        public IVisual ItemAt(int indexer)
        {
            return _items[indexer];
        }

        public List<IVisual> Items()
        {
            return _items;
        }

        public void Draw(Transform2 parentTransform)
        {
            var location = parentTransform.Location + Location;
            for(var i = 0; i < _items.Count ; i++)
                if (i <= Rows * Columns)
                {
                    var row = UseHorizontalOrientation ? i / Columns : i % Rows;
                    var column = UseHorizontalOrientation ? i % Columns : i / Rows;
                    _items[i].Draw(new Transform2(new Vector2(location.X + column * ColumnWidth, location.Y + row * RowHeight)));
                }
        }
    }
}

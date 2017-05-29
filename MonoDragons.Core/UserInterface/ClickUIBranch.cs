using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using MonoDragons.Core.Common;

namespace MonoDragons.Core.UserInterface
{
    public class ClickUIBranch
    {
        private HashSet<ClickableUIElement> _elements = new HashSet<ClickableUIElement>();
        private List<ClickUIBranch> _subBranches = new List<ClickUIBranch>();
        public readonly int Priority;
        public float Scale;
        private readonly string _name;
        private List<Action<ClickUIBranch>[]> subscriberActions = new List<Action<ClickUIBranch>[]>();

        private Vector2 parentLocation;
        public Vector2 ParentLocation
        {
            get { return parentLocation; }
            set
            {
                parentLocation = value;
                totalLocation = new Vector2(location.X + ParentLocation.X, location.Y + ParentLocation.Y);
                _subBranches.ForEach((b) => b.ParentLocation = totalLocation);
                _elements.ForEach((e) => e.ParentLocation = totalLocation);
            }
        }
        private Vector2 location;
        public Vector2 Location
        {
            get { return location; }
            set
            {
                location = value;
                totalLocation = new Vector2(location.X + ParentLocation.X, location.Y + ParentLocation.Y);
                _subBranches.ForEach((b) => b.ParentLocation = totalLocation);
                _elements.ForEach((e) => e.ParentLocation = totalLocation);
            }
        }
        private Vector2 totalLocation;

        public ClickUIBranch(string name, int priority, float scale = 1)
        {
            Scale = scale;
            Priority = priority;
            _name = name;
        }

        public void Add(ClickableUIElement element)
        {
            _elements.Add(element);
        }

        public void Remove(ClickableUIElement element)
        {
            _elements.Remove(element);
        }

        public ClickUIBranch SubBranch(int indexer)
        {
            return _subBranches[indexer];
        }

        public List<ClickUIBranch> SubBranches()
        {
            return _subBranches;
        }

        public void Add(ClickUIBranch branch)
        {
            branch.ParentLocation = new Vector2(ParentLocation.X + Location.X, ParentLocation.Y + Location.Y);
            _subBranches.Add(branch);
            subscriberActions.ForEach((a) => a[0](branch));
        }

        public void Remove(ClickUIBranch branch)
        {
            _subBranches.Remove(branch);
            subscriberActions.ForEach((a) => a[1](branch));
        }

        public void Subscribe(Action<ClickUIBranch>[] actions)
        {
            subscriberActions.Add(actions);
        }

        public void Unsubscribe(Action<ClickUIBranch>[] actions)
        {
            subscriberActions.Remove(actions);
        }
        public void ClearElements()
        {
            _elements.Clear();
        }

        public ClickableUIElement GetElement(Point mousePosition)
        {
            var position = new Point((int)Math.Round(mousePosition.X / Scale), (int)Math.Round(mousePosition.Y / Scale));
            var element = _elements.FirstOrDefault(x => x.Area.Contains(position - totalLocation.ToPoint()) && x.IsEnabled);
            return element ?? ClickUI.None;
        }

        public override string ToString()
        {
            return _name;
        }
    }
}

using Microsoft.Xna.Framework;
using System;

namespace MonoDragons.Core.UserInterface
{
    public abstract class ClickableUIElement
    {
        public abstract void OnEntered();
        public abstract void OnExitted();
        public abstract void OnPressed();
        public abstract void OnReleased();
        
        public float Scale { get; }
        public Vector2 ParentLocation { get; set; }
        public Rectangle Area { get; }
        public bool IsEnabled { get; set; }

        protected ClickableUIElement(Rectangle area, bool isEnabled = true, float scale = 1)
        {
            Area = new Rectangle((int)Math.Round(area.X * scale), (int)Math.Round(area.Y * scale),
                (int)Math.Round(area.Width * scale), (int)Math.Round(area.Height * scale));
            Scale = scale;
            ParentLocation = new Vector2(0, 0);
            IsEnabled = isEnabled;
        }
    }
}

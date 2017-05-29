
using System;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Inputs;

namespace MonoDragons.Core.PhysicsEngine
{
    public class Velocity2
    {
        public float Speed { get; set; } = 0f;
        public Rotation2 Direction { get; set; } = Rotation2.Default;

        private float Distance(TimeSpan delta)
        {
            return Speed * (float)delta.TotalMilliseconds;
        }

        // TODO: This needs to use Trigonometry to apply the velocity correctly
        public Vector2 GetDelta(TimeSpan delta)
        {
            var distance = Distance(delta);
            return new Vector2(GetXDirection() * distance, GetYDirection() * distance);
        }

        private float GetXDirection()
        {
            switch (Direction.ToDirection().HDir)
            {
                case HorizontalDirection.Left:
                    return -1.0f;
                case HorizontalDirection.Right:
                    return 1.0f;
                default:
                    return 0;
            }
        }

        private float GetYDirection()
        {
            switch (Direction.ToDirection().VDir)
            {
                case VerticalDirection.Down:
                    return 1.0f;
                case VerticalDirection.Up:
                    return -1.0f;
                default:
                    return 0;
            }
        }
    }
}

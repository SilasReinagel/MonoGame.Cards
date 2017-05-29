using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace MonoDragons.Core.PhysicsEngine
{
    public class PhysicsInstance
    {
        private readonly List<Action> callbacks = new List<Action>();

        public float GetDistance(float speed, TimeSpan deltaTime)
        {
            return (float)(speed * deltaTime.TotalMilliseconds);
        }

        public Vector2 GetDirectionTowards(Vector2 source, Vector2 destination)
        {
            var direction = new Vector2(destination.X - source.X, destination.Y - source.Y);
            direction.Normalize();
            if (float.IsNaN(direction.X) || float.IsNaN(direction.Y))
                return Vector2.Zero;
            return direction;
        }

        public Vector2 GetLocation(Vector2 source, Vector2 direction, float distance)
        {
            var part1 = new Vector2(direction.X * distance, direction.Y * distance);
            return new Vector2(source.X + part1.X, source.Y + part1.Y);
        }

        public float GetDistanceBetween(Vector2 source, Vector2 destination)
        {
            var distance = new Vector2(source.X - destination.X, source.Y - destination.Y).Length();
            return float.IsNaN(distance) ? 1 : distance;
        }



        public void MoveTowards(Vector2 source, Vector2 destination, float speed, TimeSpan deltaTime, Action<Vector2> moveCallback)
        {
            MoveTowards(source, destination, GetDistance(speed, deltaTime), moveCallback);
        }

        public void MoveTowards(Vector2 source, Vector2 destination, float distance, Action<Vector2> moveCallback)
        {
            Move(source, GetDirectionTowards(source, destination), Math.Min(distance, GetDistanceBetween(source, destination)), moveCallback);
        }

        public void Move(Vector2 source, Vector2 direction, float speed, TimeSpan deltaTime, Action<Vector2> moveCallback)
        {
            Move(source, direction, GetDistance(speed, deltaTime), moveCallback);
        }

        public void Move(Vector2 source, Vector2 direction, float distance, Action<Vector2> moveCallback)
        {
            callbacks.Add(() => moveCallback(GetLocation(source, direction, distance)));
        }

        public void Arrive(Vector2 source, Vector2 destination, Action uponArrivial)
        {
            callbacks.Add(() =>
            {
                if (Math.Abs(source.X - destination.X) < 1 && Math.Abs(source.Y - destination.Y) < 1)
                    uponArrivial();
            });
        }

        public void Resolve()
        {
            var list = callbacks.ToList();
            callbacks.Clear();
            list.ForEach(x => x());
        }
    }
}

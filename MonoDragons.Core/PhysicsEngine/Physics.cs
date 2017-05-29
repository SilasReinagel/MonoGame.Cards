using System;
using Microsoft.Xna.Framework;

namespace MonoDragons.Core.PhysicsEngine
{
    public class Physics
    {
        private static readonly PhysicsInstance _instance = new PhysicsInstance();

        public float GetDistance(float speed, TimeSpan deltaTime)
        {
            return _instance.GetDistance(speed, deltaTime);
        }

        public void MoveTowards(Vector2 source, Vector2 destination, float speed, TimeSpan deltaTime, Action<Vector2> moveCallback)
        {
            _instance.MoveTowards(source, destination, speed, deltaTime, moveCallback);
        }

        public void MoveTowards(Vector2 source, Vector2 destination, float distance, Action<Vector2> moveCallback)
        {
            _instance.MoveTowards(source, destination, distance, moveCallback);
        }

        public Vector2 GetDirectionTowards(Vector2 source, Vector2 destination)
        {
            return _instance.GetDirectionTowards(source, destination);
        }

        public void Move(Vector2 source, Vector2 direction, float speed, TimeSpan deltaTime, Action<Vector2> moveCallback)
        {
            _instance.Move(source, direction, speed, deltaTime, moveCallback);
        }

        public void Move(Vector2 source, Vector2 direction, float distance, Action<Vector2> moveCallback)
        {
            _instance.Move(source, direction, distance, moveCallback);
        }

        public void Arrive(Vector2 source, Vector2 destination, Action uponArrivial)
        {
            _instance.Arrive(source, destination, uponArrivial);
        }

        public Vector2 GetLocation(Vector2 source, Vector2 direction, float distance)
        {
            return _instance.GetLocation(source, direction, distance);
        }

        public void Resolve()
        {
            _instance.Resolve();
        }
    }
}

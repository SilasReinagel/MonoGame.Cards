using System;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using MonoDragons.Core.PhysicsEngine;

namespace MonoDragons.Core.Render
{
    public class Animations
    {
        private readonly Map<string, Animation> _states;

        private string _currentState;

        public Animations(Map<string, Animation> states, string initialState)
        {
            _states = states;
            _currentState = initialState;
        }

        private Animation CurrentAnimation => _states[_currentState];
        
        public void SetState(string stateId)
        {
            if (_currentState.Equals(stateId))
                return;

            _currentState = stateId;
        }

        public void Update(TimeSpan delta)
        {
            CurrentAnimation.Update(delta);
        }

        public void Draw(Transform2 transform)
        {
            CurrentAnimation.Draw(transform);
        }
    }
}

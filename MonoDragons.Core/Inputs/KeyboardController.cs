using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Input;
using MonoDragons.Core.Common;
using MonoDragons.Core.Engine;

namespace MonoDragons.Core.Inputs
{
    public class KeyboardController : Subject<ControlChange, Direction>, IController
    {
        private readonly Map<Keys, HorizontalDirection> _hDirBind;
        private readonly Map<Keys, VerticalDirection> _vDirBind;
        private readonly Map<Keys, Control> _controlBind;

        private KeyboardState _lastState;
        private Direction _lastDirection = Direction.None;
        private Direction _currentDirection = Direction.None;

        public KeyboardController(Map<Keys, Control> controlBind)
            : this(CreateDefaultHDirBind(), CreateDefaultVDirBind(), controlBind) { }

        public KeyboardController(Map<Keys, HorizontalDirection> hDirBind, Map<Keys, VerticalDirection> vDirBind, Map<Keys, Control> controlBind)
        {
            _hDirBind = hDirBind;
            _vDirBind = vDirBind;
            _controlBind = controlBind;
        }

        public void Update(TimeSpan delta)
        {
            var state = Keyboard.GetState();
            var downKeys = state.GetPressedKeys().ToList();
            var pressedKeys = downKeys.Where(x => !_lastState.GetPressedKeys().Any(y => x.Equals(y))).ToList();
            var releasedKeys = _lastState.GetPressedKeys().Where(x => downKeys.All(y => !y.Equals(x))).ToList();
            _currentDirection = GetDirection(downKeys);
            NotifyControlSubscribers(pressedKeys, releasedKeys);
            NotifyDirectionSubscribers(_currentDirection);
            _lastState = state;
            _lastDirection = _currentDirection;
        }

        private Direction GetDirection(List<Keys> downKeys)
        {
            var hDir = (HorizontalDirection)downKeys
                .Where(x => _hDirBind.ContainsKey(x))
                .Select(x => (int)_hDirBind[x])
                .Distinct()
                .Sum();
            var vDir = (VerticalDirection)downKeys
                .Where(x => _vDirBind.ContainsKey(x))
                .Select(x => (int)_vDirBind[x])
                .Distinct()
                .Sum();
            return new Direction(hDir, vDir);
        }

        private void NotifyDirectionSubscribers(Direction direction)
        {
            NotifySubscribers(direction);
        }

        private void NotifyControlSubscribers(List<Keys> pressedKeys, List<Keys> releasedKeys)
        {
            pressedKeys.Where(x => _controlBind.ContainsKey(x))
                .ForEach(x => NotifySubscribers(new ControlChange(_controlBind[x], ControlState.Active)));
            releasedKeys.Where(x => _controlBind.ContainsKey(x))
                .ForEach(x => NotifySubscribers(new ControlChange(_controlBind[x], ControlState.Inactive)));

            if ((int)_currentDirection.HDir != (int)_lastDirection.HDir && _currentDirection.HDir == HorizontalDirection.Left)
                NotifySubscribers(new ControlChange(Control.Left, ControlState.Active));
            if ((int)_currentDirection.HDir != (int)_lastDirection.HDir && _currentDirection.HDir == HorizontalDirection.Right)
                NotifySubscribers(new ControlChange(Control.Right, ControlState.Active));
            if ((int)_currentDirection.VDir != (int)_lastDirection.VDir && _currentDirection.VDir == VerticalDirection.Down)
                NotifySubscribers(new ControlChange(Control.Down, ControlState.Active));
            if ((int)_currentDirection.VDir != (int)_lastDirection.VDir && _currentDirection.VDir == VerticalDirection.Up)
                NotifySubscribers(new ControlChange(Control.Up, ControlState.Active));

            if ((int)_currentDirection.HDir != (int)_lastDirection.HDir && _lastDirection.HDir == HorizontalDirection.Left)
                NotifySubscribers(new ControlChange(Control.Left, ControlState.Inactive));
            if ((int)_currentDirection.HDir != (int)_lastDirection.HDir && _lastDirection.HDir == HorizontalDirection.Right)
                NotifySubscribers(new ControlChange(Control.Right, ControlState.Inactive));
            if ((int)_currentDirection.VDir != (int)_lastDirection.VDir && _lastDirection.VDir == VerticalDirection.Down)
                NotifySubscribers(new ControlChange(Control.Down, ControlState.Inactive));
            if ((int)_currentDirection.VDir != (int)_lastDirection.VDir && _lastDirection.VDir == VerticalDirection.Up)
                NotifySubscribers(new ControlChange(Control.Up, ControlState.Inactive));
        }

        private static Map<Keys, VerticalDirection> CreateDefaultVDirBind()
        {
            return new Map<Keys, VerticalDirection>
            {
                {Keys.W, VerticalDirection.Up},
                {Keys.S, VerticalDirection.Down},
                {Keys.Up, VerticalDirection.Up},
                {Keys.Down, VerticalDirection.Down},
            };
        }

        private static Map<Keys, HorizontalDirection> CreateDefaultHDirBind()
        {
            return new Map<Keys, HorizontalDirection>
            {
                {Keys.A, HorizontalDirection.Left},
                {Keys.D, HorizontalDirection.Right},
                {Keys.Left, HorizontalDirection.Left},
                {Keys.Right, HorizontalDirection.Right},
            };
        }

        public void ClearBindings()
        {
            _observers1.Clear();
            _observers2.Clear();
        }
    }
}

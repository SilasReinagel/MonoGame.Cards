using System;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Memory;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;
using System.Diagnostics;

namespace MonoDragons.Core.Engine
{
    public sealed class Metrics : IVisualAutomaton
    {
        private readonly Timer _timer;

        private int _framesThisSecond;
        private int _updatesThisSecond;
        private int _framesPerSecond;
        private int _updatesPerSecond;
        private int _frameRateTroubleCount;

        public Metrics()
        {
            _timer = new Timer(AccumulateMetrics, 500);
#if DEBUG
            AppDomain.MonitoringIsEnabled = true;
#endif
        }

        public void Update(TimeSpan delta)
        {
#if DEBUG  
            _timer.Update(delta);
            _updatesThisSecond++;
#endif
        }

        public void Draw(Transform2 parentTransform)
        {
#if DEBUG
            var memory = AppDomain.MonitoringSurvivedProcessMemorySize;
            var exponent = memory.ToString().Length - 2;
            memory = (int)Math.Round(memory / Math.Pow(10, exponent));
            var color = Color.Yellow;
            UI.DrawText($"FPS: {_framesPerSecond}", new Vector2(0, 0), color);
            UI.DrawText($"UPS: {_updatesPerSecond}", new Vector2(0, 40), color);
            UI.DrawText($"RAM: {memory}e{exponent}", new Vector2(0, 80), color);
            UI.DrawText($"Sub: {World.CurrentEventSubscriptionCount}", new Vector2(0, 120), color);
            UI.DrawText($"Scn: {Resources.CurrentSceneDisposableCount}", new Vector2(0, 160), color);
            _framesThisSecond++;
#endif
        }

        private void AccumulateMetrics()
        {
            _framesPerSecond = _framesThisSecond * 2;
            _framesThisSecond = 0;
            _updatesPerSecond = _updatesThisSecond * 2;
            _updatesThisSecond = 0;
            CheckForProcessTrouble();
        }

        private void CheckForProcessTrouble()
        {
            _frameRateTroubleCount = _framesPerSecond < 12 ? _frameRateTroubleCount + 1 : 0;
            if (_framesPerSecond < 12)
                Debug.WriteLine("Framerate Warning: Framerate = " + _framesPerSecond);
            if (_frameRateTroubleCount > 4)
            {
                Debug.WriteLine("Framerate Exception: Exiting Program.");
                Hack.TheGame.Exit();
            }
        }
    }
}

using System;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using MonoDragons.Core.Text;

namespace MonoDragons.Core.Memory
{
    public static class Resources
    {
        private static Game _game;
        private static SceneContents _sceneContents;

        public static int CurrentSceneDisposableCount => _sceneContents?.ContentCount ?? 0;

        public static void Init(Game game)
        {
            _game = game;
            _sceneContents = new SceneContents(_game.Content);
        }

        public static void Put(string toString, IDisposable disposable)
        {
            _sceneContents.Put(disposable);
        }

        public static T Load<T>(string resourceName)
        {
            return _sceneContents.Load<T>(resourceName);
        }

        public static void Unload()
        {
            _sceneContents.Dispose();
            _sceneContents = new SceneContents(_game.Content);
            DefaultFont.Load(_game.Content);
        }

        public static void Dispose(IDisposable disposable)
        {
            if (disposable != null)
                _sceneContents.Dispose(disposable);
        }

        public static void NotifyDisposed(IDisposable disposable)
        {
            if (disposable != null)
                _sceneContents.NotifyDisposed(disposable);
        }

    }
}

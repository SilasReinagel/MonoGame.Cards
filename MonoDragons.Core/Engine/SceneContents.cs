using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Content;

namespace MonoDragons.Core.Engine
{
    public class SceneContents : IDisposable
    {
        private readonly HashSet<IDisposable> _diposables = new HashSet<IDisposable>();
        private readonly ContentManager _contentManager;

        public int ContentCount => _diposables.Count;

        public SceneContents(ContentManager contentManager)
        {
            _contentManager = contentManager;
        }

        public void Put(IDisposable disposable)
        {
            _diposables.Add(disposable);
        }

        public T Load<T>(string resourceName)
        {
            return _contentManager.Load<T>(resourceName);
        }

        public void Dispose()
        {
            _diposables.ToList().ForEach(x => x.Dispose());
            _diposables.Clear();
            _contentManager.Unload();
        }

        public void Dispose(IDisposable disposable)
        {
            disposable.Dispose();
            _diposables.Remove(disposable);
        }

        public void NotifyDisposed(IDisposable disposable)
        {
            _diposables.Remove(disposable);
        }
    }
}

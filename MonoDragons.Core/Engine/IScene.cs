using System;

namespace MonoDragons.Core.Engine
{
    public interface IScene
    {
        void Init();
        void Update(TimeSpan delta);
        void Draw();
    }
}

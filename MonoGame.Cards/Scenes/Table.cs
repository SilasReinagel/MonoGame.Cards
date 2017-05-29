using System;
using MonoDragons.Core.Engine;
using MonoDragons.Core.Entities;
using MonoDragons.Core.PhysicsEngine;

namespace MonoGame.Cards.Scenes
{
    public sealed class Table : IScene
    {
        public void Init()
        {
            Entity.Create(new Transform2(new Size2(1920, 1080)))
                .Add(new Sprite("Images/Table/casino-felt"));
        }

        public void Update(TimeSpan delta)
        {
        }

        public void Draw()
        {
        }
    }
}

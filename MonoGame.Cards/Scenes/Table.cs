using System;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using MonoDragons.Core.Entities;
using MonoDragons.Core.MouseControls;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;
using MonoGame.Cards.Cards;

namespace MonoGame.Cards.Scenes
{
    public sealed class Table : IScene
    {
        public void Init()
        {
            Entity.GetSystem().Register(new MouseDragging());
            Entity.GetSystem().Register(new MouseClicking());

            Entity.Create(new Transform2(new Size2(1920, 1080)))
                .Add(new Sprite("Images/Table/casino-felt"));

            var card =
                new Card(new CardData { Back = "Cards/spiral-back", Front = "Decks/Poker/ace-of-diamonds"} );
            Entity.Create(new Transform2(new Vector2(10, 10), Sizes.Card))
                .Add(card.Sprite)
                .Add(new MouseDrag())
                .Add(new ClickAction(() => card.Flip()));
        }

        public void Update(TimeSpan delta)
        {
        }

        public void Draw()
        {
        }
    }
}

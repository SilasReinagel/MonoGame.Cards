using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Common;
using MonoDragons.Core.Engine;
using MonoDragons.Core.Entities;
using MonoDragons.Core.MouseControls;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;
using MonoGame.Cards.Cards;
using MonoGame.Cards.Decks;

namespace MonoGame.Cards.Scenes
{
    public sealed class Table : IScene
    {
        public void Init()
        {
            Entity.GetSystem().Register(new MouseClicking());
            Entity.GetSystem().Register(new MouseDragging());

            Entity.Create(new Transform2(new Size2(1920, 1080)))
                .Add(new Sprite("Images/Table/casino-felt"));

            var card = new Card(new CardData { Back = "Cards/spiral-back", Front = "Decks/Poker/ace-of-diamonds"} );
            Create(new Vector2(10, 10), card);

            var deck = 
                new Deck(
                    new List<Card> {
                        new Card(new CardData { Back = "Cards/spiral-back", Front = "Decks/Poker/ace-of-diamonds" }),
                        new Card(new CardData { Back = "Cards/spiral-back", Front = "Decks/Poker/ace-of-diamonds" })
                    });
            Entity.Create(new Transform2(new Vector2(200, 200), Sizes.Card))
                .Add(deck.Sprite)
                .Add(x => new MouseDownAction(() => deck.If(deck.Count > 0, () => Create(x.Transform.Location, deck.Draw()))));
        }

        private void Create(Vector2 location, Card card)
        {
            Entity.Create(new Transform2(location, Sizes.Card))
                .Add(card.Sprite)
                .Add(new MouseDrag())
                .Add(new ClickAction(card.Flip));
        }

        public void Update(TimeSpan delta)
        {
        }

        public void Draw()
        {
        }
    }
}

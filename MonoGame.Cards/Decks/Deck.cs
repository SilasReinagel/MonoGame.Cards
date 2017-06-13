using System;
using System.Collections.Generic;
using System.Linq;
using MonoDragons.Core.Common;
using MonoDragons.Core.PhysicsEngine;
using MonoGame.Cards.Cards;

namespace MonoGame.Cards.Decks
{
    public sealed class Deck
    {
        private const string Empty = "Images/Decks/empty-black";
        private readonly List<Card> _cards;

        public int Count => _cards.Count;
        public Sprite Sprite { get; } = new Sprite(Empty);

        public Deck(IEnumerable<Card> cards)
        {
            _cards = cards.ToList();
            UpdateSprite();
        }

        public void Shuffle()
        {
            _cards.Shuffle();
        }

        public Card Draw()
        {
            if (Count == 0)
                throw new InvalidOperationException("No cards to draw");

            var card = _cards[0];
            _cards.RemoveAt(0);
            UpdateSprite();
            return card;
        }

        private void UpdateSprite()
        {
            Sprite.Name = Count > 0 ? _cards[0].Sprite.Name : Empty;
        }
    }
}

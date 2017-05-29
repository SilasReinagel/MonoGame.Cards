using MonoDragons.Core.PhysicsEngine;

namespace MonoGame.Cards.Cards
{
    public sealed class Card
    {
        private readonly CardData _data;
        private bool _faceUp;

        public Sprite Sprite { get; }

        public Card(CardData data)
        {
            _data = data;
            Sprite = new Sprite("Images/", data.Back);
        }

        public void Flip()
        {
            _faceUp = !_faceUp;
            Sprite.Name = _faceUp ? _data.Front : _data.Back;
        }
    }
}

using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;

namespace MonoDragons.Core.Render
{
    public sealed class MutableTextPage : IVisual
    {
        private readonly List<Label> _drawnTexts = new List<Label>();
        private readonly Transform2 _betweenTexts;
        private readonly Color _textColor;

        public MutableTextPage()
        {
            _betweenTexts = new Transform2(new Vector2(0, 100));
            _textColor = Color.White;
        }

        public void Set(List<string> texts)
        {
            while (_drawnTexts.Count < texts.Count)
                _drawnTexts.Add(new Label());
            for (var i = 0; i < texts.Count; i++)
                _drawnTexts[i].Text = texts[i];
        }

        public void Draw(Transform2 parentTransform)
        {
            var currentTransform = parentTransform;
            foreach (var text in _drawnTexts)
            {
                text.Draw(currentTransform);
                currentTransform += _betweenTexts;
            }
        }
    }
}

using Microsoft.Xna.Framework;

namespace MonoDragons.Core.Graphics
{
    public class BobbingEffect
    {
        private readonly int _framesPerIndexerIncrement = 25;
        private int _indexer = 0;
        private int _frame = 0;
        private readonly Vector2[] _bobbingEffect;
        public Vector2 Effect
        {
            get
            {
                if (++_frame == _framesPerIndexerIncrement)
                {
                    _frame = 0;
                    _indexer = ++_indexer < _bobbingEffect.Length ? _indexer : 0;
                }
                return _bobbingEffect[_indexer];
            }
        }
        //= new Vector2[] { new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 1), new Vector2(1, 2), new Vector2(1, 3), new Vector2(0, 3), new Vector2(-1, 3), new Vector2(-1, 2), new Vector2(-1, 1), new Vector2(0, 1) }
        public BobbingEffect(int framesPerChange, params Vector2[] offsets)
        {
            _framesPerIndexerIncrement = framesPerChange;
            _bobbingEffect = offsets;
        }

        public BobbingEffect(int framesPerChange, params int[] offsetsParams)
        {
            _framesPerIndexerIncrement = framesPerChange;
            _bobbingEffect = new Vector2[offsetsParams.Length / 2];
            for (var i = 0; i * 2 < offsetsParams.Length; i++)
                _bobbingEffect[i] = new Vector2(offsetsParams[i * 2], offsetsParams[i * 2 + 1]);
        }
    }
}
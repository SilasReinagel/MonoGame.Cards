using NAudio.Wave;
using System;

namespace MonoDragons.Core.Audio
{
    class DisposingFileReader : ISampleProvider
    {
        public event EventHandler Disposed;

        public WaveFormat WaveFormat => _reader.WaveFormat;
        private readonly AudioFileReader _reader;

        public DisposingFileReader(AudioFileReader reader)
        {
            _reader = reader;
        }

        private bool isDisposed;
        public int Read(float[] buffer, int offset, int count)
        {
            if (isDisposed)
                return 0;

            var read = _reader.Read(buffer, offset, count);
            if (read < count)
            {
                _reader.Dispose();
                isDisposed = true;

                Disposed?.Invoke(this, EventArgs.Empty);
            }

            return read;
        }
    }
}
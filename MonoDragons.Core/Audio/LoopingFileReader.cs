using NAudio.Wave;

namespace MonoDragons.Core.Audio
{
    class LoopingFileReader : ISampleProvider
    {
        public WaveFormat WaveFormat => _reader.WaveFormat;
        private readonly AudioFileReader _reader;

        public LoopingFileReader(AudioFileReader reader)
        {
            _reader = reader;
        }

        public int Read(float[] buffer, int offset, int count)
        {
            var read = _reader.Read(buffer, offset, count);
            if (read < count)
            {
                _reader.Position = 0;
                read = _reader.Read(buffer, offset, count);
            }
            return read;
        }
    }
}
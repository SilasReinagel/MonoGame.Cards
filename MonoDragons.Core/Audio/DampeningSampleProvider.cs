using NAudio.Wave;
using System.Threading;

namespace MonoDragons.Core.Audio
{
    public class DampeningSampleProvider : ISampleProvider
    {
        public int Dampeners => _dampeners;
        int _dampeners;

        public float Volume { get; set; }
        public WaveFormat WaveFormat => _source.WaveFormat;
  
        private readonly ISampleProvider _source;

        public DampeningSampleProvider(ISampleProvider source, float volume)
            : this(source, volume, 0) { }

        public DampeningSampleProvider(ISampleProvider source, float volume, int dampeners)
        {
            _source = source;
            Volume = volume;
            _dampeners = dampeners;
        }

        public int Read(float[] buffer, int offset, int sampleCount)
        {
            if (Volume <= 0) return 0;

            var samplesRead = _source.Read(buffer, offset, sampleCount);

            var scaledVolume = Dampeners > 0
                ? Volume * .1f
                : Volume;

            for (var n = 0; n < samplesRead; n++)
                buffer[offset + n] *= scaledVolume;

            return samplesRead;
        }

        public void AddDampener()
        {
            Interlocked.Increment(ref _dampeners);
        }
        public void RemoveDampener()
        {
            Interlocked.Decrement(ref _dampeners);
        }
    }
}
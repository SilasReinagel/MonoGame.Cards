using NAudio.Wave;

namespace MonoDragons.Core.Audio
{
    public static class Audio
    {
        public static void PlaySound(string soundName)
        {
            PlaySound(soundName, 1.0f);
        }
        public static void PlaySound(string soundName, float volume)
        {
            var filename = $"Content/Sounds/{ soundName }.mp3";
            var input = new DisposingFileReader(new AudioFileReader(filename));

            if (_musicTrack != null)
            {
                _musicTrack.AddDampener();
                input.Disposed += sound_Disposed;
            }

            AudioPlaybackEngine.Instance.Play(input);
        }

        private static void sound_Disposed(object sender, System.EventArgs e)
        {
            ((DisposingFileReader)sender).Disposed -= sound_Disposed;
            _musicTrack.RemoveDampener();
        }

        static DampeningSampleProvider _musicTrack;

        public static void PlayMusicOnce(string songName)
        {
            PlayMusicOnce(songName, 0.5f);
        }

        public static void PlayMusicOnce(string songName, float volume)
        {
            var filename = $"Content/{ songName }.mp3";
            var song = new AudioFileReader(filename);
            TransitionToSong(volume, song);
        }

        public static void PlayMusic(string songName)
        {
            PlayMusic(songName, 0.5f);
        }

        public static void PlayMusic(string songName, float volume)
        {
            var filename = $"Content/{ songName }.mp3";
            var song = new LoopingFileReader(new AudioFileReader(filename));
            TransitionToSong(volume, song);
        }

        private static void TransitionToSong(float volume, ISampleProvider song)
        {
            if (_musicTrack == null)
                _musicTrack = new DampeningSampleProvider(song, volume);
            else
            {
                var old = _musicTrack;
                _musicTrack = new DampeningSampleProvider(song, volume, old.Dampeners);
                old.Volume = 0;
            }
            AudioPlaybackEngine.Instance.Play(_musicTrack);
        }
    }
}
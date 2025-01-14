using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using NAudio.Wave;

namespace MusicAppWPF.ViewModels
{
    class MusicPlayerViewModel:ViewModelBase
    {
        private IWavePlayer waveOut;
        private MediaFoundationReader mediaReader;
        
        // Song properties
        public string Title { get; set; }
        public int Duration { get; set; }
        public string Artist { get; set; }
         
        // Player properties
        private bool _isPlaying;
        public bool IsPlaying
        {
            get => _isPlaying;
            set
            {
                _isPlaying = value;
                OnPropertyChanged();
            }
        }
        
        private bool _isMuted;
        public bool IsMuted
        {
            get => _isMuted;
            set
            {
                _isMuted = value;
                OnPropertyChanged();
                waveOut.Volume = _isMuted ? 0 : Volume;
            }
        }
        
        private float _volume;
        public float Volume
        {
            get => _volume;
            set
            {
                _volume = value;
                OnPropertyChanged();
                if (!IsMuted)
                {
                    waveOut.Volume = _volume;
                }
            }
        }

        public ICommand PlayPauseCommand => new RelayCommand(PlayPause);
        public ICommand NextCommand => new RelayCommand(Next);
        public ICommand PreviousCommand => new RelayCommand(Previous);
        public ICommand MuteCommand => new RelayCommand(Mute);

        public async void PlayPause()
        {
            if (IsPlaying)
            {
                waveOut.Pause();
                IsPlaying = false;
            }
            else
            {
                waveOut.Play();
                IsPlaying = true;
            }
        }

        public void Next()
        {
            // TODO: Implement next song logic
        }

        public void Previous()
        {
            // TODO: Implement previous song logic
        }

        public void Mute()
        {
            IsMuted = !IsMuted;
        }
        
        // TODO: Music File buffering logic

        public double Position { get; set; }
        public double BufferingProgress { get; set; }
        

    }
}

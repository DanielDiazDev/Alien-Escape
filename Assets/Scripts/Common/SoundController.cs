using System;
using System.Collections.Generic;
using UnityEngine;

namespace Common
{
    public class SoundController : MonoBehaviour
    {
        public enum SFXType
        {
            Player,
            Enemy,
            Open,
            Weapon
        }
        public enum MusicType
        {
            MainMenu,
            Game,
            Defeat,
            Victory
        }
        public static SoundController Instance;

        [Header("SFX Audio Sources")]
        [SerializeField] private List<AudioSource> _sfxSources; 

        [Header("Music Audio Sources")]
        [SerializeField] private List<AudioSource> _musicSources;

        [Range(0f, 1f)]
        [SerializeField] private float _sfxVolume;
        [SerializeField] private float _musicVolume;
        private MusicType? _currentMusic;
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        public void PlaySFX(SFXType type, AudioClip clip)
        {
            var index = (int)type; 

            if (index >= 0 && index < _sfxSources.Count && _sfxSources[index] != null && clip != null)
            {
                var source = _sfxSources[index];
                source.volume = _sfxVolume;
                source.PlayOneShot(clip);
            }
        }
        public void StopSFX(SFXType type)
        {
            var index = (int)type;

            if (index >= 0 && index < _sfxSources.Count && _sfxSources[index] != null)
            {
                var source = _sfxSources[index];
                if (source.isPlaying)
                    source.Stop();
            }
        }
        public void PlayMusic(MusicType type, AudioClip clip)
        {
            if (_currentMusic == type)
            {
                return; 
            }

            StopAllMusic(); 
            var index = (int)type;

            if (index >= 0 && index < _musicSources.Count && _musicSources[index] != null && clip != null)
            {
                var source = _musicSources[index];
                source.clip = clip;
                source.volume = _musicVolume;
                source.loop = true;
                source.Play();
                _currentMusic = type;
            }
        }

        public void StopAllMusic()
        {
            foreach (var source in _musicSources)
            {
                if (source != null && source.isPlaying)
                    source.Stop();
            }
            _currentMusic = null;
        }
    }
}
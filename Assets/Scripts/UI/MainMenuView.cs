using Common;
using Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField] private GameObject _contentView;
        [SerializeField] private GameObject _gameView;
        [SerializeField] private Button _startGameButton;
        [SerializeField] private PlayableDirector _playableDirector;
        [SerializeField] private AudioClip _audioClip;
        [SerializeField] private AudioClip _audioClip2;

        private void Start()
        {
            _startGameButton.onClick.AddListener(StartGame);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SoundController.Instance.PlayMusic(SoundController.MusicType.MainMenu, _audioClip);
        }

        private void StartGame()
        {
            _contentView.SetActive(false);
            _gameView.SetActive(true);
            _playableDirector.Play();

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false; 
            SoundController.Instance.PlayMusic(SoundController.MusicType.Game, _audioClip2);
        }
    }
}
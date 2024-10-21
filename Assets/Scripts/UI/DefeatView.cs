using Common;
using Enemy;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class DefeatView : MonoBehaviour
    {
        [SerializeField] private GameObject _contentView;
        [SerializeField] private GameObject _mainMenuView;
        [SerializeField] private Button _mainMenuButton;
        [SerializeField] private AudioClip _audioClip;
        private void Start()
        {
            CatchPlayer.OnPlayerDeathEvent += ActivateDefeatView;
            _mainMenuButton.onClick.AddListener(GoToMainMenuButton);

        }
        private void OnDestroy()
        {
            CatchPlayer.OnPlayerDeathEvent -= ActivateDefeatView;

        }
        private void ActivateDefeatView()
        {
            SoundController.Instance.PlayMusic(SoundController.MusicType.Defeat, _audioClip);
            _contentView.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        private void GoToMainMenuButton()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    
}
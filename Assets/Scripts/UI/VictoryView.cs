using Common;
using Player.Weapon;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class VictoryView : MonoBehaviour
    {
        [SerializeField] private GameObject _contentView;
        [SerializeField] private GameObject _mainMenuView;
        [SerializeField] private Button _mainMenuButton;
        [SerializeField] private AudioClip _audioClip;

        private void Start()
        {
            Projectile.OnEnemyDeathEvent += ActivateVictoryView;
            _mainMenuButton.onClick.AddListener(GoToMainMenuButton);
        }
        private void OnDestroy()
        {
            Projectile.OnEnemyDeathEvent -= ActivateVictoryView;
        }
        private void ActivateVictoryView()
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
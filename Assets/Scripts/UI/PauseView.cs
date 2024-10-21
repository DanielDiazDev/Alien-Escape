using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class PauseView : MonoBehaviour
    {
        [SerializeField] private GameObject _contentView;
        [SerializeField] private GameObject _mainMenuView;
        [SerializeField] private Button _mainMenuButton;
        [SerializeField] private Button _backButton;
        private bool _isPauseActivate;
        private void Start()
        {
            _mainMenuButton.onClick.AddListener(GoToMainMenuButton);
            _backButton.onClick.AddListener(TogglePauseView);
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                TogglePauseView();
            }
        }

        private void TogglePauseView()
        {
            if (_isPauseActivate)
            {
                _contentView.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Time.timeScale = 1;
            }
            else
            {
                _contentView.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0;
            }
            _isPauseActivate = !_isPauseActivate;
        }
        private void GoToMainMenuButton()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
}
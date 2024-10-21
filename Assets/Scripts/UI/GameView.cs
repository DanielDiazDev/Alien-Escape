using Interactions;
using Player;
using Player.Weapon;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class GameView : MonoBehaviour
    {
        [SerializeField] private Image _chargeProgressImage;
        [SerializeField] private TextMeshProUGUI _cardCountText;
        [SerializeField] private GameObject _descriptionGame;
        [SerializeField] private Button _backButton;

        private void Start()
        {
            EnergyWeapon.OnChargeTimeEvent += UpdateChargeBar;
            PlayerInventory.OnCardCountEvent += UpdateCardCount;
            DescriptionGame.OnDescriptionPressedEvent += ShowDescriptionGame;
            _backButton.onClick.AddListener(HideDescriptionPanel);
        }

        

        private void OnDestroy()
        {
            EnergyWeapon.OnChargeTimeEvent -= UpdateChargeBar;
            PlayerInventory.OnCardCountEvent -= UpdateCardCount;
            DescriptionGame.OnDescriptionPressedEvent -= ShowDescriptionGame;
        }
        private void UpdateChargeBar(float progress)
        {
            _chargeProgressImage.fillAmount = progress;
        }
        private void UpdateCardCount(int count)
        {
            _cardCountText.text = count.ToString() + "/3";
        }
        private void ShowDescriptionGame()
        {
            Cursor.lockState = CursorLockMode.None;  // Desbloquea el cursor
            Cursor.visible = true;                   // Lo hace visible
            _descriptionGame.SetActive(true);
        }
        private void HideDescriptionPanel()
        {
            // Desactivamos el cursor para el juego
            Cursor.lockState = CursorLockMode.Locked;  // Bloquea el cursor al centro
            Cursor.visible = false;                    // Oculta el cursor
            _descriptionGame.SetActive(false);
        }
    }
}
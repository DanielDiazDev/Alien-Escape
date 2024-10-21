using Enemy;
using UnityEngine;

namespace Player
{
    public class CameraLook : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private Transform _player;
        private bool _isCinematic;
        private float _rotationX = 0f;
        private bool _isPlayerDeath;
        private void Start()
        {
            CatchPlayer.OnPlayerDeathEvent += PlayerDeath;
        }

        private void PlayerDeath()
        {
            _isPlayerDeath = true;
        }

        private void Update()
        {
            if (Cursor.lockState == CursorLockMode.Locked && !_isCinematic && !_isPlayerDeath)
            {
                var mouseX = Input.GetAxis("Mouse X") * _speed * Time.deltaTime;
                var mouseY = Input.GetAxis("Mouse Y") * _speed * Time.deltaTime;

                _rotationX -= mouseY;
                _rotationX = Mathf.Clamp(_rotationX, -90f, 90f);
                transform.localRotation = Quaternion.Euler(_rotationX, 0, 0);
                _player.Rotate(Vector3.up * mouseX);
            }
        }

        public void DisableCameraMovement()
        {
            _isCinematic = true;
        }

        public void EnableCameraMovement()
        {
            _isCinematic = false;
        }
    }
}
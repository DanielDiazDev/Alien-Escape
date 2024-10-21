using Common;
using Enemy;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class MovementController : MonoBehaviour
    {
        private Vector3 _movement;
        [SerializeField] private float _speedWalk;
        [SerializeField] private float _speedSneak;
        [SerializeField] private List<AudioClip> _sfxClips;
        private Rigidbody _rigidbody;
        public static event Action<Vector3, float> OnFootstep;
        private bool _isMoving;
        private float _stepCooldown = 0.5f;
        private float _lastStepTime = 0f; 
        private bool isSneaking;
        private bool _isCinematic;
        private bool _isPlayerDeath;
        
        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            CatchPlayer.OnPlayerDeathEvent += PlayerDeath;
        }

        private void Update()
        {
            if (!_isCinematic && !_isPlayerDeath)
            {
                var horizontal = Input.GetAxis("Horizontal");
                var vertical = Input.GetAxis("Vertical");
                isSneaking = Input.GetKey(KeyCode.LeftShift);
                _movement = new Vector3(horizontal, vertical, 0);
                _isMoving = _movement.magnitude > 0;
                PlayFootstepSound(isSneaking);
            }
        }
        private void FixedUpdate()
        {
            if (_isPlayerDeath) return;
            Move();
        }

        public void Move()
        {
            var velocity = isSneaking ? _speedSneak : _speedWalk;

            _rigidbody.velocity = _movement.y * velocity * transform.forward
                + _movement.x * velocity * transform.right
                + new Vector3(0, _rigidbody.velocity.y, 0);
        }
        public void DisableMovement()
        {
            _isCinematic = true;
        }
        public void EnableMovement()
        {
            _isCinematic = false;
        }
        private void PlayFootstepSound(bool isSneaking)
        {
            if (_isMoving && Time.time >= _lastStepTime + _stepCooldown)
            {
                var clipIndex = isSneaking ? 1 : 0; 
                SoundController.Instance.PlaySFX(SoundController.SFXType.Player, _sfxClips[clipIndex]);
                var soundRange = isSneaking ? 3f : 5f;
                OnFootstep?.Invoke(transform.position, soundRange);
                _lastStepTime = Time.time; 
            }
            if (!_isMoving)
            {
                SoundController.Instance.StopSFX(SoundController.SFXType.Player);
            }
        }
        private void PlayerDeath()
        {
            _isPlayerDeath = true;
        }
    }
}

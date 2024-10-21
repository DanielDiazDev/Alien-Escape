using Common;
using Enemy;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player.Weapon
{
    public class EnergyWeapon : MonoBehaviour
    {
        [SerializeField] private GameObject _projectilePrefab; 
        [SerializeField] private Transform _firePoint; 
        [SerializeField] private AudioClip _audioClip;
        [SerializeField] private float _chargeTime;
        private float chargeProgress = 0f; 
        private bool isCharging; 
        private bool _isOver;
        public static event Action<float> OnChargeTimeEvent;
        private void Start()
        {
            CatchPlayer.OnPlayerDeathEvent += IsOver;
            Projectile.OnEnemyDeathEvent += IsOver;
        }
        private void OnDestroy()
        {
            CatchPlayer.OnPlayerDeathEvent -= IsOver;
            Projectile.OnEnemyDeathEvent -= IsOver;

        }
        void Update()
        {
            if (Input.GetButtonDown("Fire1") && !isCharging && !_isOver) 
            {
                Shoot();
            }
            if (isCharging)
            {
                ChargeWeapon();
            }
        }

        void Shoot()
        {
            Instantiate(_projectilePrefab, _firePoint.position, _firePoint.rotation);
            SoundController.Instance.PlaySFX(SoundController.SFXType.Weapon, _audioClip);
            isCharging = true;
            chargeProgress = 0.0f;
        }

        void ChargeWeapon()
        {
            chargeProgress += Time.deltaTime / _chargeTime;
            OnChargeTimeEvent?.Invoke(chargeProgress);
            if (chargeProgress >= 1.0f)
            {
                isCharging = false; 
                chargeProgress = 1.0f; 
            }
        }
        private void IsOver()
        {
            _isOver = true;
        }
    }
}
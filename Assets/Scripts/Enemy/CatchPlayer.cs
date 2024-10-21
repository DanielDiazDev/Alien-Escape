using System;
using UnityEngine;

namespace Enemy
{
    public class CatchPlayer : MonoBehaviour
    {
        [SerializeField] private Transform _player;
        [SerializeField] private float _catchRange;
        public static event Action OnPlayerDeathEvent;
        public bool IsPlayerTrapped {  get; private set; }
        private void Update()
        {
            CheckPlayerDistance();
        }
        private void CheckPlayerDistance()
        {
            if (Vector3.Distance(transform.position, _player.position) <= _catchRange)
            {
                IsPlayerTrapped = true;
            }
        }
        public void PlayerDeath()
        {
            OnPlayerDeathEvent?.Invoke();
        }
    }
}
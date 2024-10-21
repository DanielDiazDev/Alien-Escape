using System;
using UnityEngine;

namespace Player.Weapon
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float _speed;
        public static event Action OnEnemyDeathEvent;
        private void Start()
        {
            MoveProjectile();
            DestroyProjectile();
        }

        private void MoveProjectile()
        {
            var rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                var forwardDirection = transform.forward; 
                rb.velocity = forwardDirection * _speed; 
            }
        }
        private void DestroyProjectile()
        {
            Destroy(gameObject, 2);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                OnEnemyDeathEvent?.Invoke();
                Destroy(other.gameObject, 2f);
            }
            Destroy(gameObject);
        }
    }
}

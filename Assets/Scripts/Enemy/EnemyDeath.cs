using Player.Weapon;
using UnityEngine;

namespace Enemy
{
    public class EnemyDeath : MonoBehaviour
    {//
        [SerializeField] private GameObject _explosionPrefab;
        [SerializeField] private float _explosionDuration;
        private void Start()
        {
            Projectile.OnEnemyDeathEvent += Explode;
        }
        private void OnDestroy()
        {
            Projectile.OnEnemyDeathEvent -= Explode;
        }


        private void Explode()
        {
            var explosion = Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            Destroy(explosion, _explosionDuration);
        }
    }
}
using UnityEngine;

namespace Player.Weapon
{
    public class AvoidCrossWall : MonoBehaviour
    {
        public Transform weapon;  // El transform del arma
        public float wallOffset = 0.1f;  // Distancia mínima del arma con las paredes
        public float maxWeaponDistance = 1.0f;  // Distancia máxima del arma desde el jugador

        void Start()
        {
            // Asegurar que el arma empiece en la posición correcta
            weapon.localPosition = new Vector3(0, 0, maxWeaponDistance);
        }

        void Update()
        {
            RaycastHit hit;

            // Usar un SphereCast para detectar paredes con mayor precisión
            if (Physics.SphereCast(transform.position, 0.2f, transform.forward, out hit, maxWeaponDistance))
            {
                // Si detecta un obstáculo, ajustar la posición del arma
                float distance = hit.distance - wallOffset;
                weapon.localPosition = new Vector3(0, 0, Mathf.Max(0, distance));
            }
            else
            {
                // Restaurar la posición del arma si no hay obstáculos
                weapon.localPosition = new Vector3(0, 0, maxWeaponDistance);
            }
        }
    }
}
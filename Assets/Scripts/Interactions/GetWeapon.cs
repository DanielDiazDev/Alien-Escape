using Player.Weapon;
using UnityEngine;

namespace Interactions
{
    public class GetWeapon : MonoBehaviour, IInteractable
    {
        [SerializeField] private GameObject _weapon;
        public void Interact()
        {
            _weapon.SetActive(true);
            Destroy(gameObject);
        }
    }
}
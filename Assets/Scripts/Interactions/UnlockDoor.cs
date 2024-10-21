using UnityEngine;

namespace Interactions
{
    public abstract class UnlockDoor : MonoBehaviour, IInteractable
    {
        [SerializeField] protected GameObject _target;
        [SerializeField] protected AudioClip _clip;
        public abstract void Interact();
    }

}
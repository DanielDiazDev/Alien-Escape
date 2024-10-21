using Common;
using Interactions;
using UnityEngine;

namespace Player
{
    public class PlayerInteractor : MonoBehaviour
    {
        [SerializeField] private AudioClip _clip;
        [SerializeField] private float _interactDistance;
        private Camera _camera;
        private void Start()
        {
            _camera = GetComponentInChildren<Camera>();
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                TryInteractWithCard();
            }
        }

        private void TryInteractWithCard()
        {
            var ray = new Ray(_camera.transform.position, _camera.transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, _interactDistance))
            {
                var interactable = hit.collider.GetComponent<IInteractable>();
                if (interactable != null)
                {
                    interactable.Interact();
                    SoundController.Instance.PlaySFX(SoundController.SFXType.Open, _clip);
                }
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, _interactDistance);
        }
    }
}

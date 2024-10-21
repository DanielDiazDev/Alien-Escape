using Player;
using UnityEngine;

namespace Interactions
{
    public class CardId : MonoBehaviour, IInteractable
    {
        public void Interact()
        {
              PlayerInventory.Instance.AddCard();
              Destroy(gameObject);
        }
        
    }
}
using System;
using UnityEngine;

namespace Interactions
{
    public class DescriptionGame : MonoBehaviour, IInteractable
    {
        public static event Action OnDescriptionPressedEvent;
        public void Interact()
        {
            OnDescriptionPressedEvent?.Invoke();
        }
    }
}
using System;
using UnityEngine;

namespace Player
{
    public class PlayerInventory : MonoBehaviour
    {
        public static PlayerInventory Instance;
        private int _cardCount = 0;
        public static event Action<int> OnCardCountEvent;
        private void Awake()
        {
            // Asegurar que solo hay una instancia de PlayerInventory
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);  // Persistir entre escenas
            }
            else
            {
                Destroy(gameObject);
            }
        }
        public void AddCard()
        {
            _cardCount++;
            OnCardCountEvent?.Invoke(_cardCount);
        }
        public bool HasAllCards()
        {
            return _cardCount == 3;
        }
    }
}

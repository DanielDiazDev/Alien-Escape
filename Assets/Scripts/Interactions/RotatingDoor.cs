using System;
using System.Collections;
using UnityEngine;

namespace Interactions
{
    public class RotatingDoor : MonoBehaviour
    {
        [SerializeField] private Transform _door; 
        [SerializeField] private float _openZPosition;
        [SerializeField] private float _openAngle;
        [SerializeField] private float _speed;
        public static event Action<Vector3, float> OnDoorOpen;

        private Vector3 _closedPosition;  
        private bool _isOpen = false;  

        void Start()
        {
            _closedPosition = _door.position;
        }

        public void OpenDoor()
        {
            if (!_isOpen)
            {
                var openPosition = new Vector3(_closedPosition.x, _closedPosition.y, _openZPosition);
                var openRotation = Quaternion.Euler(_door.eulerAngles.x, _door.eulerAngles.y + _openAngle, _door.eulerAngles.z); 
                StartCoroutine(MoveAndRotateDoor(openPosition, openRotation)); 
            }
        }
        private IEnumerator MoveAndRotateDoor(Vector3 targetPosition, Quaternion targetRotation)
        {
            _isOpen = !_isOpen; 
            var elapsedTime = 0f;

            OnDoorOpen?.Invoke(transform.position, 15f);

            var initialPosition = _door.position;
            var initialRotation = _door.rotation;

            while (elapsedTime < 1f)
            {
                var t = elapsedTime / 1f;  
                _door.position = new Vector3(initialPosition.x, initialPosition.y, Mathf.Lerp(initialPosition.z, targetPosition.z, t));
                _door.rotation = Quaternion.Lerp(initialRotation, targetRotation, elapsedTime);
                elapsedTime += Time.deltaTime * _speed;
                yield return null;
            }
            _door.position = targetPosition;
            _door.rotation = targetRotation;
        }
    }
}

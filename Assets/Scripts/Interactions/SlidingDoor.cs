using System;
using System.Collections;
using UnityEngine;

namespace Interactions
{
    public class SlidingDoor : MonoBehaviour
    {
        [SerializeField] private Transform _leftDoor;
        [SerializeField] private Transform _rightDoor;
        [SerializeField] private Vector3 _leftDoorDirection = new Vector3(-1, 0, 0); 
        [SerializeField] private Vector3 _rightDoorDirection = new Vector3(1, 0, 0);
        [SerializeField] private float _openDistance;// = 1f;
        [SerializeField] private float _speed;// = 2f;
        public static event Action<Vector3, float> OnDoorOpen;
        private Vector3 _leftClosedPosition;
        private Vector3 _leftOpenPosition;
        private Vector3 _rightClosedPosition;
        private Vector3 _rightOpenPosition;
        private bool _isOpen;

        void Start()
        {
            _leftClosedPosition = _leftDoor.position;
            _rightClosedPosition = _rightDoor.position;

            _leftOpenPosition = _leftClosedPosition + (_leftDoorDirection.normalized * _openDistance);
            _rightOpenPosition = _rightClosedPosition + (_rightDoorDirection.normalized * _openDistance);
        }

        public void OpenDoor()
        {
            if (!_isOpen)
            {
                StartCoroutine(OpenDoors());
            }
            
        }

        private IEnumerator OpenDoors()
        {
            _isOpen = true;
            var elapsedTime = 0f;
            OnDoorOpen?.Invoke(transform.position, 15f);
            while (elapsedTime < 1f)
            {
                _leftDoor.position = Vector3.Lerp(_leftClosedPosition, _leftOpenPosition, elapsedTime);
                _rightDoor.position = Vector3.Lerp(_rightClosedPosition, _rightOpenPosition, elapsedTime);
                elapsedTime += Time.deltaTime * _speed;
                yield return null;
            }

            _leftDoor.position = _leftOpenPosition;
            _rightDoor.position = _rightOpenPosition;
        }
    }
}

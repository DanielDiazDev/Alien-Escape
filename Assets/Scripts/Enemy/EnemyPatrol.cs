using Common;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class EnemyPatrol : MonoBehaviour
    {
        [SerializeField] private Transform[] _patrolPoints;
        [SerializeField] private float _waitTime;
        [SerializeField] private AudioClip _clipSFX;
        private NavMeshAgent _agent;
        private int _currentPointIndex = 0;
        private float _waitCounter;
        private bool _isWaiting;

        public void StartPatrol()
        {
            _agent = GetComponent<NavMeshAgent>();
            if (_patrolPoints.Length > 0)
            {
                _agent.SetDestination(_patrolPoints[_currentPointIndex].position);
            }
        }

        public void HandlePatrol()
        {
            if (!_agent.pathPending && _agent.remainingDistance < 0.5f)
            {
                if (!_isWaiting)
                {
                    SoundController.Instance.StopSFX(SoundController.SFXType.Enemy);

                    _isWaiting = true;
                    _waitCounter = _waitTime;
                }
                else
                {
                    _waitCounter -= Time.deltaTime;
                    if (_waitCounter <= 0f)
                    {
                        MoveToNextPoint();
                    }
                }
            }
        }

        private void MoveToNextPoint()
        {
            SoundController.Instance.PlaySFX(SoundController.SFXType.Enemy, _clipSFX);
            _currentPointIndex = (_currentPointIndex + 1) % _patrolPoints.Length;
            _agent.SetDestination(_patrolPoints[_currentPointIndex].position);
            _isWaiting = false;
        }
    }
}
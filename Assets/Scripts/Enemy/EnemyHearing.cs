using Interactions;
using Player;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class EnemyHearing : MonoBehaviour
    {
        [SerializeField] private float _hearingRange;
        [SerializeField] private float _hearingCooldown;
        private NavMeshAgent _agent;
        public bool IsHearingSound {  get; private set; }
        
        private float _hearingTimer;

        private void OnEnable()
        {
            MovementController.OnFootstep += OnSoundHeard;
            SlidingDoor.OnDoorOpen += OnSoundHeard;
        }

        private void OnDisable()
        {
            MovementController.OnFootstep -= OnSoundHeard;
            SlidingDoor.OnDoorOpen -= OnSoundHeard;
        }

        void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
        }

        void Update()
        {
            if (IsHearingSound)
            {
                _hearingTimer += Time.deltaTime;
                if (_hearingTimer >= _hearingCooldown)
                {
                    ReturnToPatrol();
                }
            }
        }

        private void OnSoundHeard(Vector3 soundPosition, float soundRange)
        {
            var distanceToSound = Vector3.Distance(transform.position, soundPosition);

            if (distanceToSound <= soundRange && distanceToSound <= _hearingRange)
            {
                _agent.SetDestination(soundPosition);
                IsHearingSound = true;
                _hearingTimer = 0;
            }
        }

        private void ReturnToPatrol()
        {
            IsHearingSound = false;
        }
    }
}

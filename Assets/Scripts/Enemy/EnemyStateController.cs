using Enemy.States;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class EnemyStateController : MonoBehaviour
    {
        private IEnemyState _currentState;
        public EnemyPatrol Patrol { get; private set; }
        public EnemyHearing Hearing { get; private set; }
        public CatchPlayer CatchPlayer { get; private set; }
        public NavMeshAgent Agent { get; private set; }
        public void Init()
        {
            Patrol = GetComponent<EnemyPatrol>();
            Hearing = GetComponent<EnemyHearing>();
            CatchPlayer = GetComponent<CatchPlayer>();
            Agent = GetComponent<NavMeshAgent>();
            SwithState(new PatrollingState(this));
        }
        private void Update()
        {
            if(_currentState != null)
            {
                _currentState.Update();
            }
        }
        public void SwithState(IEnemyState newState)
        {
            _currentState?.Exit();
            _currentState = newState;
            _currentState.Start();
        }
    }
}


namespace Enemy.States
{
    public class PatrollingState : IEnemyState
    {
        private EnemyStateController _enemyStateController;

        public PatrollingState(EnemyStateController enemyStateController)
        {
            _enemyStateController = enemyStateController;
        }

        public void Start()
        {
            _enemyStateController.Patrol.StartPatrol();
        }

        public void Update()
        {
            if (_enemyStateController.Hearing.IsHearingSound)
            {
                _enemyStateController.SwithState(new ChasingSoundState(_enemyStateController));
            }
            else if (_enemyStateController.CatchPlayer.IsPlayerTrapped)
            {
                _enemyStateController.SwithState(new CatchState(_enemyStateController));
            }
            else
            {
                _enemyStateController.Patrol.HandlePatrol();
            }
        }
        public void Exit()
        {
        }
    }

}
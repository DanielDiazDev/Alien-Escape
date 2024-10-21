namespace Enemy.States
{
    public class ChasingSoundState : IEnemyState
    {
        private EnemyStateController _enemyStateController;
        public ChasingSoundState(EnemyStateController enemyStateController)
        {
            _enemyStateController = enemyStateController;
        }

        public void Start()
        {
            _enemyStateController.Agent.speed = 8f; 
        }

        public void Update()
        {
            if (!_enemyStateController.Hearing.IsHearingSound)
            {
                _enemyStateController.SwithState(new PatrollingState(_enemyStateController));
            }
            if (_enemyStateController.CatchPlayer.IsPlayerTrapped)
            {
                _enemyStateController.SwithState(new CatchState(_enemyStateController));
            }
        }
        public void Exit()
        {
            _enemyStateController.Agent.speed = 3.5f; 
        }
    }
}
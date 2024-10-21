namespace Enemy.States
{
    public class CatchState : IEnemyState
    {
        private EnemyStateController _enemyStateController;

        public CatchState(EnemyStateController enemyStateController)
        {
            _enemyStateController = enemyStateController;
        }
        public void Start()
        {
            _enemyStateController.Agent.isStopped = true; 
        }
        public void Update()
        {
            _enemyStateController.CatchPlayer.PlayerDeath();
        }
        public void Exit()
        {
            
        }
    }
}
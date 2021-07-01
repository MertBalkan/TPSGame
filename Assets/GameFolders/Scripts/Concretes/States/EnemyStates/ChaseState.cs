using TPSGame.Abstracts.Controllers;
using TPSGame.Abstracts.States;
using UnityEngine;

namespace TPSGame.Concretes.States
{
    public class ChaseState : IState
    {
        private IEnemyController _enemyController;
        private float _moveSpeed = 10.0f;
        public ChaseState(IEnemyController enemyController)
        {
            _enemyController = enemyController;
        }
        public void OnEnter()
        {
            Debug.Log("Chase State enter");
        }

        public void OnExit()
        {
            Debug.Log("Chase State exit");
            _enemyController.Mover.MoveAction(_enemyController.transform.position, 0.0f);
        }

        public void Tick()
        {
            _enemyController.Mover.MoveAction(_enemyController.Target.position, _moveSpeed);
        }

        public void TickFixed()
        {
            
        }

        public void TickLate()
        {
            _enemyController.CharacterAnimation.MoveAnimation(_enemyController.NavMeshAgent.velocity.magnitude);
        }
    }
}
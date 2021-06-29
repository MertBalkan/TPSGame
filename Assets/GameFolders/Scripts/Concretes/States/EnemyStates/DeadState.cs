using TPSGame.Abstracts.Controllers;
using TPSGame.Abstracts.States;
using UnityEngine;

namespace TPSGame.Concretes.States
{
    public class DeadState : IState
    {
        private IEnemyController _enemyController;

        public DeadState(IEnemyController enemyController)
        {
            _enemyController = enemyController;
        }

        public void OnEnter()
        {
            Debug.Log("Dead State enter");
        }

        public void OnExit()
        {
            Debug.Log("Dead State exit");
        }

        public void Tick()
        {
            GameObject.Destroy(_enemyController.transform.gameObject);
        }

        public void TickFixed()
        {
            
        }

        public void TickLate()
        {

        }
    }
}
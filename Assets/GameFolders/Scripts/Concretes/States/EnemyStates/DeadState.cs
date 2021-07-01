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
            _enemyController.Dead.DeadAction();
            _enemyController.CharacterAnimation.DeadAnimation();
            _enemyController.transform.GetComponent<CapsuleCollider>().enabled = false;
        }

        public void OnExit()
        {
            Debug.Log("Dead State exit");
        }

        public void Tick()
        {

        }

        public void TickFixed()
        {
            
        }

        public void TickLate()
        {

        }
    }
}
using System.Collections;
using System.Collections.Generic;
using TPSGame.Abstracts.Controllers;
using TPSGame.Abstracts.States;
using UnityEngine;

namespace TPSGame.Concretes.States
{
    public class AttackState : IState
    {
        private IEnemyController _enemyController;
        public AttackState(IEnemyController enemyController)
        {
            _enemyController = enemyController;
        }
        public void OnEnter()
        {
            Debug.Log("Attack State enter");
        }

        public void OnExit()
        {
            _enemyController.CharacterAnimation.AttackAnimation(false);
        }

        public void Tick()
        {
            Debug.Log("Attack State Tick");
        }

        public void TickFixed()
        {
            _enemyController.Inventory.CurrentWeapon.Attack();
        }
        public void TickLate()
        {
            _enemyController.CharacterAnimation.AttackAnimation(true);
        }
    }
}

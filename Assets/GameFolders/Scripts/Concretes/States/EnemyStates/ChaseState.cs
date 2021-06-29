using TPSGame.Abstracts.Controllers;
using TPSGame.Abstracts.States;
using UnityEngine;

namespace TPSGame.Concretes.States
{
    public class ChaseState : IState
    {
        private IEntityController _entityController;
        private Transform _target;
        private float _moveSpeed = 10.0f;
        public ChaseState(IEntityController entityController, Transform target)
        {
            _entityController = entityController;
            _target = target;
        }
        public void OnEnter()
        {
            Debug.Log("Chase State enter");
        }

        public void OnExit()
        {
            Debug.Log("Chase State exit");
        }

        public void Tick()
        {
            _entityController.Mover.MoveAction(_target.position, _moveSpeed);
        }
    }
}
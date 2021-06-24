using System.Collections;
using System.Collections.Generic;
using TPSGame.Abstracts.Controllers;
using TPSGame.Abstracts.Movements;
using TPSGame.Concretes.Controllers;
using UnityEngine;

namespace TPSGame.Concretes.Movements
{
    public class MoveWithCharacterController : IMover
    {
        private CharacterController _characterController;

        public MoveWithCharacterController(IEntityController entityController)
        {
            _characterController = entityController.transform.GetComponent<CharacterController>();
        }

        public void MoveAction(Vector3 direction, float moveSpeed)
        {
            if (direction == Vector3.zero) return;

            Vector3 worldPosition = _characterController.transform.TransformDirection(direction);
            Vector3 movement = worldPosition * moveSpeed * Time.deltaTime;

            _characterController.Move(movement);
        }
    }
}
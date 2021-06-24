using System.Collections;
using System.Collections.Generic;
using TPSGame.Abstracts.Movements;
using TPSGame.Concretes.Controllers;
using UnityEngine;

namespace TPSGame.Concretes.Movements
{
    public class RotatorX : IRotator
    {
        private PlayerController _playerController;

        public RotatorX(PlayerController playerController)
        {
            _playerController = playerController;
        }

        public void RotationAction(float direction, float speed)
        {
            _playerController.transform.Rotate(Vector3.up * direction * speed * Time.deltaTime);
        }
    }
}
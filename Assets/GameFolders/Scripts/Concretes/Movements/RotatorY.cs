using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TPSGame.Abstracts.Movements;
using TPSGame.Concretes.Controllers;
using UnityEngine;

namespace TPSGame.Concretes.Movements
{
    public class RotatorY : IRotator
    {
        private Transform _transform;
        private float _tilt;

        public RotatorY(PlayerController playerController)
        {
            _transform = playerController.TurnTransform;
        }

        public void RotationAction(float direction, float speed)
        {
            direction *= speed * Time.deltaTime;
            _tilt = Mathf.Clamp(_tilt - direction, -30f, 30f);
            _transform.localRotation = Quaternion.Euler(_tilt, 0f, 0f);
        }
    }
}
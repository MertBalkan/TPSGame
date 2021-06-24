using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TPSGame.Concretes.Movements
{
    [RequireComponent(typeof(CharacterController))]
    public class Gravity : MonoBehaviour
    {
        [SerializeField] private float _gravity = -9.81f;
        private CharacterController _characterController;
        private Vector3 _velocity;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            if (_characterController.isGrounded) _velocity.y = 0f;
            _velocity.y += _gravity * Time.deltaTime;

            _characterController.Move(_velocity * Time.deltaTime);
        }
    }
}
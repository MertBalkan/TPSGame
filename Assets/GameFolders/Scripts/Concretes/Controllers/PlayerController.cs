using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TPSGame.Abstracts.Inputs;
using TPSGame.Abstracts.Movements;
using TPSGame.Concretes.Movements;
using TPSGame.Concretes.Animations;

namespace TPSGame.Concretes.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Movement Informations")]
        [SerializeField] private float _moveSpeed = 10.0f;
        [SerializeField] private float _turnSpeed = 10.0f;

        [SerializeField] private Transform _turnTransform;

        private IInputReader _input;
        private IMover _mover;
        private IRotator _xRotator;
        private IRotator _yRotator;

        private CharacterAnimation _animation;

        private Vector3 _direction;

        public Transform TurnTransform => _turnTransform;

        private void Awake() {
            _input = GetComponent<IInputReader>();

            _mover = new MoveWithCharacterController(this);

            _animation = new CharacterAnimation(this);

            _xRotator = new RotatorX(this);
            _yRotator = new RotatorY(this);
        }

        private void Update() {
            _direction = _input.Direction;

            _xRotator.RotationAction(_input.Rotation.x, _turnSpeed);
            _yRotator.RotationAction(_input.Rotation.y, _turnSpeed);
        }

        private void FixedUpdate()
        {
            _mover.MoveAction(_direction, _moveSpeed);

        }

        private void LateUpdate()
        {
            _animation.MoveAnimation(_direction.magnitude);
        }
    }
}
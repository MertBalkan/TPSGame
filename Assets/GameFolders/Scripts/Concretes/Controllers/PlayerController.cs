using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TPSGame.Abstracts.Inputs;
using TPSGame.Abstracts.Movements;
using TPSGame.Concretes.Movements;
using TPSGame.Concretes.Animations;
using TPSGame.Abstracts.Controllers;

namespace TPSGame.Concretes.Controllers
{
    public class PlayerController : MonoBehaviour, IEntityController
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
        private InventoryController _inventory;
        private Vector3 _direction;

        public Transform TurnTransform => _turnTransform;

        private void Awake()
        {
            _input = GetComponent<IInputReader>();
            _mover = new MoveWithCharacterController(this);
            _animation = new CharacterAnimation(this);
            _inventory = GetComponent<InventoryController>();

            _xRotator = new RotatorX(this);
            _yRotator = new RotatorY(this);
        }

        private void Update()
        {
            _direction = _input.Direction;

            _xRotator.RotationAction(_input.Rotation.x, _turnSpeed);
            _yRotator.RotationAction(_input.Rotation.y, _turnSpeed);

            if (_input.IsAttackButtonPressed)
            {
                _inventory.CurrentWeapon.Attack();
            }

            if (_input.IsInventoryButtonPressed)
            {
                _inventory.ChangeWeapon();
            }
        }

        private void FixedUpdate()
        {
            _mover.MoveAction(_direction, _moveSpeed);
        }

        private void LateUpdate()
        {
            _animation.MoveAnimation(_direction.magnitude);
            _animation.AttackAnimation(_input.IsAttackButtonPressed);
        }
    }
}
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

        private IInputReader _input;
        private IMover _mover;

        private CharacterAnimation _animation;

        private Vector3 _direction;

        private void Awake() {
            _input = GetComponent<IInputReader>();
            _mover = new MoveWithCharacterController(this);
            _animation = new CharacterAnimation(this);
        }

        private void Update() {
            _direction = _input.Direction;
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
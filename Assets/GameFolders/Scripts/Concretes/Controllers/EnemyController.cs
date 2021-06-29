using System.Collections;
using System.Collections.Generic;
using TPSGame.Abstracts.Combats;
using TPSGame.Abstracts.Controllers;
using TPSGame.Abstracts.Movements;
using TPSGame.Concretes.Animations;
using TPSGame.Concretes.Movements;
using TPSGame.Concretes.States;
using UnityEngine;
using UnityEngine.AI;

namespace TPSGame.Concretes.Controllers
{
    public class EnemyController : MonoBehaviour, IEntityController
    {
        [SerializeField] private Transform _playerPrefab;

        private IMover _mover;
        private IHealth _health;
        private CharacterAnimation _animation;
        private NavMeshAgent _navMeshAgent;
        private InventoryController _inventoryController;
        private StateMachine _stateMachine;
        private Transform _playerTransform;
        private bool _canAttack;

        public bool CanAttack => Vector3.Distance(_playerTransform.position, this.transform.position) <= _navMeshAgent.stoppingDistance && _navMeshAgent.velocity == Vector3.zero;

        private void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _mover = new MoveWithNavMesh(this);
            _animation = new CharacterAnimation(this);
            _health = GetComponent<IHealth>();
            _inventoryController = GetComponent<InventoryController>();
            _stateMachine = new StateMachine();
        }
        private void Start()
        {
            _playerTransform = FindObjectOfType<PlayerController>().transform;

            AttackState attackState = new AttackState();
            ChaseState chaseState = new ChaseState();
            DeadState deadState = new DeadState();

            _stateMachine.AddState(attackState, chaseState, () => !CanAttack);
            _stateMachine.AddState(chaseState, attackState, () => CanAttack);
            _stateMachine.AddAnyState(deadState, () => _health.IsDead);
            
            _stateMachine.SetState(chaseState);
        }
        private void Update()
        {
            if (_health.IsDead) return;
            _mover.MoveAction(_playerTransform.position, 10f);

            _stateMachine.Tick();
        }
        private void FixedUpdate()
        {
            if (_canAttack)
            {
                _inventoryController.CurrentWeapon.Attack();
            }
        }
        private void LateUpdate()
        {
            _animation.MoveAnimation(_navMeshAgent.velocity.magnitude);
            _animation.AttackAnimation(_canAttack);
        }
    }
}
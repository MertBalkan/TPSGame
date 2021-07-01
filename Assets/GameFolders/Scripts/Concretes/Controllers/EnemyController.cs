using System.Collections;
using System.Collections.Generic;
using TPSGame.Abstracts.Combats;
using TPSGame.Abstracts.Controllers;
using TPSGame.Abstracts.Movements;
using TPSGame.Concretes.Animations;
using TPSGame.Concretes.Combats;
using TPSGame.Concretes.Movements;
using TPSGame.Concretes.States;
using UnityEngine;
using UnityEngine.AI;

namespace TPSGame.Concretes.Controllers
{
    public class EnemyController : MonoBehaviour, IEnemyController
    {
        [SerializeField] private Transform _playerPrefab;

        private IHealth _health;
        private StateMachine _stateMachine;
        private bool _canAttack;
        public bool CanAttack => Vector3.Distance(Target.position, this.transform.position) <= NavMeshAgent.stoppingDistance && NavMeshAgent.velocity == Vector3.zero;
        public IMover Mover { get; private set; }
        public InventoryController Inventory { get; private set; }
        public CharacterAnimation CharacterAnimation { get; private set; }
        public NavMeshAgent NavMeshAgent { get; private set; }
        public Transform Target { get; set; }

        public Dead Dead { get; private set; }

        private void Awake()
        {
            _health = GetComponent<IHealth>();
            _stateMachine = new StateMachine();

            Inventory = GetComponent<InventoryController>();
            Mover = new MoveWithNavMesh(this);
            CharacterAnimation = new CharacterAnimation(this);
            NavMeshAgent = GetComponent<NavMeshAgent>();
            Dead = GetComponent<Dead>();
        }
        private void Start()
        {
            Target = FindObjectOfType<PlayerController>().transform;

            ChaseState chaseState = new ChaseState(this);
            AttackState attackState = new AttackState(this);
            DeadState deadState = new DeadState(this);

            _stateMachine.AddState(attackState, chaseState, () => !CanAttack);
            _stateMachine.AddState(chaseState, attackState, () => CanAttack);
            _stateMachine.AddAnyState(deadState, () => _health.IsDead);

            _stateMachine.SetState(chaseState);
        }
        private void Update()
        {
            if (_health.IsDead) return;

            _stateMachine.Tick();
        }
        private void FixedUpdate()
        {
            _stateMachine.TickFixed();
        }
        private void LateUpdate()
        {
            _stateMachine.TickLate();
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using TPSGame.Abstracts.Combats;
using TPSGame.Abstracts.Controllers;
using TPSGame.Abstracts.Movements;
using TPSGame.Concretes.Animations;
using TPSGame.Concretes.Movements;
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
        private Transform _playerTransform;
        private bool _canAttack;

        private void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _mover = new MoveWithNavMesh(this);
            _animation = new CharacterAnimation(this);
            _health = GetComponent<IHealth>();
            _inventoryController = GetComponent<InventoryController>();
        }
        private void Start()
        {
            _playerTransform = FindObjectOfType<PlayerController>().transform;
        }
        private void Update()
        {
            if (_health.IsDead) return;
            _mover.MoveAction(_playerTransform.position, 10f);
            _canAttack = Vector3.Distance(_playerTransform.position, this.transform.position) <= _navMeshAgent.stoppingDistance && _navMeshAgent.velocity == Vector3.zero;
            Debug.Log(_canAttack);
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
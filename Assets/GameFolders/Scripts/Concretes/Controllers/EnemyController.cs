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

        private void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _mover = new MoveWithNavMesh(this);
            _animation = new CharacterAnimation(this);
            _health = GetComponent<IHealth>();
        }

        private void Update()
        {
            if (_health.IsDead) return;
            _mover.MoveAction(_playerPrefab.transform.position, 10f);
        }

        private void LateUpdate()
        {
            _animation.MoveAnimation(_navMeshAgent.velocity.magnitude);
        }
    }
}
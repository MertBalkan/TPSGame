using System.Collections;
using System.Collections.Generic;
using TPSGame.Abstracts.Controllers;
using TPSGame.Abstracts.Movements;
using TPSGame.Concretes.Movements;
using UnityEngine;

namespace TPSGame.Concretes.Controllers
{
    public class EnemyController : MonoBehaviour, IEntityController
    {
        [SerializeField] private Transform _playerPrefab;

        private IMover _mover;

        private void Awake()
        {
            _mover = new MoveWithNavMesh(this);
        }

        private void Update()
        {
            _mover.MoveAction(_playerPrefab.transform.position, 10f);
        }
    }
}
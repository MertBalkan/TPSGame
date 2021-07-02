using System.Collections;
using System.Collections.Generic;
using TPSGame.Abstracts.Utilities;
using TPSGame.Concretes.Controllers;
using UnityEngine;

namespace TPSGame.Concretes.Managers
{
    public class EnemyManager : SingletonMonoBehaviour<EnemyManager>
    {
        [SerializeField] private int _maxEnemyCount = 50;
        [SerializeField] private List<EnemyController> _enemies;

        public bool CanSpawn => _maxEnemyCount > _enemies.Count;

        private void Awake()
        {
            SingletonMethod(this);
            _enemies = new List<EnemyController>();
        }
        public void AddEnemyController(EnemyController enemyController)
        {
            enemyController.transform.parent = this.transform;
            _enemies.Add(enemyController);
        }
        public void RemoveEnemyController(EnemyController enemyController)
        {
            _enemies.Remove(enemyController);
            GameManager.Instance.DecreaseWaveCount();
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using TPSGame.Concretes.Managers;
using TPSGame.Concretes.ScriptableObjects;
using UnityEngine;

namespace TPSGame.Concretes.Controllers
{
    public class SpawnerController : MonoBehaviour
    {
        [SerializeField] private SpawnScriptableObject _spawnScriptableObject;
        [SerializeField] private float _maxTime;
        private float _currentTime = 0.0f;

        private void Start()
        {
            _maxTime = _spawnScriptableObject.RandomSpawnMaxTime;
        }

        private void Update()
        {
            _currentTime += Time.deltaTime;
            if (_currentTime > _maxTime && EnemyManager.Instance.CanSpawn) Spawn();
        }
        void Spawn()
        {
            EnemyController enemyController = Instantiate(_spawnScriptableObject.EnemyPrefab,
                        transform.position,
                        Quaternion.identity);

            EnemyManager.Instance.AddEnemyController(enemyController);

            _currentTime = 0.0f;
            _maxTime = _spawnScriptableObject.RandomSpawnMaxTime;
        }
    }
}
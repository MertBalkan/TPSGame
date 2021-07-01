using System.Collections;
using System.Collections.Generic;
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
            if(_currentTime > _maxTime) Spawn();
        }
        void Spawn()
        {
            Instantiate(_spawnScriptableObject.EnemyPrefab,
                        transform.position,
                        Quaternion.identity);
            _currentTime = 0.0f;
            _maxTime = _spawnScriptableObject.RandomSpawnMaxTime;
        }
    }
}
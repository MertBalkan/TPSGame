using System.Collections;
using System.Collections.Generic;
using TPSGame.Concretes.Controllers;
using UnityEngine;

namespace TPSGame.Concretes.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Combat/Spawn Data", menuName = "Combat/Spawn Data")]
    public class SpawnScriptableObject : ScriptableObject
    {
        [SerializeField] private EnemyController _enemyPrefab;
        [SerializeField] private float _minSpawnTime = 3.0f;
        [SerializeField] private float _maxSpawnTime = 15.0f;
        
        public EnemyController EnemyPrefab => _enemyPrefab;
        public float RandomSpawnMaxTime => Random.Range(_minSpawnTime, _maxSpawnTime);
    }
}

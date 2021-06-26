using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TPSGame.Concretes.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Attack Data", menuName = "Attack Data")]
    public class AttackScriptableObject : ScriptableObject
    { 
        [SerializeField] private float _distance = 100f;
        [SerializeField] private int _damage = 10;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private float _maxAttackDelay = 0.25f;

        public float Distance => _distance;
        public int Damage => _damage;
        public LayerMask LayerMask => _layerMask;

        public float MaxAttackDelay => _maxAttackDelay;
    }
}
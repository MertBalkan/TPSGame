using System.Collections;
using System.Collections.Generic;
using TPSGame.Abstracts.Combats;
using TPSGame.Concretes.Combats;
using UnityEngine;

namespace TPSGame.Concretes.ScriptableObjects
{
    enum AttackTypeEnum
    {
        Range, Melee
    }

    [CreateAssetMenu(fileName = "Attack Data", menuName = "Attack Data")]
    public class AttackScriptableObject : ScriptableObject
    {
        [SerializeField] private AttackTypeEnum _attackType;
        [SerializeField] private float _distance = 100f;
        [SerializeField] private int _damage = 10;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private float _maxAttackDelay = 0.25f;

        public float Distance => _distance;
        public int Damage => _damage;
        public LayerMask LayerMask => _layerMask;
        public float MaxAttackDelay => _maxAttackDelay;

        public IAttackType GetAttackType(Transform transform)
        {
            if(_attackType == AttackTypeEnum.Range)
                return new RangeAttackType(transform, this);
            else
                return new MeleeAttackType(transform, this);
        }
    }
}
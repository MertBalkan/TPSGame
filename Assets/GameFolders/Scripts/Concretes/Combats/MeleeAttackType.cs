using System.Collections;
using System.Collections.Generic;
using TPSGame.Abstracts.Combats;
using TPSGame.Concretes.ScriptableObjects;
using UnityEngine;

namespace TPSGame.Concretes.Combats
{
    public class MeleeAttackType : IAttackType
    {
        private Transform _transformObject;
        private AttackScriptableObject _attackScriptableObject;

        public MeleeAttackType(Transform transformObject, AttackScriptableObject attackScriptableObject)
        {
            _transformObject = transformObject;
            _attackScriptableObject = attackScriptableObject;
        }

        public void AttackAction()
        {
            Vector3 attackPoint = _transformObject.position;
            Collider[] colliders = Physics.OverlapSphere(attackPoint,
            _attackScriptableObject.Distance,
            _attackScriptableObject.LayerMask);

            foreach (Collider collider in colliders)
            {
                IHealth health = collider.GetComponent<IHealth>();
                health?.TakeDamage(_attackScriptableObject.Damage);
            }
        }
    }
}

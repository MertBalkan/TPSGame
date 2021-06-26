using System.Collections;
using System.Collections.Generic;
using TPSGame.Abstracts.Combats;
using TPSGame.Concretes.ScriptableObjects;
using UnityEngine;

namespace TPSGame.Concretes.Combats
{
    public class RangeAttackType : IAttackType
    {
        private Camera _camera;
        private AttackScriptableObject _attackScriptableObject;

        public RangeAttackType(Transform transformObject, AttackScriptableObject attackScriptableObject)
        {
            _camera = transformObject.GetComponent<Camera>();
            _attackScriptableObject = attackScriptableObject;
        }

        public void AttackAction()
        {
            Ray ray = _camera.ViewportPointToRay(Vector3.one / 2f);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, _attackScriptableObject.Distance, _attackScriptableObject.LayerMask))
            {
                IHealth health = hit.collider.GetComponent<IHealth>();
                health?.TakeDamage(_attackScriptableObject.Damage);
            }
        }
    }
}
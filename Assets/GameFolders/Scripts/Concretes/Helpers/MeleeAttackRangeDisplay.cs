using System.Collections;
using System.Collections.Generic;
using TPSGame.Concretes.ScriptableObjects;
using UnityEngine;

namespace TPSGame.Concretes.Helpers
{
    public class MeleeAttackRangeDisplay : MonoBehaviour
    {
        [SerializeField] private float _radius = 1.0f;

        private void OnDrawGizmos()
        {
            OnDrawGizmosSelected();
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(this.transform.position, _radius);
        }
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TPSGame.Concretes.Combats
{
    public class Dead : MonoBehaviour
    {
        [SerializeField] private float _delayTime = 5.0f;
        public void DeadAction()
        {
            StartCoroutine(DeadActionAsync());
        }
        private IEnumerator DeadActionAsync()
        {
            yield return new WaitForSeconds(_delayTime);
            Destroy(this.gameObject);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TPSGame.Concretes.Controllers
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] private bool _canFire;

        [SerializeField] private float _maxAttackDelay = 0.25f;
        [SerializeField] private float _distance = 100f;

        [SerializeField] private Camera _camera;

        [SerializeField] private LayerMask _layerMask;

        private float _currentTime = 0f;

        private void Update()
        {
            _currentTime += Time.deltaTime;
            _canFire = _currentTime > _maxAttackDelay;
        }

        public void Attack()
        {
            if (!_canFire) return;
            
            Ray ray = _camera.ViewportPointToRay(Vector3.one / 2f);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, _distance, _layerMask))
                Debug.Log( hit.collider.gameObject.name);

            _currentTime = 0f;
        }
    }
}
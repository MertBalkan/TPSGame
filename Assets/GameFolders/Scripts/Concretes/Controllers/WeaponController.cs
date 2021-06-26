using System.Collections;
using System.Collections.Generic;
using TPSGame.Abstracts.Combats;
using TPSGame.Concretes.Combats;
using TPSGame.Concretes.ScriptableObjects;
using UnityEngine;

namespace TPSGame.Concretes.Controllers
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] private bool _canFire;
        [SerializeField] private Transform _transformObject;
        [SerializeField] private AttackScriptableObject _attackScriptableObject;

        private IAttackType _attackType;
        
        private float _currentTime = 0f;

        public AttackScriptableObject AttackScriptableObject => _attackScriptableObject;
        private void Awake()
        {
            _attackType = _attackScriptableObject.GetAttackType(_transformObject); 
        }

        private void Update()
        {
            _currentTime += Time.deltaTime;
            _canFire = _currentTime > _attackScriptableObject.MaxAttackDelay;
        }

        public void Attack()
        {
            if (!_canFire) return;

            _attackType.AttackAction();

            _currentTime = 0f;
        }
    }
}
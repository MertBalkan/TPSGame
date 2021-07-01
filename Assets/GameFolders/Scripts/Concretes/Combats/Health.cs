using System.Collections;
using System.Collections.Generic;
using TPSGame.Abstracts.Combats;
using TPSGame.Concretes.ScriptableObjects;
using UnityEngine;

namespace TPSGame.Concretes.Combats
{
    public class Health : MonoBehaviour, IHealth
    {
        [SerializeField] private HealthScriptableObject _healthData;
        [SerializeField] private int _currentHealth;

        public bool IsDead => _currentHealth <= 0;

        public event System.Action<int, int> OnTakeHit;
        public event System.Action OnDead;

        private void Awake()
        {
            _currentHealth = _healthData.MaxHealth;
        }

        public void TakeDamage(int damage)
        {
            Debug.Log(this.gameObject.name + "  " + _currentHealth);
            if (IsDead) return;

            _currentHealth -= damage;
            OnTakeHit?.Invoke(_currentHealth, _healthData.MaxHealth);
            if(IsDead) OnDead?.Invoke();
        }
    }
}
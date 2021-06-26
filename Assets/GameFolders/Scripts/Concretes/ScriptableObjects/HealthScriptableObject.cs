using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TPSGame.Concretes.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Health Data", menuName = "Health Data")]
    public class HealthScriptableObject : ScriptableObject
    {
        [SerializeField] private int _maxHealth;

        public int MaxHealth => _maxHealth;
    }
}

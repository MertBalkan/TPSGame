using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TPSGame.Abstracts.Utilities
{
    public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : Component
    {
        public static T Instance { get; private set; }

        protected void SingletonMethod(T entity)
        {
            if (Instance == null)
            {
                Instance = entity;
                DontDestroyOnLoad(this.gameObject);
            }
            else{
                Destroy(this.gameObject);
            }
        }
    }
}
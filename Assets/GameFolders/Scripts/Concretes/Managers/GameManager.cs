using System.Collections;
using System.Collections.Generic;
using TPSGame.Abstracts.Utilities;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TPSGame.Concretes.Managers
{
    public class GameManager : SingletonMonoBehaviour<GameManager>
    {
        [SerializeField] private int _waveMaxCount = 100;

        public bool IsWaveFinished => _waveMaxCount <= 0;

        private void Awake()
        {
            SingletonMethod(this);
        }

        public void LoadLevel(string levelName)
        {
            StartCoroutine(LoadLevelAsync(levelName));
        }
        private IEnumerator LoadLevelAsync(string levelName)
        {
            yield return SceneManager.LoadSceneAsync(levelName);
        }
        public void DecreaseWaveCount()
        {
            if(IsWaveFinished) return;
            _waveMaxCount--;
        }
    }
}
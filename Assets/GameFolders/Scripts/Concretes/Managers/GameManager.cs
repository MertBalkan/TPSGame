using System.Collections;
using System.Collections.Generic;
using TPSGame.Abstracts.Utilities;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TPSGame.Concretes.Managers
{
    public class GameManager : SingletonMonoBehaviour<GameManager>
    {
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
    }
}
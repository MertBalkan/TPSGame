﻿using System.Collections;
using System.Collections.Generic;
using TPSGame.Abstracts.Utilities;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TPSGame.Concretes.Managers
{
    public class GameManager : SingletonMonoBehaviour<GameManager>
    {
        [SerializeField] private float _waveMultiple = 1.2f;
        [SerializeField] private float _waitForNextLevel = 10.0f;
        [SerializeField] private int _maxWaveBoundaryCount = 50;

        private int _currentWaveMaxCount = 50;
        public bool IsWaveFinished => _currentWaveMaxCount <= 0;

        private void Awake()
        {
            SingletonMethod(this);
        }
        private void Start()
        {
            _currentWaveMaxCount = _maxWaveBoundaryCount;
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
            if (IsWaveFinished && EnemyManager.Instance.IsListEmpty)
            {
                StartCoroutine(StartNextWaveAsync());
            }
            else
            {
                _currentWaveMaxCount--;
            }
        }
        private IEnumerator StartNextWaveAsync()
        {
            yield return new WaitForSeconds(_waitForNextLevel);
            _maxWaveBoundaryCount = System.Convert.ToInt32(_maxWaveBoundaryCount * _waveMultiple);
            _currentWaveMaxCount = _maxWaveBoundaryCount;
        }
    }
}
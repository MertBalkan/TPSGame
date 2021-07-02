using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using TPSGame.Concretes.Managers;
using System;

namespace TPSGame.Concretes.UIs
{
    public class DisplayWaveLevel : MonoBehaviour
    {
        private TMP_Text _levelText;
        private void Awake()
        {
            _levelText = GetComponent<TMP_Text>();
        }
        private void OnEnable()
        {
            GameManager.Instance.OnNextWave += HandleOnNextWave;
        }
        private void OnDisable()
        {
            GameManager.Instance.OnNextWave -= HandleOnNextWave;
        }
        private void HandleOnNextWave(int levelValue)
        {
            _levelText.text = "Wave: " + levelValue.ToString();
        }
    }
}

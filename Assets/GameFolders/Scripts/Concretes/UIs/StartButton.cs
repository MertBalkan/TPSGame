using System.Collections;
using System.Collections.Generic;
using TPSGame.Concretes.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace TPSGame.Concretes.UIs
{
    public class StartButton : MonoBehaviour
    {
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }
        private void OnEnable()
        {
            _button.onClick.AddListener(HandleOnButtonClicked);
        }
        private void OnDisable()
        {
            _button.onClick.RemoveListener(HandleOnButtonClicked);
        }
        private void HandleOnButtonClicked()
        {
            GameManager.Instance.LoadLevel("Game");
        }
    }
}
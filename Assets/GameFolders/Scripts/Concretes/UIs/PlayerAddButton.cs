using TPSGame.Concretes.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace TPSGame.Concretes.UIs
{
    public class PlayerAddButton : MonoBehaviour
    {
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }
        private void OnEnable()
        {
            _button.onClick.AddListener(OnButtonClicked);
        }
        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnButtonClicked);
        }
        private void OnButtonClicked()
        {
            GameManager.Instance.IncreasePlayerCount();
        }
    }
}
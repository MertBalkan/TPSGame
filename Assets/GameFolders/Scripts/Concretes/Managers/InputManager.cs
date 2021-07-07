using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TPSGame.Concretes.Managers
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;
        private PlayerInputManager _playerInputManager;
        private int _playerIndex;
        private void Awake()
        {
            _playerInputManager = GetComponent<PlayerInputManager>();
            _playerInputManager.playerPrefab = _prefab;
        }
        private void OnEnable()
        {
            StartCoroutine(LoadPlayersAsync());
        }
        private IEnumerator LoadPlayersAsync()
        {
            WaitForSeconds waitForSeconds = new WaitForSeconds(1f);
            for (int i = 0; i < GameManager.Instance.PlayerCount; i++)
            {
                _playerInputManager.JoinPlayer(_playerIndex);
                yield return waitForSeconds;
            }
        }
        public void HandleOnJoin()
        {
            _playerIndex++;
        }
        public void HandleOnLeft()
        {
            _playerIndex--;
        }
    }
}
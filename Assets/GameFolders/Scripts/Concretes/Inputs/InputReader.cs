using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TPSGame.Abstracts.Inputs;
using UnityEngine.InputSystem;
using System;

namespace TPSGame.Concretes.Inputs
{
    public class InputReader : MonoBehaviour, IInputReader
    {
        public Vector3 Direction { get; private set; }
        public Vector2 Rotation { get; private set; }
        public bool IsAttackButtonPressed { get; private set; }
        public bool IsInventoryButtonPressed { get; private set; }

        private int _index = 0;

        public void OnMove(InputAction.CallbackContext context)
        {
            Vector2 oldDirection = context.ReadValue<Vector2>();
            Direction = new Vector3(oldDirection.x, 0.0f, oldDirection.y);
        }

        public void OnRotator(InputAction.CallbackContext context)
        {
            Rotation = context.ReadValue<Vector2>();
        }

        public void OnAttack(InputAction.CallbackContext context)
        {
            IsAttackButtonPressed = context.ReadValueAsButton();
        }

        public void OnInventoryPressed(InputAction.CallbackContext context){
            if(IsInventoryButtonPressed && context.action.triggered) return;
            
            StartCoroutine(WaitOnFrameAsync());
        }

        private IEnumerator WaitOnFrameAsync()
        {
            IsInventoryButtonPressed = true && _index % 2 == 0;
            yield return new WaitForEndOfFrame();
            IsInventoryButtonPressed = false;
            _index++;
        }
    }
}
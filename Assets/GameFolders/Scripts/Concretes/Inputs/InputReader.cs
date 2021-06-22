using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TPSGame.Abstracts.Inputs;
using UnityEngine.InputSystem;

namespace TPSGame.Concretes.Inputs
{
    public class InputReader : MonoBehaviour, IInputReader
    {
        public Vector3 Direction { get; private set; }

        public void OnMove(InputAction.CallbackContext context)
        {
            Vector2 oldDirection = context.ReadValue<Vector2>();
            Direction = new Vector3(oldDirection.x, 0.0f, oldDirection.y);
        }
    }
}
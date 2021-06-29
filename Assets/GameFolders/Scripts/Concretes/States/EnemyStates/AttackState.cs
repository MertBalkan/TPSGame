using System.Collections;
using System.Collections.Generic;
using TPSGame.Abstracts.States;
using UnityEngine;

namespace TPSGame.Concretes.States
{
    public class AttackState : IState
    {
        public void OnEnter()
        {
            Debug.Log("Attack State enter");
        }

        public void OnExit()
        {
            Debug.Log("Attack State Exit");
        }

        public void Tick()
        {
            Debug.Log("Attack State Tick");
        }
    }
}

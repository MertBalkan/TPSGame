using TPSGame.Abstracts.States;
using UnityEngine;

namespace TPSGame.Concretes.States
{
    public class ChaseState : IState
    {
        public void OnEnter()
        {
            Debug.Log("Chase State enter");
        }

        public void OnExit()
        {
            Debug.Log("Chase State exit");
        }

        public void Tick()
        {
            Debug.Log("Chase State Tick");
        }
    }
}
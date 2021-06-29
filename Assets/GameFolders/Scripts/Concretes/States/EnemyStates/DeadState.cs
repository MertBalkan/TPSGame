using TPSGame.Abstracts.States;
using UnityEngine;

namespace TPSGame.Concretes.States
{
    public class DeadState : IState
    {
        public void OnEnter()
        {
            Debug.Log("Dead State enter");
        }

        public void OnExit()
        {
            Debug.Log("Dead State exit");
        }

        public void Tick()
        {
            Debug.Log("Dead State Tick");
        }

        public void TickFixed()
        {
            
        }

        public void TickLate()
        {
            
        }
    }
}
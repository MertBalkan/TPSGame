using System;
using System.Collections;
using System.Collections.Generic;
using TPSGame.Abstracts.States;
using UnityEngine;

namespace TPSGame.Concretes.Staets
{
    public class StateTransformer
    {
        private IState To { get; }
        private IState From { get; }
        private System.Func<bool> Condition { get; }

        public StateTransformer(IState to, IState from, Func<bool> condition)
        {
            To = to;
            From = from;
            Condition = condition;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using TPSGame.Abstracts.States;
using UnityEngine;

namespace TPSGame.Concretes.States
{
    public class StateTransformer
    {
        public IState To { get; }
        public IState From { get; }
        public System.Func<bool> Condition { get; }

        public StateTransformer(IState to, IState from, Func<bool> condition)
        {
            To = to;
            From = from;
            Condition = condition;
        }
    }
}

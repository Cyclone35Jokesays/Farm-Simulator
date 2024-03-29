﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateStuff
{
    public class StateMachine<T>
    {
        public State<T> CurrentState { get; private set; }
        public T Owner;

        public StateMachine(T _o)
        {
            Owner = _o;
            CurrentState = null;
        }

        public void ChangeState(State<T> _newState)
        {
            if (CurrentState != null)
                CurrentState.ExitState(Owner);
            CurrentState = _newState;
            CurrentState.EnterState(Owner);
        }

        public void Update()
        {
            if (CurrentState != null)
                CurrentState.UpdateState(Owner);
        }
    }

    public abstract class State<T>
    {
        public abstract void EnterState(T _owner);
        public abstract void ExitState(T _owner);
        public abstract void UpdateState(T _owner);
    }
}
using System;
using System.Collections.Generic;

namespace Scripts.Infrastructure
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, Istate> _states;
        private Istate _activeState;

        public GameStateMachine()
        {
            _states = new Dictionary<Type, Istate>();
        }

        public void Enter<TState>() where TState : Istate
        {
            _activeState?.Exit();
            Istate state = _states[typeof(TState)];
            _activeState = state;
            state.Enter();
        }
    }
}
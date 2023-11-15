using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class StateInitializer : IStateInitializer
    {
        public IState NewState(IState state)
        {
            state.Enter();
            return state;
        }

        public IState ChangeState(IState currentState, IState nextState)
        {
            currentState?.Exit();
            nextState.Enter();
            return nextState;
        }
    }
}
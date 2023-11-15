using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace GameLogic
{
    public interface IStateInitializer
    {
        IState NewState(IState state);
        IState ChangeState(IState currentState, IState nextState);
    }
}
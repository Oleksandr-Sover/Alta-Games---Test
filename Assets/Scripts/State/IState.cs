using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public interface IState
    {
        void Enter();
        void Execute();
        void Exit();
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameLogic
{
    public delegate void OnTap();
    public delegate void OnRelease();

    public interface IInputHandler
    {
        void UpdateInput();
        event OnTap onTap;
        event OnRelease onRelease;
    }
}
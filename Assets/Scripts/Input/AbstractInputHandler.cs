using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public abstract class AbstractInputHandler : MonoBehaviour
    {
        public abstract void UpdateInput();

        void Update()
        {
            UpdateInput();
        }
    }
}
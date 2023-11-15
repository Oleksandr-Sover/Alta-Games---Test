using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class TouchInputHandler : AbstractInputHandler, IInputHandler
    {
        public event OnTap onTap;
        public event OnRelease onRelease;

        public override void UpdateInput()
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    onTap?.Invoke();
                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    onRelease?.Invoke();
                }
            }
        }
    }
}
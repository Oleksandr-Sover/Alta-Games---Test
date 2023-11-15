using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class Timer
    {
        float time = 0;

        public void SetTimer(float time) => this.time = time;

        public bool CalculateTime()
        {
            if (time > 0)
            {
                time -= Time.deltaTime;
                return true;
            }
            else
                return false;
        }
    }
}
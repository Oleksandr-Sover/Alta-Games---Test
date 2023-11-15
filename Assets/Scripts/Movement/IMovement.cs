using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public interface IMovement
    {
        void Initialization(GameObject obj, Vector3 direction, float speed);
        void StartMoving();
        void StopForce();
        void StopMoving();
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public interface IObstacleSetter
    {
        void SetObstacles(ObjectPoolFactory obstacleFactory, ObstacleData obstacleData);
    }
}
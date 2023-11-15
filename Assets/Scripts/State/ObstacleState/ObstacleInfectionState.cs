using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class ObstacleInfectionState : IState
    {
        ObstacleData obstacleData;

        Timer timer = new();

        public delegate void OnDestroyObstacles();
        public event OnDestroyObstacles onDestroyObstacles;

        bool infection = false;

        public void Initialization(ObstacleData obstacleData)
        {
            this.obstacleData = obstacleData;
        }

        public void Enter()
        {
            timer.SetTimer(obstacleData.InfectionTime);
        }

        public void Execute()
        {
            infection = timer.CalculateTime();

            if (!infection)
            {
                onDestroyObstacles?.Invoke();
                infection = true;
            }
        }

        public void Exit()
        {
          
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class PlayersShotState : IState
    {
        ShotController shotController;

        public void Initialization(ShotController shotController)
        {
            this.shotController = shotController;
        }

        public void Enter()
        {
            shotController.InitMovement();
            shotController.StartMoveShot();
        }

        public void Execute()
        {

        }

        public void Exit()
        {
            shotController.StopMoveShot();
        }
    }
}
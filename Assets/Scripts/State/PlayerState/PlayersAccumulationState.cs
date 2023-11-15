using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class PlayersAccumulationState : IState
    {
        ShotController shotController;
        PlayerController playerController;
        LineController lineController;

        public void Initialization(ShotController shotController, PlayerController playerController, LineController lineController) 
        {
            this.shotController = shotController;
            this.playerController = playerController;
            this.lineController = lineController;
        }

        public void Enter()
        {
            shotController.SetShot();
            shotController.SetShotScaler();
            playerController.SetPlayerScaler();
            lineController.SetLineScaler();
        }

        public void Execute()
        {
            shotController.ScaleShot();
            playerController.ScalePlayer();
            lineController.ScaleLine();

            if (shotController.IsMinShotReached() && playerController.realese) 
            {
                playerController.SetShotState();
                playerController.realese = false;
            }
        }

        public void Exit()
        {

        }
    }
}
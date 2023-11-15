using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class PlayersMovementState : IState
    {
        PlayerData playerData;
        IMovement Movement;

        Timer movementTimer = new();

        bool collision;
        bool move;

        public void Initialization(PlayerData playerData, IMovement Movement, CollisionDetector collisionDetector)
        {
            this.playerData = playerData;
            this.Movement = Movement;

            collisionDetector.onCollisionA += OnTerrainCollision;
        }

        public void Enter()
        {

        }

        public void Execute()
        {
            if (collision)
            {
                collision = false;
                movementTimer.SetTimer(playerData.MovementTime);
            }

            move = movementTimer.CalculateTime();

            if (move)
            {
                Movement.StartMoving();
            }
            else
            {
                Movement.StopForce();
            }
        }

        public void Exit()
        {
            
        }

        void OnTerrainCollision() => collision = true;
    }
}
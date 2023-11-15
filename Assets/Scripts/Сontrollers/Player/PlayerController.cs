using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class PlayerController : MonoBehaviour
    {
        IInputHandler InputHandler;

        IStateInitializer StateInitializer = new StateInitializer();
        IState CurrentState;
        IScaler Scaler;
        IMovement Movement;

        PlayersRestingState playersRestingState = new();
        PlayersAccumulationState playersAccumulationState = new();
        PlayersShotState playersShotState = new();
        PlayersMovementState playersMovementState = new();

        [SerializeField] PlayerData playerData;
        [SerializeField] ShotData shotData;
        [SerializeField] ShotController shotController;
        [SerializeField] LineController lineController;
        [SerializeField] ObstacleController obstacleController;
        [SerializeField] CollisionDetector collisionDetector;
        [SerializeField] GameController gameController;
        
        [HideInInspector] public bool realese;

        readonly string terrainTag = "Terrain";
        readonly string obstacleTag = "Obstacle";

        bool endShot;

        void Awake()
        {
            InputHandler = GetComponent<IInputHandler>();
            Scaler = GetComponent<IScaler>();
            Movement = GetComponent<IMovement>();

            Movement.Initialization(gameObject, playerData.BounceVector, playerData.Speed);

            CurrentState = StateInitializer.NewState(playersRestingState);

            collisionDetector.Initialization(terrainTag, obstacleTag);

            playersAccumulationState.Initialization(shotController, this, lineController);
            playersShotState.Initialization(shotController);
            playersMovementState.Initialization(playerData, Movement, collisionDetector);

            obstacleController.obstacleInfectionState.onDestroyObstacles += OnRestingOrMoveState;
            shotController.onDestroy += OnRestingOrMoveState;
            collisionDetector.onCollisionB += gameController.ReloadScene;
        }

        void Start()
        {
            SetStartData();
        }

        void Update()
        {
            CurrentState.Execute();
        }

        void SetStartData()
        {
            playerData.Power = playerData.StartingPower;
            Scaler.SetScale(gameObject, playerData.Power);
        }

        void OnEnable() => SubscribeToInput();

        void OnDisable() => UnsubscribeFromInput();

        void OnDestroy() => UnsubscribeFromInput();

        void SubscribeToInput()
        {
            InputHandler.onTap += OnTap;
            InputHandler.onRelease += OnRealese;
        }

        void UnsubscribeFromInput()
        {
            InputHandler.onTap -= OnTap;
            InputHandler.onRelease -= OnRealese;
        }

        void OnTap()
        {
            if (CurrentState != playersShotState)
            {
                CurrentState = StateInitializer.ChangeState(CurrentState, playersAccumulationState);
            }
        }

        void OnRealese()
        {
            if (CurrentState == playersAccumulationState && !realese)
            {
                if (shotController.IsMinShotReached())
                {
                    SetShotState();
                }
                else
                    realese = true;
            }
        }

        public void SetEndShotState()
        {
            SetShotState();
            endShot = true;
        }

        public void SetShotState() => CurrentState = StateInitializer.ChangeState(CurrentState, playersShotState);

        void OnRestingOrMoveState()
        {
            if (!endShot)
                CurrentState = StateInitializer.ChangeState(CurrentState, playersRestingState);
            else
                SetMoveState();
        }

        public void SetMoveState() => CurrentState = StateInitializer.ChangeState(CurrentState, playersMovementState);

        public void SetPlayerScaler() => Scaler.SetScaler(gameObject, playerData.ScaleDuration, playerData.Power, shotData.StartingShotPower);

        public void ScalePlayer() => playerData.Power = Scaler.Scale();
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class ObstacleController : MonoBehaviour
    {
        [SerializeField] ObstacleData obstacleData;
        [SerializeField] ObjectPoolFactory obstacleFactory;
        [SerializeField] ShotController shotController;

        IStateInitializer StateInitializer = new StateInitializer();
        IObstacleSetter obstacleSetter;
        IState CurrentState;

        ObstacleRestingState obstacleRestingState = new();
        public readonly ObstacleInfectionState obstacleInfectionState = new();

        List<GameObject> infectedObstacles = new();

        void Awake()
        {
            obstacleSetter = GetComponent<IObstacleSetter>();
            obstacleSetter.SetObstacles(obstacleFactory, obstacleData);
            obstacleInfectionState.Initialization(obstacleData);

            CurrentState = StateInitializer.NewState(obstacleRestingState);

            shotController.onInfection += SetInfection;
            obstacleInfectionState.onDestroyObstacles += DestroyObstacles;
        }

        void Update()
        {
            CurrentState.Execute();
        }

        void DestroyObstacles()
        {
            foreach (var obstacle in infectedObstacles)
            {
                obstacleFactory.Destroy(obstacle);
            }

            shotController.ClearInfectedObjects();
            CurrentState = StateInitializer.ChangeState(CurrentState, obstacleRestingState);
        }

        public void SetInfection()
        {
            infectedObstacles = shotController.GetInfectedObjects();
            MeshRenderer meshRenderer;

            foreach (var obstacle in infectedObstacles)
            {
                meshRenderer = obstacle.GetComponent<MeshRenderer>();
                meshRenderer.material = obstacleData.InfectionMaterial;
            }

            CurrentState = StateInitializer.ChangeState(CurrentState, obstacleInfectionState);
        }

        void OnDrawGizmosSelected()
        {
            // draw the boundaries of the obstacle field
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(obstacleData.FieldCenter + new Vector3(0, obstacleData.FieldCenter.y, 0), new Vector3(obstacleData.FieldHeight, obstacleData.FieldCenter.y, obstacleData.FieldWidth));
        }
    }
}
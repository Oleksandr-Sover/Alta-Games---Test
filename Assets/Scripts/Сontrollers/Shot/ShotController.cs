using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class ShotController : MonoBehaviour
    {
        IScaler Scaler;
        IMovement Movement;

        [SerializeField] PlayerData playerData;
        [SerializeField] ShotData shotData;
        [SerializeField] ObjectPoolFactory shotFactory;
        [SerializeField] ShotSetter shotSetter;

        public delegate void OnInfection();
        public event OnInfection onInfection;

        public delegate void OnDestroy();
        public event OnDestroy onDestroy;

        GameObject shot;
        CollisionDetector collisionDetector;
        PoolTriggerDetector triggerDetector;

        List<GameObject> infectedObjects = new();

        readonly string obstacleTag = "Obstacle";
        readonly string doorTag = "Door";

        void Awake()
        {
            Scaler = GetComponent<IScaler>();
            Movement = GetComponent<IMovement>();
        }

        public void SetShot()
        {
            var shot = shotSetter.SetShot(shotFactory);

            if (this.shot != shot)
            {
                collisionDetector = shot.GetComponent<CollisionDetector>();
                triggerDetector = shot.GetComponentInChildren<PoolTriggerDetector>();
                collisionDetector.Initialization(obstacleTag, doorTag);
                collisionDetector.onCollisionA += Infection;
                collisionDetector.onCollisionB += DestroyShot;
            }

            this.shot = shot;
        }

        void Infection()
        {
            infectedObjects.Clear();
            infectedObjects.AddRange(triggerDetector.GetObjectsInTrigger());
            onInfection?.Invoke();
            DestroyShot();
        }

        void DestroyShot()
        {
            shotFactory.Destroy(shot);
            onDestroy?.Invoke();
        }

        public bool IsMinShotReached()
        {
            if (shot.transform.localScale.x < shotData.MinShotPower)
                return false;
            else
                return true;
        }

        public void ClearInfectedObjects() => triggerDetector.ClearObjects();

        public List<GameObject> GetInfectedObjects() => infectedObjects;

        public void SetShotScaler() => Scaler.SetScaler(shot, playerData.ScaleDuration, shotData.StartingShotPower, playerData.Power);

        public void ScaleShot() => Scaler.Scale();

        public void StartMoveShot() => Movement.StartMoving();

        public void StopMoveShot() => Movement.StopMoving();

        public void InitMovement() => Movement.Initialization(shot, Vector3.forward, shotData.Speed);
    }
}
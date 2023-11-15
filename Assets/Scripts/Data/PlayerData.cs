using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData", order = 0)]
    public class PlayerData : ScriptableObject
    {
        [SerializeField] float startingPower = 1f;
        public float StartingPower { get => startingPower; }

        [SerializeField] float power;
        public float Power { get => power; set => power = value; }

        [SerializeField] float minPower = 0.5f;
        public float MinPower { get => minPower; }

        [SerializeField] float scaleDuration = 2.0f;
        public float ScaleDuration { get => scaleDuration; }

        [SerializeField] float movementTime = 0.5f;
        public float MovementTime { get => movementTime; }

        [SerializeField] float speed = 10;
        public float Speed { get => speed; }

        [SerializeField] Vector3 bounceVector = new Vector3(0, 0.8944272f, 0.4472136f);
        public Vector3 BounceVector { get => bounceVector; }
    }
}
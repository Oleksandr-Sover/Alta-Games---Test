using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    [CreateAssetMenu(fileName = "ShotData", menuName = "ScriptableObjects/ShotData", order = 2)]
    public class ShotData : ScriptableObject
    {
        [SerializeField] float startingShotPower = 0.01f;
        public float StartingShotPower { get => startingShotPower; }

        [SerializeField] float minShotPower = 0.2f;
        public float MinShotPower { get => minShotPower; }

        [SerializeField] float speed = 1f;
        public float Speed { get => speed; }
    }
}
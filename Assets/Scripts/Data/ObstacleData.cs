using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace GameLogic
{
    [CreateAssetMenu(fileName = "ObstacleData", menuName = "ScriptableObjects/ObstacleData", order = 1)]
    public class ObstacleData : ScriptableObject
    {
        [SerializeField, Range(1, 20)] float fieldWidth = 10f;
        public float FieldWidth { get => fieldWidth; }

        [SerializeField, Range(1, 20)] float fieldHeight = 10f;
        public float FieldHeight { get => fieldHeight; }

        [SerializeField, Range(10, 100)] int minQuantity = 40;
        public int MinQuantity { get => minQuantity; }

        [SerializeField, Range(50, 250)] int maxQuantity = 80;
        public int MaxQuantity { get => maxQuantity; }

        [SerializeField, Range(0.1f, 1)] float minFillingProbability = 0.2f;
        public float MinFillingProbability { get => minFillingProbability; }

        [SerializeField] Vector3 fieldCenter = Vector3.zero;
        public Vector3 FieldCenter { get => fieldCenter; }

        [SerializeField] float infectionTime = 2f;
        public float InfectionTime { get => infectionTime; }

        [SerializeField] Material infectionMaterial;
        public Material InfectionMaterial { get => infectionMaterial; }
    }
}
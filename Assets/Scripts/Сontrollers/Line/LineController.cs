using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class LineController : MonoBehaviour
    {
        IScaler Scaler;

        [SerializeField] PlayerData playerData;
        [SerializeField] ShotData shotData;

        void Awake()
        {
            Scaler = GetComponent<IScaler>();
        }

        public void SetLineScaler() => Scaler.SetScaler(gameObject, playerData.ScaleDuration, playerData.Power, shotData.StartingShotPower);

        public void ScaleLine() => Scaler.SetScale(gameObject, playerData.Power);
    }
}
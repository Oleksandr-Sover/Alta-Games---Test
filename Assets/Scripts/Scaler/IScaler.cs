using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public interface IScaler
    {
        void SetScaler(GameObject obj, float scaleDuration, float initialScale, float targetScale);
        float Scale();
        void SetScale(GameObject obj, float scale);
    }
}
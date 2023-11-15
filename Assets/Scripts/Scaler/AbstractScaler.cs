using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public abstract class AbstractScaler : MonoBehaviour
    {
        protected GameObject obj;
        protected float scaleDuration;
        protected float initialScale;
        protected float targetScale;
        protected float timer;
        protected float newScale;

        [SerializeField] protected float scaleFactor = 1;

        public void SetScaler(GameObject obj, float scaleDuration, float initialScale, float targetScale)
        {
            SetScalerData(obj, scaleDuration, initialScale, targetScale);
            ScaleObject(obj, initialScale);
        }

        void SetScalerData(GameObject obj, float scaleDuration, float initialScale, float targetScale)
        {
            this.obj = obj;
            this.scaleDuration = scaleDuration;
            this.initialScale = initialScale;
            this.targetScale = targetScale;
            timer = 0;
        }

        public void SetScale(GameObject obj, float scale) => ScaleObject(obj, scale);

        protected abstract void ScaleObject(GameObject obj, float scale);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class LineScaler : AbstractScaler, IScaler
    {
        [SerializeField] bool scaleX;
        [SerializeField] bool scaleY;
        [SerializeField] bool scaleZ;

        public float Scale()
        {
            timer += Time.deltaTime;
            newScale = Mathf.Lerp(initialScale, targetScale, timer / scaleDuration);

            ScaleObject(obj, newScale);

            return newScale;
        }

        protected override void ScaleObject(GameObject obj, float scale)
        {
            Vector3 newScale = obj.transform.localScale;

            if (scaleX)
                newScale.x = scale * scaleFactor;

            if (scaleY)
                newScale.y = scale * scaleFactor;

            if (scaleZ)
                newScale.z = scale * scaleFactor;

            obj.transform.localScale = newScale;
        }
    }
}
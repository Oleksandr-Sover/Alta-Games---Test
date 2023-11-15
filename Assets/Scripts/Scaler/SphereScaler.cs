using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class SphereScaler : AbstractScaler, IScaler
    {
        public float Scale()
        {
            timer += Time.deltaTime;

            float initialVolume = (4.0f / 3.0f) * Mathf.PI * Mathf.Pow(initialScale, 3);
            float targetVolume = (4.0f / 3.0f) * Mathf.PI * Mathf.Pow(targetScale, 3);

            float currentVolume = Mathf.Lerp(initialVolume, targetVolume, timer / scaleDuration);

            newScale = Mathf.Pow(3.0f / (4.0f * Mathf.PI) * currentVolume, 1.0f / 3.0f) * scaleFactor;

            obj.transform.localScale = new Vector3(newScale, newScale, newScale);

            return newScale;
        }

        protected override void ScaleObject(GameObject obj, float scale)
        {
            float finalScale = scale * scaleFactor;
            obj.transform.localScale = new Vector3(finalScale, finalScale, finalScale);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class PoolTriggerDetector : MonoBehaviour
    {
        List<GameObject> objectsInTrigger = new List<GameObject>();

        void OnTriggerEnter(Collider other)
        {
            if (!objectsInTrigger.Contains(other.gameObject))
            {
                objectsInTrigger.Add(other.gameObject);
            }
        }

        public List<GameObject> GetObjectsInTrigger() => objectsInTrigger;

        public void ClearObjects() => objectsInTrigger.Clear();
    }
}
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameLogic
{
    public class ObjectPool: IObjectPool<GameObject>
    {
        public List<GameObject> ActiveObjects { get; private set; }
        public List<GameObject> DeactiveObjects { get; private set; }

        public ObjectPool() 
        { 
            ActiveObjects = new();
            DeactiveObjects = new();
        }

        public void EnableObject(GameObject go)
        {
            go.SetActive(true);
            ActiveObjects.Add(go);
            DeactiveObjects.Remove(go);
        }

        public void DisableObject(GameObject go)
        {
            go.SetActive(false);
            DeactiveObjects.Add(go);
            ActiveObjects.Remove(go);
        }
    }
}
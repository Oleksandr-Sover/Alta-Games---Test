using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameLogic
{
    public class ObjectPoolFactory : MonoBehaviour, IFactory<GameObject>
    {
        [SerializeField] GameObject prefab;

        public List<GameObject> Objects { get => objectPool.ActiveObjects; }

        IObjectPool<GameObject> objectPool = new ObjectPool();

        public GameObject Create()
        {
            if (objectPool.DeactiveObjects.Count > 0)
            {
                GameObject go = objectPool.DeactiveObjects.Last();
                objectPool.EnableObject(go);
                return go;
            }
            else
            {
                GameObject go = Instantiate(prefab);
                objectPool.EnableObject(go);
                return go;
            }
        }

        public void Destroy(GameObject go) => objectPool.DisableObject(go);
    }
}
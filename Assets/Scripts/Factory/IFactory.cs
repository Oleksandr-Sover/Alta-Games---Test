using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public interface IFactory<T> where T : Object
    {
        List<T> Objects { get; }
        T Create();
        void Destroy(T objectToDestroy);
    }
}
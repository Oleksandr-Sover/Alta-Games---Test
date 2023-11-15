using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public interface IObjectPool<T> where T : Object
    {
        List<T> ActiveObjects { get; }
        List<T> DeactiveObjects { get; }
        void EnableObject(T t);
        void DisableObject(T t);
    }
}
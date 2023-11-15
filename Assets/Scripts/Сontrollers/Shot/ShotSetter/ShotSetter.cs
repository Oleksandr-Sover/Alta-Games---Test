using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class ShotSetter : MonoBehaviour
    {
        public GameObject SetShot(ObjectPoolFactory shotFactory)
        {
            GameObject shot = shotFactory.Create();
            shot.transform.position = transform.position;
            return shot;
        }
    }
}
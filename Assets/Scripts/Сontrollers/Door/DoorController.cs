using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class DoorController : MonoBehaviour
    {
        [SerializeField] DoorAnimator doorAnimator;

        public void OpenDoor() => doorAnimator.OpenDoor(true);
    }
}
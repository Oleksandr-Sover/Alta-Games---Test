using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class DoorAnimator : MonoBehaviour
    {
        [SerializeField] Animator leftLeafAnimator;
        [SerializeField] Animator rightLeafAnimator;

        static int idOpen;

        void Start()
        {
            idOpen = Animator.StringToHash("Open");
        }

        public void OpenDoor(bool open)
        {
            leftLeafAnimator.SetBool(idOpen, open);
            rightLeafAnimator.SetBool(idOpen, open);
        }
    }
}
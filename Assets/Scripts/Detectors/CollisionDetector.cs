using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class CollisionDetector : MonoBehaviour
    {
        public delegate void OnCollisionA();
        public event OnCollisionA onCollisionA;

        public delegate void OnCollisionB();
        public event OnCollisionB onCollisionB;

        string tagA;
        string tagB;

        bool isTagA;
        bool isTagB;

        public void Initialization(string tagA = "", string tagB = "")
        {
            this.tagA = tagA;
            this.tagB = tagB;

            if (tagA == "")
            {
                isTagA = false;
            }
            else
            {
                isTagA = true;
            }

            if (tagB == "")
            {
                isTagB = false;
            }
            else 
            { 
                isTagB = true; 
            }
        }

        void OnCollisionEnter(Collision collision)
        {
            if (isTagA && isTagB)
            {
                if (collision.gameObject.CompareTag(tagA))
                {
                    onCollisionA?.Invoke();
                }
                else if (collision.gameObject.CompareTag(tagB))
                {
                    onCollisionB?.Invoke();
                }
            }
            else if (isTagA)
            {
                if (collision.gameObject.CompareTag(tagA))
                {
                    onCollisionA?.Invoke();
                }
            }
            else if (isTagB)
            {
                if (collision.gameObject.CompareTag(tagB))
                {
                    onCollisionB?.Invoke();
                }
            }
        }
    }
}
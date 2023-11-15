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

        public delegate void OnCollisionC();
        public event OnCollisionC onCollisionC;

        string tagA;
        string tagB;
        string tagC;

        bool isTagA;
        bool isTagB;
        bool isTagC;

        public void Initialization(string tagA = "", string tagB = "", string tagC = "")
        {
            this.tagA = tagA;
            this.tagB = tagB;
            this.tagC = tagC;

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

            if (tagC == "")
            {
                isTagC = false;
            }
            else
            {
                isTagC = true;
            }    
        }

        void OnCollisionEnter(Collision collision)
        {
            if (isTagA && isTagB && isTagC)
            {
                if (collision.gameObject.CompareTag(tagA))
                {
                    onCollisionA?.Invoke();
                }
                else if (collision.gameObject.CompareTag(tagB))
                {
                    onCollisionB?.Invoke();
                }
                else if (collision.gameObject.CompareTag(tagC))
                {
                    onCollisionC?.Invoke();
                }
            }
            else if (isTagA && isTagB)
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
        }
    }
}
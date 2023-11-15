using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class RigidbodyMovement : MonoBehaviour, IMovement
    {
        Rigidbody rb;
        Vector3 direction;
        float speed;
        bool move;

        public void Initialization(GameObject obj, Vector3 direction, float speed)
        {
            rb = obj.GetComponent<Rigidbody>();

            this.direction = direction;
            this.speed = speed;
        }

        void FixedUpdate()
        {
            if (move)
                rb.AddForce(direction * speed);
        }

        public void StartMoving() => move = true;

        public void StopForce() => move = false;

        public void StopMoving()
        {
            move = false;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
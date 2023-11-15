using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetector : MonoBehaviour
{
    public delegate void OnTrigger();
    public event OnTrigger onTrigger;

    [SerializeField] string tagA;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagA))
        {
            onTrigger?.Invoke();
        }
    }
}

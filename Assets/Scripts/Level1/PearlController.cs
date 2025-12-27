using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PearlController : MonoBehaviour
{
    private Rigidbody pearlRigidbody;
    

    public void Start()
    {
        pearlRigidbody = GetComponent<Rigidbody>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BottleBase"))
        {
            Vector3 localPosition = transform.InverseTransformPoint(transform.position);
            if (localPosition.y > -4.21f)
            {
                pearlRigidbody.useGravity = false;
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("BottleBase"))
        {
            pearlRigidbody.useGravity = true;
        }
    }

    
}
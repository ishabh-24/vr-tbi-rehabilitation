using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopShelfCheck : MonoBehaviour
{
    public Material correct;
    private int correctMatches = 0;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("RedCube"))
        {
            GameObject cube = collision.gameObject;
            cube.GetComponent<Renderer>().material = correct;
        }
    }
}

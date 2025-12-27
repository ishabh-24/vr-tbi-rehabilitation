using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomShelfCheck : MonoBehaviour
{
    public Material correct;
    public int correctMatches = 0;

    public GameObject cube1;
    public GameObject cube2;
    public GameObject cube3;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("GreenCube"))
        {
            GameObject cube = collision.gameObject;
            cube.GetComponent<Renderer>().material = correct;
        }
    }
}

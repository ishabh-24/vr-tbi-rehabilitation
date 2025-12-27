using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class bucketCheck : MonoBehaviour
{
    public Material correct;
    public Material correctDark;
    public int numCorrect;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("WhiteClothes"))
        {
            GameObject cube = collision.gameObject;
            cube.GetComponent<Renderer>().material = correct;

        }

        if (collision.gameObject.CompareTag("DarkClothes"))
        {
            GameObject cube = collision.gameObject;
            cube.GetComponent<Renderer>().material = correctDark;
        }


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dryerCheck : MonoBehaviour
{
    public Material correctLight;
    public Material correctDark;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("WhiteClothes"))
        {
            GameObject cube = collision.gameObject;
            cube.GetComponent<Renderer>().material = correctLight;
        }

        if (collision.gameObject.CompareTag("DarkClothes"))
        {
            GameObject cube = collision.gameObject;
            cube.GetComponent<Renderer>().material = correctDark;
        }


    }

}

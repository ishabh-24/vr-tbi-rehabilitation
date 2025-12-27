using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Experimental.GlobalIllumination;

public class washerCheck : MonoBehaviour
{
    public Material correct;
    public Material correctDark;

    public int numCorrect;

    public TextMeshProUGUI washerLight;

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

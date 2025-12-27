using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Experimental.GlobalIllumination;
using Mono.Reflection;

public class Level3Manager : MonoBehaviour
{
    public GameObject white1;
    public GameObject white2;
    public GameObject white3;
    public GameObject washingCircle;
    public GameObject washingCircleDryer;

    public Material whiteC;
    public Material whiteCDryer;
    public Material whiteCBucket;
    public Material darkCBucket;

    public TextMeshProUGUI instructionsText;
    public GameObject level3Screen;

    public int numCorrect;
    public int numCorrectD;
    public int numCorrectB;

    public int numCorrectDarkW;
    public int numCorrectDarkD;
    public int numCorrectDarkB;

    public Vector3 white1Position;
    public Vector3 white2Position;
    public Vector3 white3Position;

    public Material loadComplete;
    public Material loadNotComplete;

    public TextMeshProUGUI lightWasherText;
    public TextMeshProUGUI lightDryerText;
    public TextMeshProUGUI lightBucketText;
    public TextMeshProUGUI failedText;
    

    public Button startL;
    public Button startDryer;
    public Button bucketCheck;
    public Button startLoadDark;
    public Button startDryerDark;
    public Button checkDryerButton;

    public GameObject dark1;
    public GameObject dark2;
    public GameObject dark3;

    public Material darkC;
    public Material darkDryerC;

    public int duration;

    public TextMeshProUGUI darkWasherText;
    public TextMeshProUGUI darkDryerText;
    public TextMeshProUGUI darkBucketText;

    public ParticleSystem level3Confetti;

    // Start is called before the first frame update
    void Start()
    {
        instructionsText.gameObject.SetActive(false);
        level3Screen.gameObject.SetActive(false);
        startL.gameObject.SetActive(false);
        lightWasherText.gameObject.SetActive(false);
        startDryer.gameObject.SetActive(false);
        lightDryerText.gameObject.SetActive(false);
        bucketCheck.gameObject.SetActive(false);
        lightBucketText.gameObject.SetActive(false);
        failedText.gameObject.SetActive(false);
        startLoadDark.gameObject.SetActive(false);
        darkWasherText.gameObject.SetActive(false);
        startDryerDark.gameObject.SetActive(false);
        darkDryerText.gameObject.SetActive(false);
        checkDryerButton.gameObject.SetActive(false);
        darkBucketText.gameObject.SetActive(false);
        level3Confetti.gameObject.SetActive(false);

    }

    public void startLoad()
    {
        MeshRenderer meshRenderer = white1.GetComponent<MeshRenderer>();
        Material cubeMaterial = white1.GetComponent<Renderer>().material;

        string correctMaterialName = whiteC.name;
        string assignedMaterialName = cubeMaterial.name;

        if (assignedMaterialName.Contains(correctMaterialName))
        {
            numCorrect++;
        }

        MeshRenderer meshRenderer2 = white2.GetComponent<MeshRenderer>();
        Material cubeMaterial2 = white2.GetComponent<Renderer>().material;

        string correctMaterialName2 = whiteC.name;
        string assignedMaterialName2 = cubeMaterial2.name;

        if (assignedMaterialName2.Contains(correctMaterialName2))
        {
            numCorrect++;
        }

        MeshRenderer meshRenderer3 = white3.GetComponent<MeshRenderer>();
        Material cubeMaterial3 = white3.GetComponent<Renderer>().material;

        string correctMaterialName3 = whiteC.name;
        string assignedMaterialName3 = cubeMaterial3.name;

        if (assignedMaterialName3.Contains(correctMaterialName3))
        {
            numCorrect++;
        }

        if (numCorrect == 3)
        {
            Debug.Log("White Clothes placed into washing machine.");
            failedText.gameObject.SetActive(false);
            lightWasherText.gameObject.SetActive(true);
            StartCoroutine(ActivateObject());
        }

        if (numCorrect != 3)
        {
            failedText.gameObject.SetActive(true);
            numCorrect = 0;
        }

        IEnumerator ActivateObject()
        {
            // Activate the object

            // Wait for the specified duration
            yield return new WaitForSeconds(duration);

            washingCircle.GetComponent<Renderer>().material = loadComplete;
            startDryer.gameObject.SetActive(true);


        }
    }

    public void startDryerLoad()
    {

        MeshRenderer meshRenderer = white1.GetComponent<MeshRenderer>();
        Material cubeMaterial = white1.GetComponent<Renderer>().material;

        string correctMaterialName = whiteCDryer.name;
        string assignedMaterialName = cubeMaterial.name;

        if (assignedMaterialName.Contains(correctMaterialName))
        {
            numCorrectD++;
        }

        MeshRenderer meshRenderer2 = white2.GetComponent<MeshRenderer>();
        Material cubeMaterial2 = white2.GetComponent<Renderer>().material;

        string correctMaterialName2 = whiteCDryer.name;
        string assignedMaterialName2 = cubeMaterial2.name;

        if (assignedMaterialName2.Contains(correctMaterialName2))
        {
            numCorrectD++;
        }

        MeshRenderer meshRenderer3 = white3.GetComponent<MeshRenderer>();
        Material cubeMaterial3 = white3.GetComponent<Renderer>().material;

        string correctMaterialName3 = whiteCDryer.name;
        string assignedMaterialName3 = cubeMaterial3.name;

        if (assignedMaterialName3.Contains(correctMaterialName3))
        {
            numCorrectD++;
        }

        if (numCorrectD == 3)
        {
            Debug.Log("White Clothes placed into dryer machine.");
            failedText.gameObject.SetActive(false);
            lightWasherText.gameObject.SetActive(false);
            lightDryerText.gameObject.SetActive(true);
            StartCoroutine(ActivateObject());

        }

        if (numCorrectD != 3)
        {
            lightWasherText.gameObject.SetActive(false);
            failedText.gameObject.SetActive(true);
            numCorrectD = 0;
        }

        IEnumerator ActivateObject()
        {
            // Activate the object

            // Wait for the specified duration
            yield return new WaitForSeconds(duration);

            washingCircleDryer.GetComponent<Renderer>().material = loadComplete;
            bucketCheck.gameObject.SetActive(true);


        }
    }

    public void checkBucket()
    {
        MeshRenderer meshRenderer = white1.GetComponent<MeshRenderer>();
        Material cubeMaterial = white1.GetComponent<Renderer>().material;

        string correctMaterialName = whiteCBucket.name;
        string assignedMaterialName = cubeMaterial.name;

        if (assignedMaterialName.Contains(correctMaterialName))
        {
            numCorrectB++;
        }

        MeshRenderer meshRenderer2 = white2.GetComponent<MeshRenderer>();
        Material cubeMaterial2 = white2.GetComponent<Renderer>().material;

        string correctMaterialName2 = whiteCBucket.name;
        string assignedMaterialName2 = cubeMaterial2.name;

        if (assignedMaterialName2.Contains(correctMaterialName2))
        {
            numCorrectB++;
        }

        MeshRenderer meshRenderer3 = white3.GetComponent<MeshRenderer>();
        Material cubeMaterial3 = white3.GetComponent<Renderer>().material;

        string correctMaterialName3 = whiteCBucket.name;
        string assignedMaterialName3 = cubeMaterial3.name;

        if (assignedMaterialName3.Contains(correctMaterialName3))
        {
            numCorrectB++;
        }

        if (numCorrectB == 3)
        {
            Debug.Log("White Clothes placed into bucket.");
            failedText.gameObject.SetActive(false);
            lightBucketText.gameObject.SetActive(true);
            lightDryerText.gameObject.SetActive(false);
            washingCircle.GetComponent<Renderer>().material = loadNotComplete;
            washingCircleDryer.GetComponent<Renderer>().material = loadNotComplete;
            startLoadDark.gameObject.SetActive(true);
            bucketCheck.gameObject.SetActive(false);
            startDryer.gameObject.SetActive(false);
            white1.gameObject.SetActive(false);
            white2.gameObject.SetActive(false);
            white3.gameObject.SetActive(false);

        }

        if (numCorrectB != 3)
        {
            lightDryerText.gameObject.SetActive(false);
            failedText.gameObject.SetActive(true);
            numCorrectB = 0;
        }
    }

    public void startDarkLoad()
    {
        MeshRenderer meshRenderer = dark1.GetComponent<MeshRenderer>();
        Material cubeMaterial = dark1.GetComponent<Renderer>().material;

        string correctMaterialName = darkC.name;
        string assignedMaterialName = cubeMaterial.name;

        if (assignedMaterialName.Contains(correctMaterialName))
        {
            numCorrectDarkW++;
        }

        MeshRenderer meshRenderer2 = dark2.GetComponent<MeshRenderer>();
        Material cubeMaterial2 = dark2.GetComponent<Renderer>().material;

        string correctMaterialName2 = darkC.name;
        string assignedMaterialName2 = cubeMaterial2.name;

        if (assignedMaterialName2.Contains(correctMaterialName2))
        {
            numCorrectDarkW++;
        }

        MeshRenderer meshRenderer3 = dark3.GetComponent<MeshRenderer>();
        Material cubeMaterial3 = dark3.GetComponent<Renderer>().material;

        string correctMaterialName3 = darkC.name;
        string assignedMaterialName3 = cubeMaterial3.name;

        if (assignedMaterialName3.Contains(correctMaterialName3))
        {
            numCorrectDarkW++;
        }

        if (numCorrectDarkW == 3)
        {
            lightBucketText.gameObject.SetActive(false);
            Debug.Log("Dark Clothes placed into washing machine.");
            failedText.gameObject.SetActive(false);
            darkWasherText.gameObject.SetActive(true);
            StartCoroutine(ActivateObject());
        }

        if (numCorrect != 3)
        {
            failedText.gameObject.SetActive(true);
            numCorrect = 0;
        }

        IEnumerator ActivateObject()
        {
            // Activate the object

            // Wait for the specified duration
            yield return new WaitForSeconds(duration);

            washingCircle.GetComponent<Renderer>().material = loadComplete;
            startDryerDark.gameObject.SetActive(true);


        }

    }

    public void startDarkDryerLoad()
    {
        MeshRenderer meshRenderer = dark1.GetComponent<MeshRenderer>();
        Material cubeMaterial = dark1.GetComponent<Renderer>().material;

        string correctMaterialName = darkDryerC.name;
        string assignedMaterialName = cubeMaterial.name;

        if (assignedMaterialName.Contains(correctMaterialName))
        {
            numCorrectDarkD++;
        }

        MeshRenderer meshRenderer2 = dark2.GetComponent<MeshRenderer>();
        Material cubeMaterial2 = dark2.GetComponent<Renderer>().material;

        string correctMaterialName2 = darkDryerC.name;
        string assignedMaterialName2 = cubeMaterial2.name;

        if (assignedMaterialName2.Contains(correctMaterialName2))
        {
            numCorrectDarkD++;
        }

        MeshRenderer meshRenderer3 = dark3.GetComponent<MeshRenderer>();
        Material cubeMaterial3 = dark3.GetComponent<Renderer>().material;

        string correctMaterialName3 = darkDryerC.name;
        string assignedMaterialName3 = cubeMaterial3.name;

        if (assignedMaterialName3.Contains(correctMaterialName3))
        {
            numCorrectDarkD++;
        }

        if (numCorrectDarkD == 3)
        {
            Debug.Log("Dark Clothes placed into dryer machine.");
            failedText.gameObject.SetActive(false);
            darkWasherText.gameObject.SetActive(false);
            darkDryerText.gameObject.SetActive(true);
            StartCoroutine(ActivateObject());

        }

        if (numCorrectDarkD != 3)
        {
            failedText.gameObject.SetActive(true);
            numCorrectDarkD = 0;
        }

        IEnumerator ActivateObject()
        {
            // Activate the object

            // Wait for the specified duration
            yield return new WaitForSeconds(duration);

            washingCircleDryer.GetComponent<Renderer>().material = loadComplete;
            checkDryerButton.gameObject.SetActive(true);

        }
    }

    public void checkBucketDark()
    {
        MeshRenderer meshRenderer = dark1.GetComponent<MeshRenderer>();
        Material cubeMaterial = dark1.GetComponent<Renderer>().material;

        string correctMaterialName = darkCBucket.name;
        string assignedMaterialName = cubeMaterial.name;

        if (assignedMaterialName.Contains(correctMaterialName))
        {
            numCorrectDarkB++;
        }

        MeshRenderer meshRenderer2 = dark2.GetComponent<MeshRenderer>();
        Material cubeMaterial2 = dark2.GetComponent<Renderer>().material;

        string correctMaterialName2 = darkCBucket.name;
        string assignedMaterialName2 = cubeMaterial2.name;

        if (assignedMaterialName2.Contains(correctMaterialName2))
        {
            numCorrectDarkB++;
        }

        MeshRenderer meshRenderer3 = dark3.GetComponent<MeshRenderer>();
        Material cubeMaterial3 = dark3.GetComponent<Renderer>().material;

        string correctMaterialName3 = darkCBucket.name;
        string assignedMaterialName3 = cubeMaterial3.name;

        if (assignedMaterialName3.Contains(correctMaterialName3))
        {
            numCorrectDarkB++;
        }

        if (numCorrectDarkB == 3)
        {
            Debug.Log("Dark Clothes placed into bucket.");
            failedText.gameObject.SetActive(false);
            darkBucketText.gameObject.SetActive(true);
            darkDryerText.gameObject.SetActive(false);
            level3Confetti.gameObject.SetActive(true);


        }

        if (numCorrectDarkB != 3)
        {
            darkDryerText.gameObject.SetActive(false);
            failedText.gameObject.SetActive(true);
            numCorrectB = 0;
        }
    }

}

    


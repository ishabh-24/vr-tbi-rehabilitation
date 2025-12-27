using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Experimental.GlobalIllumination;

public class Level2Manager : MonoBehaviour
{
    public GameObject[] gameObjects;

    public GameObject red1;
    public GameObject red2;
    public GameObject red3;

    public GameObject green1;
    public GameObject green2;
    public GameObject green3;

    public GameObject blue1;
    public GameObject blue2;
    public GameObject blue3;

    public Material purpleMaterial;

    public Material Red1;
    public Material Blue1;
    public Material Green1;

    public TextMeshProUGUI successText;
    public TextMeshProUGUI failText;

    public Vector3 red1Position;
    public Vector3 red2Position;
    public Vector3 red3Position;

    public Vector3 green1Position;
    public Vector3 green2Position;
    public Vector3 green3Position;

    public Vector3 blue1Position;
    public Vector3 blue2Position;
    public Vector3 blue3Position;

    public GameObject panel;
    public TextMeshProUGUI instructions;

    public float duration = 30f;

    public Button seeInstructions;
    public Button startButton;
    public Button nextLevel;
    public Button check;
    public Button reset;
    public Button startLoad;

    public int numFails;

    public GameObject cameraObject; // Reference to the main camera GameObject
    public GameObject directionalLight;

    public TextMeshProUGUI instructionsText;
    public GameObject level3Screen;
    public Button startLevel3;

    public ParticleSystem level2Confetti;

    void Start()
    {
        successText.gameObject.SetActive(false);
        failText.gameObject.SetActive(false);
        reset.gameObject.SetActive(false);
        seeInstructions.gameObject.SetActive(false);
        nextLevel.gameObject.SetActive(false);

        red1Position = red1.transform.position;
        red2Position = red2.transform.position;
        red3Position = red3.transform.position;

        green1Position = green1.transform.position;
        green2Position = green2.transform.position;
        green3Position = green3.transform.position;

        blue1Position = blue1.transform.position;
        blue2Position = blue2.transform.position;
        blue3Position = blue3.transform.position;

        startLevel3.gameObject.SetActive(false);

        level2Confetti.gameObject.SetActive(false);

    }
    public void CheckTaskCompletion()
    {
        int numCorrect = 0;
       

        foreach (GameObject cube in gameObjects)
        {
            MeshRenderer meshRenderer = cube.GetComponent<MeshRenderer>();
            Material cubeMaterial = meshRenderer.material;

            if (cube.CompareTag("RedCube"))
            {
                string correctMaterialName = Red1.name;
                string assignedMaterialName = cubeMaterial.name;
                Debug.Log("Red Cube found.");

                if (assignedMaterialName.Contains(correctMaterialName))
                {
                    numCorrect++;
                }
            }

            else if (cube.CompareTag("GreenCube"))
            {
                Debug.Log("Green Cube found.");
                string correctMaterialName1 = Green1.name;
                string assignedMaterialName1 = cubeMaterial.name;

                if (assignedMaterialName1.Contains(correctMaterialName1))
                {
                    numCorrect++;
                }
            }

            else if (cube.CompareTag("BlueCube"))
            {
                Debug.Log("Blue cube found.");
                string correctMaterialName2 = Blue1.name;
                string assignedMaterialName2 = cubeMaterial.name;

                if (assignedMaterialName2.Contains(correctMaterialName2))
                {
                    numCorrect++;
                }
            }
        }

        if (numCorrect == 9)
        {
            Debug.Log("Level 2 Completed. Red object placed on the top shelf, blue objects placed on the middle shelf, and green objects placed on the bottom shelf.");
            failText.gameObject.SetActive(false);
            successText.gameObject.SetActive(true);
            reset.gameObject.SetActive(false);
            seeInstructions.gameObject.SetActive(false);
            nextLevel.gameObject.SetActive(true);
            level2Confetti.gameObject.SetActive(true);
        }

        if (numCorrect != 9)
        {
            Debug.Log("Sorry, you did not organize the cubes in the correct way. Try again!");
            failText.gameObject.SetActive(true);
            numFails++;
        }

        if (numFails == 3 && numFails != 0)
        {
            
            seeInstructions.gameObject.SetActive(true);
            numFails = 0;
            StartCoroutine(ActivateObject());

        }
    }

    IEnumerator ActivateObject()
    {
        // Activate the object

        // Wait for the specified duration
        yield return new WaitForSeconds(duration);

        // Deactivate the object after the duration has passed
      
        panel.gameObject.SetActive(false);
        instructions.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);

    }


    public void onResetButtonClick()
    {
        red1.transform.position = red1Position;
        red2.transform.position = red2Position;
        red3.transform.position = red3Position;

        green1.transform.position = green1Position;
        green2.transform.position = green2Position;
        green3.transform.position = green3Position;

        blue1.transform.position = blue1Position;
        blue2.transform.position = blue2Position;
        blue3.transform.position = blue3Position;

    }

    public void onNextLevelButtonClick()
    {
        cameraObject.transform.position = new UnityEngine.Vector3(101.81f, 4.6f, 1.63f);
        directionalLight.transform.position = new UnityEngine.Vector3(100f, 4.61f, 1.63f);
        successText.gameObject.SetActive(false);
        nextLevel.gameObject.SetActive(false);
        check.gameObject.SetActive(false);
        startLevel3.gameObject.SetActive(true);
        instructionsText.gameObject.SetActive(true);
        level3Screen.gameObject.SetActive(true);
    }

}
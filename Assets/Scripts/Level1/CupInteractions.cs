using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;


public class CupInteractions : MonoBehaviour
{
    private int pearlsInside = 0;
    private int pearlsNeeded = 8; //the number of pearls needed to fill the cup
    public GameObject[] pearls;
    private Vector3[] initialPearlPositions;

    public GameObject waterBottle;
    
    private MoveWaterbottle waterBottleController;
    private PearlController pearlsController;
    public Button nextLevel;

    public TextMeshProUGUI completedText;
    public TextMeshProUGUI notCompleted;
    public TextMeshProUGUI level2Instructions;
    public Button restartButton;
    public Button level2Start;
    public Button reset;
    public GameObject Level2Screen;

    public GameObject Pearl1;
    public GameObject Pearl2;
    public GameObject Pearl3;
    public GameObject Pearl4;
    public GameObject Pearl5;
    public GameObject Pearl6;
    public GameObject Pearl7;
    public GameObject Pearl8;

    public ParticleSystem level1Confetti;
    

    private bool level1Complete = false;
    private int numAttempts = 1;

    public GameObject cameraObject; // Reference to the main camera GameObject
    public GameObject directionalLight;


    void Start()
    {
        // Get the reference to the MoveWaterbottle script attached to the water bottle GameObject
        waterBottleController = FindObjectOfType<MoveWaterbottle>();

        pearls = new GameObject[] { Pearl1, Pearl2, Pearl3, Pearl4, Pearl5, Pearl6, Pearl7, Pearl8 };
        

        // Initialize the initialPearlPositions array and track the initial positions of the pearls
        initialPearlPositions = new Vector3[pearls.Length];
        for (int i = 0; i < pearls.Length; i++)
        {
            initialPearlPositions[i] = pearls[i].transform.position;
        }

        //Level 2 
        nextLevel.gameObject.SetActive(false);
        Level2Screen.gameObject.SetActive(false);
        level2Instructions.gameObject.SetActive(false);
        level2Start.gameObject.SetActive(false);

        level1Confetti.gameObject.SetActive(false);

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pearl"))
        { 

            pearlsInside++;
            GameObject pearl = other.gameObject;
            pearl.SetActive(false);

            if (pearlsInside >= pearlsNeeded)
            {
                //The cup is filled with the 8 pearls
                completedText.gameObject.SetActive(true);
                level1Complete = true;

                nextLevel.gameObject.SetActive(true);

            }

            if (level1Complete)
            {
                Debug.Log("Level 1 Complete: poured 8 pearls from waterbottle into cup. ");
                level1Confetti.gameObject.SetActive(true);
            }
            else
            {
                CheckTaskCompletion();
            }

        }
    }

    private void CheckTaskCompletion()
    {
        bool isCompleted = pearlsInside >= pearlsNeeded;
        int pearlsLost = 0;

        if (!isCompleted)
        {
            for (int i = 0; i < pearls.Length; i++)
            {
                
                if (pearls[i] != null && pearls[i].transform.position.y < 3f)
                {
                    pearlsLost++;
                    

                }
                if (pearlsLost + pearlsInside == 8 && pearlsInside != 8)
                {
                    notCompleted.gameObject.SetActive(true);
                    restartButton.gameObject.SetActive(true);
                    Debug.Log("Did not successfully complete task.");
                    
                }
            }
        }

    }

    public void OnRestartButtonClick()
    {
        pearlsInside = 0;
        if (waterBottleController != null)
        {
            waterBottleController.ResetWaterBottle();
            
        }
        ResetPearls();
    }

    public void ResetPearls()
    {
        // Reset the pearls to their initial positions
        for (int i = 0; i < pearls.Length; i++)
        {
            pearls[i].transform.position = initialPearlPositions[i];
            pearls[i].SetActive(true);
        }

    }

    public void onNextLevelButtonClick()
    {
        //Camera & Light Adjustment
        cameraObject.transform.position = new UnityEngine.Vector3(38.52f, 6f, 1.46f);
        directionalLight.transform.position = new UnityEngine.Vector3(24.22f, 17.31f, -0.67f);
        directionalLight.transform.rotation = Quaternion.Euler(157f, -94f, -45f);
        cameraObject.transform.rotation = UnityEngine.Quaternion.identity;
        completedText.gameObject.SetActive(false);
        nextLevel.gameObject.SetActive(false);
        cameraObject.transform.Rotate(0f, 90f, 0f);

        //Level 2 Visuals & Instructions
        Level2Screen.gameObject.SetActive(true);
        level2Instructions.gameObject.SetActive(true);
        level2Start.gameObject.SetActive(true);
        reset.gameObject.SetActive(true);
    }

    public void onStart2ButtonClick()
    {
        Level2Screen.gameObject.SetActive(false);
        level2Instructions.gameObject.SetActive(false);
        level2Start.gameObject.SetActive(false);
    }
}

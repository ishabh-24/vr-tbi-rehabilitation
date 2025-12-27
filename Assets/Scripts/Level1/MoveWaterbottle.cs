using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Numerics;

public class MoveWaterbottle : MonoBehaviour
{
    public float delta = 0.01f; //public scaling factor 'delta'
    public float rotationAngle = 10f; //adjustable angle as per requirement
    public GameObject cap; 
    public GameObject waterBottle;
    public GameObject cup;
    public TextMeshProUGUI completedText;
    public TextMeshProUGUI notCompleted;
    public Button restartButton;
    public Button checkButton;
    
   
    private int pearlsPoured = 0;
    private int maxPearls = 8;
    private bool isCupFilled = false;

    void Start()
    {
        completedText.gameObject.SetActive(false);
        notCompleted.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        checkButton.gameObject.SetActive(false);
        
    }

    void Update()
    {
        // Pouring functionality
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PourPearls();
        }

        //Move down
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            UnityEngine.Vector3 position = this.transform.position;
            position.y -= delta;
            this.transform.position = position;
        }

        //Move up
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            UnityEngine.Vector3 position = this.transform.position;
            position.y += delta;
            this.transform.position = position;
            waterBottle.GetComponent<SphereCollider>().enabled = true;
        }

        //Move left
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            UnityEngine.Vector3 position = this.transform.position;
            position.z += delta;
            this.transform.position = position;
        }

        //Move right
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            UnityEngine.Vector3 position = this.transform.position;
            position.z -= delta;
            this.transform.position = position;
        }

        //Press Key 'R' to rotate clockwise
        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.Rotate(UnityEngine.Vector3.right, rotationAngle);
        }

        //Press Key 'F' to rotate counterclockwise
        if (Input.GetKeyDown(KeyCode.F))
        {
            transform.Rotate(UnityEngine.Vector3.right, -rotationAngle);
        }

        // Check for mouse click to remove cap
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == cap)
            {
                // Cap clicked, remove it
                cap.SetActive(false);
            }
        }
    }

    // Pouring functionality
    void PourPearls()
    {
        if (pearlsPoured == 0)
        {
            Rigidbody rb = waterBottle.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.useGravity = true;
        }

        pearlsPoured++;

        if (pearlsPoured >= maxPearls) // maxPearls is the total number of pearls in the water bottle
        {
            //pearls have been fully poured into the cup
            completedText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Pearl"))
        {
            // Disable gravity for pearls inside the water bottle
            other.GetComponent<Rigidbody>().useGravity = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pearl"))
        {
            // Enable gravity for pearls exiting the water bottle
            other.GetComponent<Rigidbody>().useGravity = true;
        }
    }

    public void ResetWaterBottle()
    {
        notCompleted.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        UnityEngine.Vector3 initialPosition = new UnityEngine.Vector3(-6f, 8.4f, 4.6f);
        this.transform.position = initialPosition;
        this.transform.rotation = UnityEngine.Quaternion.identity;

    }
}

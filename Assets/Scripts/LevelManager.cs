using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Numerics;

public class LevelManager : MonoBehaviour
{
    public Transform teleportPoint; // Reference to the teleportation point GameObject in Base2
    public GameObject cameraObject; // Reference to the main camera GameObject
    public GameObject directionalLight;
    public Button nextLevel;

    private void Start()
    {
        // Disable the teleport point initially
        teleportPoint.gameObject.SetActive(false);
    }

}
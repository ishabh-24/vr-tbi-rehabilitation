
using UnityEngine;

public class HandObjectController : MonoBehaviour
{
    void Update()
    {
        // Get the mouse position in screen coordinates
        Vector3 mousePosition = Input.mousePosition;

        // Convert the screen position to world position
        mousePosition.z = 10f; // Adjust this value to bring the hand into view
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Move the hand to the mouse position
        transform.position = worldPosition;
    }
}

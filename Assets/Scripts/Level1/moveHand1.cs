using UnityEngine;

public class moveHand1 : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of hand movement
    public float delta = 0.01f;

    void Update()
    {
        MoveHand();
    }

    void MoveHand()
    {
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

    }
}
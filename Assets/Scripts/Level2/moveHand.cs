using UnityEngine;

public class moveHand : MonoBehaviour
{
    public float speed = 50f; // Movement speed
    public float pickupRange = 2f; // Range to pick up objects
    public Transform holdParent; // Where to parent the picked object

    private Rigidbody rb;
    private Rigidbody heldObject = null;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }
        rb.isKinematic = false; // Ensure it can be moved by physics
    }

    void FixedUpdate()
    {
        // Handle movement
        Vector3 move = Vector3.zero;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            move.x -= speed * Time.fixedDeltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            move.x += speed * Time.fixedDeltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            move.y += speed * Time.fixedDeltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            move.y -= speed * Time.fixedDeltaTime;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            move.z += speed * Time.fixedDeltaTime;
        }
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            move.z -= speed * Time.fixedDeltaTime;
        }

        rb.velocity = move;

    }
}
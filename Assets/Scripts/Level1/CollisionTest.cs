using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    private bool isInsideBottle = true;
    public float buoyancyForce = 0f;
    public float fallForce = 1f;
    public float maxFallVelocity = 5f;
    public Collider topOpeningCollider; // Reference to the collider at the top opening of the water bottle

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pearl"))
        {
            if (isInsideBottle)
            {
                // Pearl entered the bottle, disable gravity and keep it inside
                Rigidbody pearlRB = other.GetComponent<Rigidbody>();
                pearlRB.useGravity = false;
                pearlRB.velocity = Vector3.zero;
                pearlRB.angularVelocity = Vector3.zero;
                isInsideBottle = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pearl"))
        {
            // Check if the pearl is exiting the collider
            Vector3 localPosition = transform.InverseTransformPoint(other.transform.position);
            if (localPosition.y < -4.21f)
            {
                // Pearl is exiting the collider, enable gravity to allow it to fall out
                Rigidbody pearlRB = other.GetComponent<Rigidbody>();
                pearlRB.useGravity = true;
                pearlRB.isKinematic = false;
                isInsideBottle = false;
            }

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Pearl"))
        {
            // Allow pearls to move within the water bottle
            Vector3 localPosition = transform.InverseTransformPoint(other.transform.position);
            if (localPosition.y > -4.21f)
            {
                // Pearl is within the collider and below the top opening, apply buoyancy force to simulate floating
                Rigidbody pearlRB = other.GetComponent<Rigidbody>();
                pearlRB.AddForce(Vector3.up * buoyancyForce);
            }
        }
    }


    private void FixedUpdate()
    {
        if (!isInsideBottle)
        {
            foreach (Transform child in transform)
            {
                if (child.CompareTag("Pearl"))
                {
                    Rigidbody pearlRB = child.GetComponent<Rigidbody>();
                    ApplyPearlExitBehavior(pearlRB);
                }
            }
        }
    }

    private void ApplyPearlExitBehavior(Rigidbody pearlRB)
    {
        if (pearlRB)
        {
            // Apply falling force to the pearl to simulate it falling off the water bottle
            if (topOpeningCollider.bounds.Contains(pearlRB.position))
            {
                pearlRB.useGravity = true; // Enable gravity to allow the pearl to fall
                pearlRB.isKinematic = false; // Disable kinematic to allow physics to take effect

                // Apply an additional force to keep the pearl on the surface of the water bottle
                Vector3 surfaceNormal = GetSurfaceNormal(pearlRB.position);
                pearlRB.AddForce(surfaceNormal * fallForce, ForceMode.Acceleration);
                pearlRB.velocity = Vector3.ClampMagnitude(pearlRB.velocity, maxFallVelocity);
            }
        }
    }

    private Vector3 GetSurfaceNormal(Vector3 position)
    {
        // Calculate the surface normal of the water bottle at the given position
        Vector3 localPosition = transform.InverseTransformPoint(position);
        Vector3 surfaceNormal = Vector3.up; // Default to upward direction

        if (localPosition.y >= -4.21f)
        {
            // Calculate the surface normal based on the curvature of the water bottle mesh
            // Modify this calculation based on the specific shape of your water bottle mesh
            float radius = Mathf.Sqrt(localPosition.x * localPosition.x + localPosition.z * localPosition.z);
            surfaceNormal = new Vector3(localPosition.x / radius, -4.21f, localPosition.z / radius);
        }

        return surfaceNormal;
    }
}

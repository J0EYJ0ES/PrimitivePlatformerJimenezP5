using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerControl : MonoBehaviour
{




    // Private variables
    public float moveSpeed = 5.0f;
    public float jumpForce = 5.0f;
    public Camera mainCamera;
    public Vector3 cameraOffset = new Vector3(0, 5, -10);

    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    // Update is called once per frame
    void Update()
    {
        // Get input from arrow keys or WASD
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calculate direction vector
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Move the object relative to time
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);

        // Jump input
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        // Respawn the player if they fall below a certain y-level (-5)
        if (transform.position.y < -5f)
        {
            transform.position = new Vector3(1f, 0.5f, 0f);

            // Reset Rigidbody velocity so the object doesn't continue falling after teleporting
            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }
    }

    // LateUpdate is called after all Update functions have been called
    void LateUpdate()
    {
        if (mainCamera != null)
        {
            // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
            mainCamera.transform.position = transform.position + cameraOffset;
        }
    }

    // Check if the player is on the ground
    private bool IsGrounded()
    {
        // Casts a ray downwards to check for collisions (0.6f is just over half the height of a default 1x1 primitive)
        return Physics.Raycast(transform.position, Vector3.down, 0.6f);
    }
}

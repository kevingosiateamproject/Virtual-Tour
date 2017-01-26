using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private Vector3 cameraRotation = Vector3.zero;

    private Rigidbody rb;

    private void Start()
    {
        // We are making sure we refernce the Rigidbody connected to Player
        rb = GetComponent<Rigidbody>();
    } 

    // Method that gets a movement vector
    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }

    public void Rotate(Vector3 _rotation)
    {
        rotation = _rotation;
    }

    public void RotateCamera(Vector3 _cameraRotation)
    {
        cameraRotation = _cameraRotation;
    }

    // Runs every physics iteration
    void FixedUpdate()
    {
        // We want to preform our movement by calling a method
        PerformMovement();
        PerformRotation();
    }

    // We are performing movement based on the velocity variable
    void PerformMovement()
    {
        if(velocity != Vector3.zero)
        {
            // MovePosition checks all the physics so Player will collide with object
            // Here we move the Rigidbody of the player in real time based on the velocity.
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }

    void PerformRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        if(cam != null)
        {
            cam.transform.Rotate(-cameraRotation);
        }
    }
}
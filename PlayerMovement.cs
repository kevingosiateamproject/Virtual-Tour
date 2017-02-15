using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private float cameraRotationX = 0f;
    private float currentCameraRotationX = 0f;
    private Vector3 Force = Vector3.zero;

    [SerializeField]
    private float cameraRotationLimit = 85f;

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

    public void RotateCamera(float _cameraRotationX)
    {
        cameraRotationX = _cameraRotationX;
    }

    // Gets a force vector
    public void ApplyForce(Vector3 _Force)
    {
        Force = _Force;
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

        if(Force != Vector3.zero)
        {
            rb.AddForce(Force * Time.fixedDeltaTime, ForceMode.Acceleration);
        }
    }

    void PerformRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        if(cam != null)
        {
            //New rotational calculation
            currentCameraRotationX -= cameraRotationX;
            // Mathf.Clamp will clamp the currentCameraRotationX between the next two values
            currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);

            // The rotation as Euler angles in degrees relative to the parent transform's rotation.
            // Apply our rotation to the transform of our camera
            cam.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);
        }
    }
}
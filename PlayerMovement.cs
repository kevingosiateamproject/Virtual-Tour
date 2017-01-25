using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    private Vector3 velocity = Vector3.zero;

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

    // Runs every physics iteration
    void FixedUpdate()
    {
        // We want to preform our movement by calling a method
        PerformMovement();
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
}
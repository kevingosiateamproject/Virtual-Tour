using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float speed = 5f;

    private PlayerMovement movement;

    void Start()
    {
        movement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        // Calculate movement as a 3D vector
        float _xMov = Input.GetAxisRaw("Horizontal");
        float _zMov = Input.GetAxisRaw("Vertical");

        Vector3 _movHorizontal = transform.right * _xMov; // (1, 0, 0)
        Vector3 _movVertical = transform.forward * _zMov; // (0, 0, 1)

        // Final Movement vector
        Vector3 _velocity = (_movHorizontal + _movVertical).normalized * speed;

        // Apply Movement
        movement.Move(_velocity);
    }
}

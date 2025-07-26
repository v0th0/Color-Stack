using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovementNew : MonoBehaviour
{
    public float forwardSpeed = 5f;
    public float strafeSpeed = 3f;

    private Vector2 moveInput;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        // Auto-move forward
        Vector3 forwardMove = transform.forward * forwardSpeed;

        // Left/Right move from input (X only)
        Vector3 sideMove = transform.right * moveInput.x * strafeSpeed;

        Vector3 movement = (forwardMove + sideMove) * Time.fixedDeltaTime;

        rb.MovePosition(rb.position + movement);
    }
}

using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public InputAction MoveKeys;
    public InputAction RotateKeys;
    Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MoveKeys.Enable();
        RotateKeys.Enable();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveDirection = MoveKeys.ReadValue<Vector2>();
        rb.AddRelativeForce(moveDirection * moveSpeed, ForceMode2D.Force);
        Vector2 rotationDirection = RotateKeys.ReadValue<Vector2>();
        transform.Rotate(transform.rotation.x, transform.rotation.y, rotationDirection.x);
    }
}

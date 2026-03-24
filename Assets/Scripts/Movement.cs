using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public float maxSpeed = 10f;
    public float moveSpeed;
    public InputAction MoveKeys;
    public InputAction RotateKeys;
    public InputAction BoostKey;
    Rigidbody2D rb;

    public float boostSpeed = 25f;
    public bool canBoost;
    public float boostTime = 3f;
    public float boostCooldown = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MoveKeys.Enable();
        RotateKeys.Enable();
        BoostKey.Enable();
        rb = GetComponent<Rigidbody2D>();
        canBoost = true;
        moveSpeed = maxSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveDirection = MoveKeys.ReadValue<Vector2>();
        rb.AddRelativeForce(moveDirection * moveSpeed, ForceMode2D.Force);
        Vector2 rotationDirection = RotateKeys.ReadValue<Vector2>();
        transform.Rotate(transform.rotation.x, transform.rotation.y, rotationDirection.x);

        if (BoostKey.WasPressedThisFrame() && canBoost == true)
        {
            moveSpeed = boostSpeed;
            canBoost = false;
            Invoke("ResetBoosting", boostTime);

        }
    }

    void ResetBoosting()
    {
        moveSpeed = maxSpeed;
        Invoke("BoostingCooldown", boostCooldown);
    }
    void BoostingCooldown()
    {
        canBoost = true;
    }
}

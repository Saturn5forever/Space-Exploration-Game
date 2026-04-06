using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public float maxSpeed = 10f;
    public float moveSpeed;
    public InputAction MoveKeys;
    public InputAction RotateKeys;
    public float rotationSpeed = 0.5f;
    
    Rigidbody2D rb;

    public InputAction BoostKey;
    public float boostSpeed = 32f;
    private bool canBoost;
    public float boostTime = 3f;
    public float boostCooldownDuration = 10f;
    public Image cooldownOverlay;
    private float remainingTime;

    AudioSource audioSource;
    public AudioClip movingAudio;
    public AudioClip collisionSound;
    private bool isMoving = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        MoveKeys.Enable();
        RotateKeys.Enable();
        BoostKey.Enable();
        rb = GetComponent<Rigidbody2D>();
        canBoost = true;
        moveSpeed = maxSpeed;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Object"))
        {
            audioSource.PlayOneShot(collisionSound);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 moveDirection = MoveKeys.ReadValue<Vector2>();
        rb.AddRelativeForce(moveDirection * moveSpeed * 100 * Time.deltaTime, ForceMode2D.Force);
        Vector2 rotationDirection = RotateKeys.ReadValue<Vector2>();
        transform.Rotate(transform.rotation.x, transform.rotation.y, rotationDirection.x * rotationSpeed);

    }

    void Update()
    {
        if (BoostKey.WasPressedThisFrame() && canBoost == true)
        {
            moveSpeed = boostSpeed;
            canBoost = false;
            StartCoroutine(BoostingCooldown());
        }
        if (MoveKeys.IsPressed())
        {
            if (!isMoving)
            {
                audioSource.Play();
                isMoving = true;
            }
            
        }
        else
        {
            if (isMoving)
            {
                audioSource.Stop();
                isMoving = false;
            }
        }
    }

    IEnumerator BoostingCooldown()
    {
        canBoost = false;
        remainingTime = boostCooldownDuration;
        yield return new WaitForSeconds(boostTime);
        moveSpeed = maxSpeed;
        cooldownOverlay.fillAmount = 1f;
        while(remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            UpdateCooldownUI();
            yield return null;
        }
        canBoost = true;
        cooldownOverlay.fillAmount = 0f;
    }

    void UpdateCooldownUI()
    {
        cooldownOverlay.fillAmount = remainingTime / boostCooldownDuration;
    }

}   

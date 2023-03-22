using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float MovementSpeed;
    [SerializeField] public float JumpStrength;

    Rigidbody2D rb;
    PlayerControls controls;
    float movement;
    bool isGrounded;


    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        controls = new PlayerControls();

        controls.Player.Movement.performed += context => movement = context.ReadValue<float>();
        controls.Player.Movement.canceled += _ => movement = 0;

        controls.Player.Jump.started += _ => Jump();
    }

    private void OnEnable() => controls.Enable();
    private void OnDisable() => controls.Disable();

    // Update is called once per frame
    void Update()
    {
        if (movement < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (movement > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(movement * MovementSpeed, rb.velocity.y);
    }

    void Jump()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpStrength);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}

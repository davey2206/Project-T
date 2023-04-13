using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float MovementSpeed;
    [SerializeField] public float JumpStrength;

    Animator animator;
    Rigidbody2D rb;
    PlayerControls controls;
    float movement;
    bool isGrounded;
    float coyoteTime = 0.2f;
    float coyoteTimeCounter;


    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
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
        coyoteJump();
        if (movement < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            animator.SetBool("Moving", true);
        }
        else if (movement > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            animator.SetBool("Moving", true);
        }
        else
        {
            animator.SetBool("Moving", false);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(movement * MovementSpeed, rb.velocity.y);
    }

    void Jump()
    {
        if (coyoteTimeCounter > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpStrength);

            coyoteTimeCounter = 0f;
            isGrounded = false;
        }
    }

    void coyoteJump()
    {
        if (isGrounded) 
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Box"))
        {
            isGrounded = true;
        }
    }
}

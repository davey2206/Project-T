using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] ControlPanel panel;
    float vertical, horizontal;
    Rigidbody2D rigidbody2D;
    GameObject box2D;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (panel.GetActiveState())
        {
            parent();
            MoveCrane();
        }

        else
        {
            rigidbody2D.velocity = Vector3.zero;
        }
    }
    private void parent()
    {
        if (Input.GetKeyDown(KeyCode.Space) && box2D != null)
        {
            box2D.transform.parent = GameObject.Find("Persistent").transform;
            box2D.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            box2D = null;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Box") && box2D == null)
        {
            box2D = collision.gameObject;
            box2D.transform.parent = transform;
            box2D.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            box2D.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;

        }
    }
    void MoveCrane()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        rigidbody2D.velocity = new Vector2(horizontal * moveSpeed, vertical * moveSpeed);
    }
}

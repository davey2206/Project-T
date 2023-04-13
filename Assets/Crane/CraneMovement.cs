using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    float vertical, horizontal;
    Rigidbody2D rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject go in gameObjectArray)
        {
            go.SetActive(false);
        }

        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveCrane();
    }

    void MoveCrane()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        rigidbody2D.velocity = new Vector2(horizontal * moveSpeed, vertical * moveSpeed);
    }
}

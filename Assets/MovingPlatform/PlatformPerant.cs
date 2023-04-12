using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPerant : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.parent = transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.parent = GameObject.Find("Persistent").transform;
        }
    }
}

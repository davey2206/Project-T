using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneParent : MonoBehaviour
{
    GameObject box2D;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Box"))
        {
            collision.transform.parent = transform;
            if (Input.GetKeyUp(KeyCode.Space))
            {
                Debug.Log("spaaaaaaaaaace");
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Box"))
        {
            
            collision.transform.parent = GameObject.Find("Persistent").transform;

            
        }
    }
}

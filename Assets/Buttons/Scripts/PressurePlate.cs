using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    Button_Transmitter transmitter;

    // Start is called before the first frame update
    void Start()
    {
        transmitter = GetComponent<Button_Transmitter>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Box"))
        {
            StartCoroutine(onExit());
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Box"))
        {
            StopAllCoroutines();
            transmitter.SetState(true);
        }
    }

    IEnumerator onExit()
    {
        yield return new WaitForSeconds(0.5f);
        transmitter.SetState(false);
    }
}

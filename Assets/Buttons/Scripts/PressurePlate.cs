using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    Button_Transmitter transmitter;
    [SerializeField][Range(0, 1)] float timeActiveAfterRelease;

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
        yield return new WaitForSeconds(timeActiveAfterRelease);
        transmitter.SetState(false);
    }
}

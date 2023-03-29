using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    Button_Receiver receiver;
    [SerializeField] GameObject door;

    void Start()
    {
        receiver = GetComponent<Button_Receiver>();
    }

    private void Update()
    {
        if (receiver.CheckAllTransmittersState())
        {
            door.SetActive(false);
        }
        else
        {
            door.SetActive(true);
        }
    }
}

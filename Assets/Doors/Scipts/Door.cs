using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    Button_Receiver receiver;
    Switch_Receiver SwitchReceiver;
    [SerializeField] GameObject door;
    [SerializeField] bool UseSwitch;

    void Start()
    {
        receiver = GetComponent<Button_Receiver>();
        SwitchReceiver = GetComponent<Switch_Receiver>();
    }

    public void Update()
    {
        if (UseSwitch)
        {
            Switch();
        }
        else
        {
            Button();
        }
    }

    public void Switch()
    {
        if (SwitchReceiver.getState())
        {
            door.SetActive(false);
        }
        else
        {
            door.SetActive(true);
        }
    }

    public void Button()
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

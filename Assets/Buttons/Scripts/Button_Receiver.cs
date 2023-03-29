using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Receiver : MonoBehaviour
{
    [SerializeField] List<Button_Transmitter> transmitters;

    public bool CheckAllTransmittersState()
    {
        foreach (var transmitter in transmitters)
        {
            if (transmitter.GetState() == false)
            {
                return false;
            }
        }

        return true;
    }
}

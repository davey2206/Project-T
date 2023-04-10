using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_Transmitter : MonoBehaviour
{
    [SerializeField] List<Switch_Receiver> receivers;

    public void SwitchStates()
    {
        foreach (var receiver in receivers)
        {
            receiver.SwitchState();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Transmitter : MonoBehaviour
{
    bool State;

    public bool GetState()
    {
        return State;
    }

    public void SetState(bool s)
    {
        State = s;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_Receiver : MonoBehaviour
{
    bool state = false;

    public void SwitchState()
    {
        state = !state;
    }

    public bool getState()
    {
        return state;
    }
}

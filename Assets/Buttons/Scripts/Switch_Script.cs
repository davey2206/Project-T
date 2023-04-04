using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Switch_Script : MonoBehaviour
{
    [SerializeField] bool useSwitch;
    bool isPressed = false;
    float dist;
    GameObject player;

    Switch_Transmitter SwitchTransmitter;
    Button_Transmitter ButtonTransmitter;

    private void Start()
    {
        player = GameObject.Find("Player");
        SwitchTransmitter = GetComponent<Switch_Transmitter>();
        ButtonTransmitter = GetComponent<Button_Transmitter>();
    }

    private void Update()
    {
        dist = Vector2.Distance(transform.position, player.transform.position);

        if (!useSwitch)
        {
            Button();
        }
    }

    public void Button()
    {
        isPressed = !isPressed;
        ButtonTransmitter.SetState(isPressed);
    }

    public void Switch(InputAction.CallbackContext context)
    {
        if (!useSwitch) return;

        if (!context.started) return;

        if (dist > 20) return;

        SwitchTransmitter.SwitchStates();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControlPanel : MonoBehaviour
{
    private float dist;
    GameObject player;
    bool active = false;

    public bool GetActiveState()
    {
        Debug.Log(active);
        return active;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    public void Switch(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        if (dist > 12) return;

        active = !active;

        if (active)
        {
            player.GetComponent<PlayerMovement>().enabled = false;
        }

        else
        {
            player.GetComponent<PlayerMovement>().enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector2.Distance(transform.position, player.transform.position);
    }
}

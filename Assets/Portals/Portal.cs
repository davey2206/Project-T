using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Portal : MonoBehaviour
{
    GameObject player;
    PortalManager portalManager;

    float dist;

    private void Start()
    {
        player = GameObject.Find("Player");
        portalManager = GameObject.Find("PortalManager").GetComponent<PortalManager>();
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector2.Distance(transform.position, player.transform.position);
    }

    public void SwitchTime(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        if (dist > 20) return;

        portalManager.SwitchTime();
    }
}

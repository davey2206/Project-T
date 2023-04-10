using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    [SerializeField] GameObject past;
    [SerializeField] GameObject present;

    public bool time = false;

    public void SwitchTime()
    {
        time = !time;
        past.SetActive(!past.activeInHierarchy);
        present.SetActive(!past.activeInHierarchy);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset_WhenTouched : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var player = collision.GetComponent<PlayerRewind>();

            if (!player.GetActive())
            {
                collision.GetComponent<PlayerRewind>().StartRewindTimeToStart();
            }
            
        }
    }
}

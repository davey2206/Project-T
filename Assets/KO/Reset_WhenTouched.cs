using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset_WhenTouched : MonoBehaviour
{
    public PlayerMovement movement;
    void OnCollisionEnter( Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Death")
        {
            movement.enabled = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
        }
    }
}

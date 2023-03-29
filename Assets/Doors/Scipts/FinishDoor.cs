using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishDoor : MonoBehaviour
{
    SceneManager_Script sceneManager;

    private void Start()
    {
        sceneManager= GameObject.Find("SceneManager").GetComponent<SceneManager_Script>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            sceneManager.LoadNextScene();
        }
    }
}

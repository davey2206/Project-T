using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager_Script : MonoBehaviour
{
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadLevel(int Level)
    {
        SceneManager.LoadScene(Level - 1);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager_Script : MonoBehaviour
{
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (SceneManager.sceneCountInBuildSettings != currentSceneIndex + 1)
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
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

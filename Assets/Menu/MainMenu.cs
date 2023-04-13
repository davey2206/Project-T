using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject Menu;
    [SerializeField] GameObject Setting;
    bool settingsActive = false;
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);   
    }

    public void ToggleSettings()
    {
        settingsActive = !settingsActive;

        if (settingsActive)
        {
            Menu.SetActive(false);
            Setting.SetActive(true);
        }
        else
        {
            Menu.SetActive(true);
            Setting.SetActive(false);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

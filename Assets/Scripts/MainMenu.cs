using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public string nextSceneToLoad;
    public string backToHomescreen;
    public bool isPaused = false;
    public GameObject pauseMenu;
    public GameObject confirmQuit;
    public void Resume()
    {
        Time.timeScale = 1f;
        isPaused = false;
        pauseMenu.SetActive(false);
    }
    public void Pause()
    {
        isPaused = true;
        if (isPaused == true)
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
        }
    }
    public void ConfirmQuit()
    {
        confirmQuit.SetActive(true);
    }
    public void BackToHomescreen()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(backToHomescreen);
    }
}

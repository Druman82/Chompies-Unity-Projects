using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public string mainMenuLevel;
    public GameObject pauseMenu;
    public GameObject pauseButton;
    public PlayfabManager playfabManager;

    public void PauseGame()
    {
        Cursor.visible = true;
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);   
    }

    public void ResumeGame()
    {
        Cursor.visible = false;
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
    }

    public void QuitToMain()
    {
        Cursor.visible = true;
        Time.timeScale = 1f;
        Settings.difficulty = 2;
        Settings.recks = false;
        Settings.easy = false;
        SceneManager.LoadScene(mainMenuLevel);

    }
}

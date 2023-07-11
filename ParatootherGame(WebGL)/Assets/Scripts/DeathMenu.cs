using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class DeathMenu : MonoBehaviour
{
    public string mainMenuLevel;
    public GameObject pauseButton;
    public GameObject pauseMenu;
    public TextMeshProUGUI gameOverText;

    void Update()
    {
        Cursor.visible = true;
        pauseButton.SetActive(false);
        pauseMenu.SetActive(false);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            RestartGame();
        }
        if(Settings.points >= 100 && Settings.points <= 499)
        {
            gameOverText.text = "oops!";
        }
        else if (Settings.points >= 500 && Settings.points <= 999)
        {
            gameOverText.text = "well...";
        }
        else if(Settings.points >= 1000 && Settings.points <= 1999)
        {
            gameOverText.text = "not terrible";
        }
        else if (Settings.points >= 2000 && Settings.points <= 3999)
        {
            gameOverText.text = "you're trying";
        }
        else if (Settings.points >= 4000 && Settings.points <= 6999)
        {
            gameOverText.text = "adequate";
        }
        else if (Settings.points >= 7000 && Settings.points <= 9999)
        {
            gameOverText.text = "good game";
        }
        else if (Settings.points >= 10000 && Settings.points <= 14999)
        {
            gameOverText.text = "way to go!";
        }        
        else if (Settings.points >= 15000 && Settings.points <= 19999)
        {
            gameOverText.text = "great scott!";
        }
        else if (Settings.points >= 20000 && Settings.points <= 39999)
        {
            gameOverText.text = "unbelieveable";
        }
        else if (Settings.points >= 40000 && Settings.points <= 59999)
        {
            gameOverText.text = "Whaaaa???";
        }        
        else if (Settings.points >= 60000 && Settings.points <= 89999)
        {
            gameOverText.text = "Master!!!";
        }
        else if (Settings.points >= 90000 && Settings.points <= 119999)
        {
            gameOverText.text = "you legend!!!";
        }
        else if (Settings.points >= 120000)
        {
            gameOverText.text = "recks?";
        }
    }
    public void RestartGame()
    {
        Cursor.visible = false;
        pauseButton.SetActive(true);
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);

        FindObjectOfType<GameManager>().Reset();
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

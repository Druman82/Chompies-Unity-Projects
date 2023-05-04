using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LeaderboardMenu : MonoBehaviour
{
    public string mainMenu;
    public AudioSource theWayToFindHome;

    void Start()
    {
        if (Settings.creditsMenu == true && Settings.musicBool == false)
        {
            theWayToFindHome.Stop();
        }
        else if (Settings.creditsMenu == true && Settings.musicBool == true)
        {
            theWayToFindHome.Play();
        }
    }

    public void MainMenu()
    {
        StartCoroutine("BackToMain");
    }

    public IEnumerator BackToMain()
    {
        yield return new WaitForSeconds(0.5f);
        Settings.creditsMenu = false;
        SceneManager.LoadScene(mainMenu);
    }
}

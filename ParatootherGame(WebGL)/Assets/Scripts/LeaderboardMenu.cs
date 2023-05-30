using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LeaderboardMenu : MonoBehaviour
{
    public string mainMenu;
    public AudioSource theWayToFindHome;
    public GameObject share;
    public string houseMenu;

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
        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            share.gameObject.SetActive(true);
        }
        else
        {
            share.gameObject.SetActive(false);
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

    public void HouseMenu()
    {
        StartCoroutine("GoToHouseMenu");
    }

    public IEnumerator GoToHouseMenu()
    {
        yield return new WaitForSeconds(0.75f);
        SceneManager.LoadScene(houseMenu);
    }
}

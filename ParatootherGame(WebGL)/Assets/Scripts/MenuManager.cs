using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public PauseMenu pauseMenu;
    public GameObject PauseButton;
    public GameObject share;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1f)
            {
                Cursor.visible = true;
                Time.timeScale = 0f;
                PauseButton.SetActive(false);
            }
            else if(Time.timeScale == 0f)
            {
                Cursor.visible = false;
                Time.timeScale = 1f;
                PauseButton.SetActive(true);
            }
            pauseMenu.gameObject.SetActive(!pauseMenu.gameObject.activeSelf);
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
}

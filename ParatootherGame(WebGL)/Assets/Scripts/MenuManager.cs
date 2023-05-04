using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public PauseMenu pauseMenu;
    public GameObject PauseButton;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastingToObject : MonoBehaviour
{

    public static string selectedObject;
    public string internalObject;
    public RaycastHit theObject;
    public MainMenu mainMenu;
    [SerializeField] public Transform none;
    [SerializeField] public Transform bear;
    [SerializeField] public Transform dad;
    [SerializeField] public Transform gac;
    [SerializeField] public Transform turtle;
    [SerializeField] public Transform samurai;
    public AudioSource selectSound;

    void Start()
    {
        mainMenu = FindObjectOfType<MainMenu>();
        //Cursor.lockState = CursorLockMode.Locked;

    }

    void Update()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out theObject))
        {
            selectedObject = theObject.transform.gameObject.name;
            internalObject = theObject.transform.gameObject.name;
            internalObject.ToString();
        }
        /*
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            mouseX = Input.GetTouch(0).deltaPosition.x;
            mouseY = Input.GetTouch(0).deltaPosition.y;
        }*/

        if (Input.GetMouseButtonDown(0))
        {
            if (internalObject == "None")
            {
                if (Settings.soundFXBool == true)
                {
                    selectSound.Play();
                }
                none.gameObject.SetActive(false);
                bear.gameObject.SetActive(true);
                dad.gameObject.SetActive(true);
                gac.gameObject.SetActive(true);
                turtle.gameObject.SetActive(true);
                samurai.gameObject.SetActive(true);

                Settings.target = 1;

                Settings.none = true;
                Settings.bear = false;
                Settings.dad = false;
                Settings.gac = false;
                Settings.turtle = false;
                Settings.samuria = false;
                Settings.among = false;

            }
            if (internalObject == "Bear")
            {
                if (Settings.soundFXBool == true)
                {
                    selectSound.Play();
                }
                none.gameObject.SetActive(true);
                bear.gameObject.SetActive(false);
                dad.gameObject.SetActive(true);
                gac.gameObject.SetActive(true);
                turtle.gameObject.SetActive(true);
                samurai.gameObject.SetActive(true);

                Settings.target = 3;

                Settings.none = false;
                Settings.bear = true;
                Settings.dad = false;
                Settings.gac = false;
                Settings.turtle = false;
                Settings.samuria = false;
                Settings.among = false;

            }
            if (internalObject == "Dad")
            {
                if (Settings.soundFXBool == true)
                {
                    selectSound.Play();
                }
                none.gameObject.SetActive(true);
                bear.gameObject.SetActive(true);
                dad.gameObject.SetActive(false);
                gac.gameObject.SetActive(true);
                turtle.gameObject.SetActive(true);
                samurai.gameObject.SetActive(true);

                Settings.target = 5;

                Settings.none = false;
                Settings.bear = false;
                Settings.dad = true;
                Settings.gac = false;
                Settings.turtle = false;
                Settings.samuria = false;
                Settings.among = false;

            }
            if (internalObject == "GAC")
            {
                if (Settings.soundFXBool == true)
                {
                    selectSound.Play();
                }
                none.gameObject.SetActive(true);
                bear.gameObject.SetActive(true);
                dad.gameObject.SetActive(true);
                gac.gameObject.SetActive(false);
                turtle.gameObject.SetActive(true);
                samurai.gameObject.SetActive(true);

                Settings.target = 4;

                Settings.none = false;
                Settings.bear = false;
                Settings.dad = false;
                Settings.gac = true;
                Settings.turtle = false;
                Settings.samuria = false;
                Settings.among = false;

            }

            if (internalObject == "Turtle")
            {
                if (Settings.soundFXBool == true)
                {
                    selectSound.Play();
                }
                none.gameObject.SetActive(true);
                bear.gameObject.SetActive(true);
                dad.gameObject.SetActive(true);
                gac.gameObject.SetActive(true);
                turtle.gameObject.SetActive(false);
                samurai.gameObject.SetActive(true);

                Settings.target = 1;

                Settings.none = false;
                Settings.bear = false;
                Settings.dad = false;
                Settings.gac = false;
                Settings.turtle = true;
                Settings.samuria = false;
                Settings.among = false;

            }
            if (internalObject == "Samurai")
            {
                if (Settings.soundFXBool == true)
                {
                    selectSound.Play();
                }
                none.gameObject.SetActive(true);
                bear.gameObject.SetActive(true);
                dad.gameObject.SetActive(true);
                gac.gameObject.SetActive(true);
                turtle.gameObject.SetActive(true);
                samurai.gameObject.SetActive(false);

                Settings.target = 1;

                Settings.none = false;
                Settings.bear = false;
                Settings.dad = false;
                Settings.gac = false;
                Settings.turtle = false;
                Settings.samuria = true;
                Settings.among = false;

            }
            if (internalObject == "Door")
            {
                Cursor.lockState = CursorLockMode.None;
                mainMenu.StartGame();
            }
        }
    }
}

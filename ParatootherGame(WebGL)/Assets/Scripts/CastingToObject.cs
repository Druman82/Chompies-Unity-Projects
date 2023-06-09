using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class CastingToObject : MonoBehaviour
{
    public static string selectedObject;
    public string internalObject;
    public RaycastHit theObject;
    public MainMenu mainMenu;
    public string firstLevel;
    public string easyLevel;
    public string recksLevel;
    public MainMenu leaderboard;
    public MainMenu apeGangLeaderboard;
    public MainMenu brawlerBearsLeaderboard;
    public MainMenu cryptoDadsLeaderboard;
    public MainMenu gamingApeClubLeaderboard;
    public MainMenu hikeshiLeaderboard;
    public MainMenu spaceRidersLeaderboard;
    public MainMenu tacoTribeLeaderboard;
    public MainMenu thePlagueLeaderboard;
    public MainMenu teamLeaderboard;
    public MainMenu loginScreen;
    public string options;
    public string credits;
    public string achievements;
    public TextMeshProUGUI progressText;
    public Slider slider;
    public GameObject loadingScreen;
    public Vector3 offset;
    [SerializeField] public Transform none;
    [SerializeField] public Transform bear;
    [SerializeField] public Transform dad;
    [SerializeField] public Transform gac;
    [SerializeField] public Transform turtle;
    [SerializeField] public Transform samurai;
    [SerializeField] public Transform noneHeld;
    [SerializeField] public Transform bearHeld;
    [SerializeField] public Transform dadHeld;
    [SerializeField] public Transform gacHeld;
    [SerializeField] public Transform turtleHeld;
    [SerializeField] public Transform samuraiHeld;
    [SerializeField] public Transform howToPlay;
    [SerializeField] public Transform shelfMovable;
    [SerializeField] public Transform shelfHeld;
    [SerializeField] public Transform shelfOnFence;
    [SerializeField] public Transform padLock;

    public AudioSource selectSound;

    void Start()
    {
        mainMenu = FindObjectOfType<MainMenu>();
        //Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out theObject, 2.5f))
        {
            selectedObject = theObject.transform.gameObject.name;
            internalObject = theObject.transform.gameObject.name;
            internalObject.ToString();
        }

        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            Select();
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                Select();
            }
        }
    }

    public void Select()
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
            noneHeld.gameObject.SetActive(true);
            bearHeld.gameObject.SetActive(false);
            dadHeld.gameObject.SetActive(false);
            gacHeld.gameObject.SetActive(false);
            turtleHeld.gameObject.SetActive(false);
            samuraiHeld.gameObject.SetActive(false);
            shelfMovable.gameObject.SetActive(true);
            shelfHeld.gameObject.SetActive(false);

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
            noneHeld.gameObject.SetActive(false);
            bearHeld.gameObject.SetActive(true);
            dadHeld.gameObject.SetActive(false);
            gacHeld.gameObject.SetActive(false);
            turtleHeld.gameObject.SetActive(false);
            samuraiHeld.gameObject.SetActive(false);
            shelfMovable.gameObject.SetActive(true);
            shelfHeld.gameObject.SetActive(false);

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
            noneHeld.gameObject.SetActive(false);
            bearHeld.gameObject.SetActive(false);
            dadHeld.gameObject.SetActive(true);
            gacHeld.gameObject.SetActive(false);
            turtleHeld.gameObject.SetActive(false);
            samuraiHeld.gameObject.SetActive(false);
            shelfMovable.gameObject.SetActive(true);
            shelfHeld.gameObject.SetActive(false);

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
            noneHeld.gameObject.SetActive(false);
            bearHeld.gameObject.SetActive(false);
            dadHeld.gameObject.SetActive(false);
            gacHeld.gameObject.SetActive(true);
            turtleHeld.gameObject.SetActive(false);
            samuraiHeld.gameObject.SetActive(false);
            shelfMovable.gameObject.SetActive(true);
            shelfHeld.gameObject.SetActive(false);

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
            noneHeld.gameObject.SetActive(false);
            bearHeld.gameObject.SetActive(false);
            dadHeld.gameObject.SetActive(false);
            gacHeld.gameObject.SetActive(false);
            turtleHeld.gameObject.SetActive(true);
            samuraiHeld.gameObject.SetActive(false);
            shelfMovable.gameObject.SetActive(true);
            shelfHeld.gameObject.SetActive(false);

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
            noneHeld.gameObject.SetActive(false);
            bearHeld.gameObject.SetActive(false);
            dadHeld.gameObject.SetActive(false);
            gacHeld.gameObject.SetActive(false);
            turtleHeld.gameObject.SetActive(false);
            samuraiHeld.gameObject.SetActive(true);
            shelfMovable.gameObject.SetActive(true);
            shelfHeld.gameObject.SetActive(false);

            Settings.target = 1;

            Settings.none = false;
            Settings.bear = false;
            Settings.dad = false;
            Settings.gac = false;
            Settings.turtle = false;
            Settings.samuria = true;
            Settings.among = false;

        }

        if (internalObject == "ShelfMovable")
        {
            shelfMovable.gameObject.SetActive(false);
            shelfHeld.gameObject.SetActive(true);
            none.gameObject.SetActive(true);
            bear.gameObject.SetActive(true);
            dad.gameObject.SetActive(true);
            gac.gameObject.SetActive(true);
            turtle.gameObject.SetActive(true);
            samurai.gameObject.SetActive(true);
            noneHeld.gameObject.SetActive(false);
            bearHeld.gameObject.SetActive(false);
            dadHeld.gameObject.SetActive(false);
            gacHeld.gameObject.SetActive(false);
            turtleHeld.gameObject.SetActive(false);
            samuraiHeld.gameObject.SetActive(false);
        }

        if (internalObject == "BrokenFence" && shelfHeld.gameObject.activeSelf)
        {
            shelfHeld.gameObject.SetActive(false);
            shelfOnFence.gameObject.SetActive(true);
        }

        if (internalObject == "Lock" && Settings.goldKeyHeld)
        {
            padLock.gameObject.SetActive(false);
            Settings.chestUnlock = true;
        }

        if (internalObject == "Door")
        {
            Cursor.lockState = CursorLockMode.None;
            if (Settings.difficulty == 1)
            {
                LoadLevel(easyLevel);
            }
            else if (Settings.difficulty == 2)
            {
                LoadLevel(firstLevel);
            }
            else if (Settings.difficulty == 3)
            {
                LoadLevel(recksLevel);
            }
            Settings.threeD = false;
            Settings.night = false;
            Settings.points = 0;
            Settings.rocketCount = 0;
            Settings.jetpack = false;
            Settings.jetpackStart = false;
            Settings.space = false;
            Settings.glasses = false;
            Settings.frg = false;
            Settings.hoverboard = false;
            Settings.crownCoin = 0;
            Settings.tokenNum = 0;
            Settings.ninjaStarCount = 0;
            Settings.batteryCount = 0;
            Settings.pillowCount = 0;
            Settings.bubblegumCount = 0;
            Settings.coins = 0;
            Settings.sewer = false;
            Settings.sewerPipe = false;
            Settings.slots = false;
            Settings.slotBG = false;
            Settings.city = false;
            Settings.turtleShell = false;
            Settings.helmet = false;
            Settings.spaceship = false;
            Settings.spaceshipStart = false;
            Settings.bed = false;
            Settings.gameLevel = true;
            Settings.candyland = false;
            Settings.openHouse = false;
            Settings.house = false;
            Settings.raceLevel = false;
            Settings.hotAirBalloon = false;
            Settings.hotAirBalloonStart = false;
            Settings.portal = false;
            Settings.levelSewer = false;
            Settings.levelCity = false;
            Settings.levelHouse = false;
            Settings.levelCandyland = false;
            Settings.levelSpace = false;
            Settings.levelChange = false;
            CameraFollow.jetpack = false;
            CameraFollow.up = 0;
            CameraFollow.portal = false;
            CameraFollow.frogFeet = false;
        }

        if (internalObject == "Start")
        {
            Cursor.lockState = CursorLockMode.None;
            LoadLevel(firstLevel);
        }

        if (internalObject == "Leaderboards")
        {
            Cursor.lockState = CursorLockMode.None;
            mainMenu.Leaderboard();
        }

        if (internalObject == "Credits")
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(credits);
        }

        if (internalObject == "Quit")
        {
            Application.Quit();
        }

        if (internalObject == "Options")
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(options);

        }

        if (internalObject == "Achievements")
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(achievements);
        }

        if (internalObject == "HowToPlay")
        {
            //Cursor.lockState = CursorLockMode.None;
            HowToPlay();
        }

        if (internalObject == "LogOut")
        {
            Cursor.lockState = CursorLockMode.None;
            mainMenu.LoginScreens();
        }

        if (internalObject == "MainMenu")
        {
            //Cursor.lockState = CursorLockMode.None;
            ComputerMain();
        }
    }

    public void HowToPlay()
    {
        howToPlay.gameObject.SetActive(true);
        //menu.gameObject.SetActive(false);
    }

    public void ComputerMain()
    {
        howToPlay.gameObject.SetActive(false);
    }

    public void LoadLevel(string gameLevel)
    {
        StartCoroutine(LoadAsynchronously(gameLevel));
    }

    IEnumerator LoadAsynchronously(string gameLevel)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(gameLevel);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            slider.value = progress;
            progressText.text = (progress * 100f).ToString("0") + "%";

            yield return null;
        }
    }
}

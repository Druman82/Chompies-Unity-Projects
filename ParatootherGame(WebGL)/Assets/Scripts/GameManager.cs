using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform platformGenerator;
    private Vector3 platformStartPoint;
    public Transform cloudGenerator;
    private Vector3 cloudStartPoint;
    public RacePlayerMovementKeyboard racePlayer;
    public Player thePlayer;
    public Player amongPlayer;
    public Player bearPlayer;
    public Player gacPlayer;
    public Player dadPlayer;
    public Player plaguePlayer;
    private Vector3 playerStartPoint;
    private PlatformDestroyer[] platformList;
    private CloudDestroyer[] cloudList;
    private ScoreManager theScoreManager;
    private Camera theMainCamera;
    public DeathMenu theDeathScreen;
    public string gameLevel;
    public string spaceLevel;
    public string sewerLevel;
    public string cityLevel;
    public string houseLevel;
    public string candylandLevel;
    public string easyLevel;
    public string recksLevel;
    [SerializeField] private Transform footR;
    [SerializeField] private Transform footL;
    [SerializeField] private Transform[] coinsParachutes;
    [SerializeField] public Transform rocketText;
    [SerializeField] public Transform ninjaStarText;
    [SerializeField] public Transform batteryText;
    [SerializeField] public Transform pillowText;
    public GameObject finishMessage;

    // Start is called before the first frame update
    void Start()
    {
        platformStartPoint = platformGenerator.position;
        playerStartPoint = thePlayer.transform.position;
        playerStartPoint = amongPlayer.transform.position;
        cloudStartPoint = cloudGenerator.position;
        theMainCamera = FindObjectOfType<Camera>();
        theScoreManager = FindObjectOfType<ScoreManager>();
    }

    public void RestartGame()
    {
        theScoreManager.scoreIncreasing = false;
        thePlayer.gameObject.SetActive(false);
        amongPlayer.gameObject.SetActive(false);
        bearPlayer.gameObject.SetActive(false);
        gacPlayer.gameObject.SetActive(false);
        dadPlayer.gameObject.SetActive(false);
        plaguePlayer.gameObject.SetActive(false);
        theDeathScreen.gameObject.SetActive(true);
    }

    public void Reset()
    {
        if (Settings.raceLevel)
        {
            racePlayer.currentTime = 0;
        }
        theDeathScreen.gameObject.SetActive(false);
        finishMessage.SetActive(false);
        platformList = FindObjectsOfType<PlatformDestroyer>();
        for (int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }
        cloudList = FindObjectsOfType<CloudDestroyer>();
        for (int i = 0; i < cloudList.Length; i++)
        {
            cloudList[i].gameObject.SetActive(false);
        }
        for (int i = 0;i < coinsParachutes.Length; i++)
        {
            coinsParachutes[i].gameObject.SetActive(true);
        }
        if(Settings.slots == true)
        {
            if (Settings.gameLevel == true)
            {
                SceneManager.LoadScene(gameLevel);
            }
            else if (Settings.space == true)
            {
                SceneManager.LoadScene(spaceLevel);
            }
            else if (Settings.sewer == true)
            {
                SceneManager.LoadScene(sewerLevel);
            }
            else if (Settings.city == true)
            {
                SceneManager.LoadScene(cityLevel);
            }
            else if (Settings.house == true)
            {
                SceneManager.LoadScene(houseLevel);
            }
            else if (Settings.candyland == true)
            {
                SceneManager.LoadScene(candylandLevel);
            }
            else if (Settings.easy == true)
            {
                SceneManager.LoadScene(easyLevel);
            }
            else if (Settings.recks == true)
            {
                SceneManager.LoadScene(recksLevel);
            }
            if (Settings.holdTwoD == true)
            {
                Settings.holdTwoD = false;
                Settings.threeD = false;
            }
        }
        theMainCamera.transform.position = playerStartPoint;
        thePlayer.transform.position = playerStartPoint;
        amongPlayer.transform.position = playerStartPoint;
        bearPlayer.transform.position = playerStartPoint;
        gacPlayer.transform.position = playerStartPoint;
        dadPlayer.transform.position = playerStartPoint;
        plaguePlayer.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        cloudGenerator.position = cloudStartPoint;
        if (Settings.none == true || Settings.roo == true || Settings.turtle == true || Settings.samuria == true)
        {
            thePlayer.gameObject.SetActive(true);
        }
        if (Settings.among == true)
        {
            amongPlayer.gameObject.SetActive(true);
        }
        if (Settings.bear == true)
        {
            bearPlayer.gameObject.SetActive(true);
        }
        if (Settings.gac == true)
        {
            gacPlayer.gameObject.SetActive(true);
        }
        if (Settings.dad == true)
        {
            dadPlayer.gameObject.SetActive(true);
        }
        if (Settings.recksFrog == true)
        {
            plaguePlayer.gameObject.SetActive(true);
        }
        thePlayer.parachute.gameObject.SetActive(false);
        amongPlayer.parachute.gameObject.SetActive(false);
        bearPlayer.parachute.gameObject.SetActive(false);
        gacPlayer.parachute.gameObject.SetActive(false);
        dadPlayer.parachute.gameObject.SetActive(false);
        plaguePlayer.parachute.gameObject.SetActive(false);
        thePlayer.jumpHeight = 2f;
        amongPlayer.jumpHeight = 2f;
        bearPlayer.jumpHeight = 2f;
        gacPlayer.jumpHeight = 2f;
        dadPlayer.jumpHeight = 2f;
        plaguePlayer.jumpHeight = 2f;
        if (Settings.none == true || Settings.roo == true || Settings.turtle == true || Settings.gac == true || Settings.samuria == true || Settings.among == true || Settings.bear == true || Settings.dad == true || Settings.recksFrog == true)
        {
            thePlayer.footR.gameObject.SetActive(false);
            amongPlayer.footR.gameObject.SetActive(false);
            bearPlayer.footR.gameObject.SetActive(false);
            gacPlayer.footR.gameObject.SetActive(false);
            dadPlayer.footR.gameObject.SetActive(false);
            plaguePlayer.footR.gameObject.SetActive(false);
            thePlayer.footL.gameObject.SetActive(false);
            amongPlayer.footL.gameObject.SetActive(false);
            bearPlayer.footL.gameObject.SetActive(false);
            gacPlayer.footL.gameObject.SetActive(false);
            dadPlayer.footL.gameObject.SetActive(false);
            plaguePlayer.footL.gameObject.SetActive(false);
            thePlayer.frogCostume.gameObject.SetActive(false);
            plaguePlayer.frogCostume.gameObject.SetActive(false);
            if (Settings.samuria == true)
            {
                thePlayer.samuriaLegL.gameObject.SetActive(true);
                thePlayer.samuriaLegR.gameObject.SetActive(true);
            }
            if (Settings.turtle == true)
            {
                thePlayer.footL.gameObject.SetActive(true);
                thePlayer.footR.gameObject.SetActive(true);
            }
        }
        if (Settings.recks == true)
        {
            thePlayer.bee.gameObject.SetActive(false);
            amongPlayer.bee.gameObject.SetActive(false);
            bearPlayer.bee.gameObject.SetActive(false);
            gacPlayer.bee.gameObject.SetActive(false);
            dadPlayer.bee.gameObject.SetActive(false);
            plaguePlayer.bee.gameObject.SetActive(false);
        }
        rocketText.gameObject.SetActive(false);
        ninjaStarText.gameObject.SetActive(false);
        batteryText.gameObject.SetActive(false);
        pillowText.gameObject.SetActive(false);
        theScoreManager.scoreCount = 0;
        theScoreManager.scoreIncreasing = true;
        Settings.points = 0;
        Settings.rocketCount = 0;
        Settings.tokenNum = 0;
        Settings.crownCoin = 0;
        Settings.ninjaStarCount = 0;
        Settings.batteryCount = 0;
        Settings.pillowCount = 0;
        Settings.bubblegumCount = 0;
        Settings.coins = 0;
        Settings.jetpack = false;
        Settings.jetpackStart = false;
        Settings.sewerPipe = false;
        Settings.slots = false;
        Settings.frg = false;
        Settings.turtleShell = false;
        Settings.helmet = false;
        Settings.spaceship = false;
        Settings.spaceshipStart = false;
        Settings.bed = false;
        Settings.openHouse = false;
        Settings.hotAirBalloon = false;
        Settings.hotAirBalloonStart = false;
        Settings.portal = false;
        Settings.slotBG = false;
        Settings.levelChange = false;
        if (Settings.sewer == false)
        {
            Settings.levelSewer = false;
        }
        if (Settings.city == false)
        {
            Settings.levelCity = false;
        }
        if (Settings.house == false)
        {
            Settings.levelHouse = false;
        }
        if (Settings.candyland == false)
        {
            Settings.levelCandyland = false;
        }
        if (Settings.space == false)
        {
            Settings.levelSpace = false;
        }
        if (Settings.gameLevel == false)
        {
            Settings.levelGame = false;
        }
        thePlayer.velocity.y = 0;
        amongPlayer.velocity.y = 0;
        bearPlayer.velocity.y = 0;
        gacPlayer.velocity.y = 0;
        dadPlayer.velocity.y = 0;
        plaguePlayer.velocity.y = 0;
        CameraFollow.jetpack = false;
        CameraFollow.up = 0;
        CameraFollow.portal = false;
        CameraFollow.frogFeet = false;
    }
}

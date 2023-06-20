using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class MainMenu : MonoBehaviour
{
    public string firstLevel;
    public string easyLevel;
    public string recksLevel;
    public string leaderboard;
    public string apeGangLeaderboard;
    public string brawlerBearsLeaderboard;
    public string cryptoDadsLeaderboard;
    public string gamingApeClubLeaderboard;
    public string hikeshiLeaderboard;
    public string spaceRidersLeaderboard;
    public string tacoTribeLeaderboard;
    public string thePlagueLeaderboard;
    public string teamLeaderboard;
    public string raceLeaderboard;
    public string raceTeamLeaderboard;
    public string team1Leaderboard;
    public string team2Leaderboard;
    public string team3Leaderboard;
    public string team4Leaderboard;
    public string team5Leaderboard;
    public string credits;
    public string loginScreen;
    public string mainMenu;
    public string houseMenu;
    public string raceLevel;
    public TextMeshProUGUI progressText;
    public Slider slider;
    public GameObject loadingScreen;
    private bool loading;
    public AudioSource crystalCaveBGMusic;
    public AchievementGet achievementGet;
    [SerializeField] public Transform options;
    [SerializeField] public Transform achievements;
    [SerializeField] public Transform achievementsButton;
    [SerializeField] public Transform achievementsDeactivatedButton;
    [SerializeField] public Transform howToPlay;
    [SerializeField] public Transform chooseCostume;
    [SerializeField] public Transform menu;
    [SerializeField] public Transform chooseLeaderboard;
    [SerializeField] public Transform among;
    [SerializeField] public Transform share;
    [SerializeField] public Transform gameSelector;


    public void Start()
    {
        Cursor.visible = true;

        chooseCostume.gameObject.SetActive(false);
        menu.gameObject.SetActive(true);
        if (Settings.musicBool == false)
        {
            crystalCaveBGMusic.Stop();
        }
        else if (Settings.musicBool == true)
        {
            crystalCaveBGMusic.Play();
        }

        if (Settings.amongSelect == true)
        {
            among.gameObject.SetActive(true);
        }
        else if (Settings.amongSelect == false)
        {
            among.gameObject.SetActive(false);
        }

        if (Settings.achievementsEnabled == false)
        {
            achievementsButton.gameObject.SetActive(false);
            achievementsDeactivatedButton.gameObject.SetActive(true);
        }
        else
        {
            achievementsButton.gameObject.SetActive(true);
            achievementsDeactivatedButton.gameObject.SetActive(false);
        }
    }

    public void StartGame()
    {
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

    public void Race()
    {
        LoadLevel(raceLevel);

        Settings.joyImage = true;
        Settings.raceLevel = true;
        Settings.target = 1;
        Settings.samuria = false;
        Settings.taco = false;
        Settings.bear = false;
        Settings.gac = false;
        Settings.dad = false;
        Settings.frog = false;
        Settings.recksFrog = false;
        Settings.turtle = false;
        Settings.among = false;
        Settings.none = true;
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

    public void GameSelector()
    {
        gameSelector.gameObject.SetActive(true);
    }
    
    public void Credits()
    {
        StartCoroutine("CreditsMenu");
    }

    public void Options()
    {
        options.gameObject.SetActive(true);
        menu.gameObject.SetActive(false);
    }
    public void Achievements()
    {
        achievementGet.GetLevelMaster();
        achievements.gameObject.SetActive(true);
        menu.gameObject.SetActive(false);
        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            share.gameObject.SetActive(true);
        }
        else
        {
            share.gameObject.SetActive(false);
        }
    }

    public void HowToPlay()
    {
        howToPlay.gameObject.SetActive(true);
        menu.gameObject.SetActive(false);
    }
    
    public void HouseMenu()
    {
        StartCoroutine("GoToHouseMenu");
    }
    
    public void ChooseCostume()
    {
        chooseCostume.gameObject.SetActive(true);
        gameSelector.gameObject.SetActive(false);
        menu.gameObject.SetActive(false);
    }

    public void QuitGame()
    {
        StartCoroutine("CloseGame");
    }

    public void Leaderboard()
    {
        StartCoroutine("Leaderboards");
    }
    public void ApeGangLeaderboard()
    {
        StartCoroutine("ApeGangLeaderboards");
    }
    public void BrawlerBearsLeaderboard()
    {
        StartCoroutine("BrawlerBearsLeaderboards");
    }
    public void CryptoDadsLeaderboard()
    {
        StartCoroutine("CryptoDadsLeaderboards");
    }
    public void GamingApeClubLeaderboard()
    {
        StartCoroutine("GamingApeClubLeaderboards");
    }
    public void HikeshiLeaderboard()
    {
        StartCoroutine("HikeshiLeaderboards");
    }
    public void SpaceRidersLeaderboard()
    {
        StartCoroutine("SpaceRidersLeaderboards");
    }
    public void TacoTribeLeaderboard()
    {
        StartCoroutine("TacoTribeLeaderboards");
    }
    public void ThePlagueLeaderboard()
    {
        StartCoroutine("ThePlagueLeaderboards");
    }
    public void TeamLeaderboard()
    {
        StartCoroutine("TeamLeaderboards");
    }
    public void RaceLeaderboard()
    {
        StartCoroutine("RaceLeaderboards");
    }
    public void RaceTeamLeaderboard()
    {
        StartCoroutine("RaceTeamLeaderboards");
    }
    public void Team1Leaderboard()
    {
        StartCoroutine("Team1Leaderboards");
    }
    public void Team2Leaderboard()
    {
        StartCoroutine("Team2Leaderboards");
    }
    public void Team3Leaderboard()
    {
        StartCoroutine("Team3Leaderboards");
    }
    public void Team4Leaderboard()
    {
        StartCoroutine("Team4Leaderboards");
    }
    public void Team5Leaderboard()
    {
        StartCoroutine("Team5Leaderboards");
    }

    public void LoginScreens()
    {
        StartCoroutine("LoginScreen");
    }
    public void BackToMain()
    {
        options.gameObject.SetActive(false);
        achievements.gameObject.SetActive(false);
        howToPlay.gameObject.SetActive(false);
        chooseCostume.gameObject.SetActive(false);
        chooseLeaderboard.gameObject.SetActive(false);
        gameSelector.gameObject.SetActive(false);
        menu.gameObject.SetActive(true);
    }

    public void ComputerMain()
    {
        howToPlay.gameObject.SetActive(false);
    }

    public void ChooseLeaderboard()
    {
        menu.gameObject.SetActive(false);
        chooseLeaderboard.gameObject.SetActive(true);
    }

    public void ApeGangSelect()
    {
        Settings.apeGang = true;
        SceneManager.LoadScene(mainMenu);
    }
    public void BrawelerBearsSelect()
    {
        Settings.brawlerBears = true;
        SceneManager.LoadScene(mainMenu);
    }
    public void CryptoDadsSelect()
    {
        Settings.cryptoDads = true;
        SceneManager.LoadScene(mainMenu);
    }
    public void GamingApeClubSelect()
    {
        Settings.gamingApeClub = true;
        SceneManager.LoadScene(mainMenu);
    }
    public void HikeshiSelect()
    {
        Settings.hikeshi = true;
        SceneManager.LoadScene(mainMenu);
    }
    public void SpaceRidersSelect()
    {
        Settings.spaceRiders = true;
        SceneManager.LoadScene(mainMenu);
    }
    public void TacoTribeSelect()
    {
        Settings.tacoTribe = true;
        SceneManager.LoadScene(mainMenu);
    }
    public void ThePlagueSelect()
    {
        Settings.thePlague = true;
        SceneManager.LoadScene(mainMenu);
    }

    public void ChompiesSelect()
    {
        Settings.hikeshiLeaderboard = false;
        SceneManager.LoadScene(mainMenu);
    }

    public IEnumerator CreditsMenu()
    {
        yield return new WaitForSeconds(0.75f);
        Settings.creditsMenu = true;
        SceneManager.LoadScene(credits);
    }
    public IEnumerator GoToHouseMenu()
    {
        yield return new WaitForSeconds(0.75f);
        SceneManager.LoadScene(houseMenu);
    }

    public IEnumerator CloseGame()
    {
        yield return new WaitForSeconds(0.75f);
        Application.Quit();
    }

    public IEnumerator Leaderboards()
    {
        Settings.team1Leaderboard = false;
        Settings.team2Leaderboard = false;
        Settings.team3Leaderboard = false;
        Settings.team4Leaderboard = false;
        Settings.team5Leaderboard = false;
        Settings.apeGangLeaderboard = false;
        Settings.brawlerBearsLeaderboard = false;
        Settings.cryptoDadsLeaderboard = false;
        Settings.gamingApeClubLeaderboard = false;
        Settings.hikeshiLeaderboard = false;
        Settings.spaceRidersLeaderboard = false;
        Settings.tacoTribeLeaderboard = false;
        Settings.thePlagueLeaderboard = false;
        Settings.teamLeaderboard = false;
        Settings.raceLeaderboard = false;
        Settings.raceTeamLeaderboard = false;
        yield return new WaitForSeconds(0.75f);
        SceneManager.LoadScene(leaderboard);
    }

    public IEnumerator ApeGangLeaderboards()
    {
        Settings.team1Leaderboard = false;
        Settings.team2Leaderboard = false;
        Settings.team3Leaderboard = false;
        Settings.team4Leaderboard = false;
        Settings.team5Leaderboard = false;
        Settings.apeGangLeaderboard = true;
        Settings.brawlerBearsLeaderboard = false;
        Settings.cryptoDadsLeaderboard = false;
        Settings.gamingApeClubLeaderboard = false;
        Settings.hikeshiLeaderboard = false;
        Settings.spaceRidersLeaderboard = false;
        Settings.tacoTribeLeaderboard = false;
        Settings.thePlagueLeaderboard = false;
        Settings.teamLeaderboard = false;
        Settings.raceLeaderboard = false;
        Settings.raceTeamLeaderboard = false;
        yield return new WaitForSeconds(0.75f);
        SceneManager.LoadScene(apeGangLeaderboard);
    }
    public IEnumerator BrawlerBearsLeaderboards()
    {
        Settings.team1Leaderboard = false;
        Settings.team2Leaderboard = false;
        Settings.team3Leaderboard = false;
        Settings.team4Leaderboard = false;
        Settings.team5Leaderboard = false;
        Settings.apeGangLeaderboard = false;
        Settings.brawlerBearsLeaderboard = true;
        Settings.cryptoDadsLeaderboard = false;
        Settings.gamingApeClubLeaderboard = false;
        Settings.hikeshiLeaderboard = false;
        Settings.spaceRidersLeaderboard = false;
        Settings.tacoTribeLeaderboard = false;
        Settings.thePlagueLeaderboard = false;
        Settings.teamLeaderboard = false;
        Settings.raceLeaderboard = false;
        Settings.raceTeamLeaderboard = false;
        yield return new WaitForSeconds(0.75f);
        SceneManager.LoadScene(brawlerBearsLeaderboard);
    }
    public IEnumerator CryptoDadsLeaderboards()
    {
        Settings.team1Leaderboard = false;
        Settings.team2Leaderboard = false;
        Settings.team3Leaderboard = false;
        Settings.team4Leaderboard = false;
        Settings.team5Leaderboard = false;
        Settings.apeGangLeaderboard = false;
        Settings.brawlerBearsLeaderboard = false;
        Settings.cryptoDadsLeaderboard = true;
        Settings.gamingApeClubLeaderboard = false;
        Settings.hikeshiLeaderboard = false;
        Settings.spaceRidersLeaderboard = false;
        Settings.tacoTribeLeaderboard = false;
        Settings.thePlagueLeaderboard = false;
        Settings.teamLeaderboard = false;
        Settings.raceLeaderboard = false;
        Settings.raceTeamLeaderboard = false;
        yield return new WaitForSeconds(0.75f);
        SceneManager.LoadScene(cryptoDadsLeaderboard);
    }
    public IEnumerator GamingApeClubLeaderboards()
    {
        Settings.team1Leaderboard = false;
        Settings.team2Leaderboard = false;
        Settings.team3Leaderboard = false;
        Settings.team4Leaderboard = false;
        Settings.team5Leaderboard = false;
        Settings.apeGangLeaderboard = false;
        Settings.brawlerBearsLeaderboard = false;
        Settings.cryptoDadsLeaderboard = false;
        Settings.gamingApeClubLeaderboard = true;
        Settings.hikeshiLeaderboard = false;
        Settings.spaceRidersLeaderboard = false;
        Settings.tacoTribeLeaderboard = false;
        Settings.thePlagueLeaderboard = false;
        Settings.teamLeaderboard = false;
        Settings.raceLeaderboard = false;
        Settings.raceTeamLeaderboard = false;
        yield return new WaitForSeconds(0.75f);
        SceneManager.LoadScene(gamingApeClubLeaderboard);
    }
    public IEnumerator HikeshiLeaderboards()
    {
        Settings.team1Leaderboard = false;
        Settings.team2Leaderboard = false;
        Settings.team3Leaderboard = false;
        Settings.team4Leaderboard = false;
        Settings.team5Leaderboard = false;
        Settings.apeGangLeaderboard = false;
        Settings.brawlerBearsLeaderboard = false;
        Settings.cryptoDadsLeaderboard = false;
        Settings.gamingApeClubLeaderboard = false;
        Settings.hikeshiLeaderboard = true;
        Settings.spaceRidersLeaderboard = false;
        Settings.tacoTribeLeaderboard = false;
        Settings.thePlagueLeaderboard = false;
        Settings.teamLeaderboard = false;
        Settings.raceLeaderboard = false;
        Settings.raceTeamLeaderboard = false;
        yield return new WaitForSeconds(0.75f);
        SceneManager.LoadScene(hikeshiLeaderboard);
    }
    public IEnumerator SpaceRidersLeaderboards()
    {
        Settings.team1Leaderboard = false;
        Settings.team2Leaderboard = false;
        Settings.team3Leaderboard = false;
        Settings.team4Leaderboard = false;
        Settings.team5Leaderboard = false;
        Settings.apeGangLeaderboard = false;
        Settings.brawlerBearsLeaderboard = false;
        Settings.cryptoDadsLeaderboard = false;
        Settings.gamingApeClubLeaderboard = false;
        Settings.hikeshiLeaderboard = false;
        Settings.spaceRidersLeaderboard = true;
        Settings.tacoTribeLeaderboard = false;
        Settings.thePlagueLeaderboard = false;
        Settings.teamLeaderboard = false;
        Settings.raceLeaderboard = false;
        Settings.raceTeamLeaderboard = false;
        yield return new WaitForSeconds(0.75f);
        SceneManager.LoadScene(spaceRidersLeaderboard);
    }
    public IEnumerator TacoTribeLeaderboards()
    {
        Settings.team1Leaderboard = false;
        Settings.team2Leaderboard = false;
        Settings.team3Leaderboard = false;
        Settings.team4Leaderboard = false;
        Settings.team5Leaderboard = false;
        Settings.apeGangLeaderboard = false;
        Settings.brawlerBearsLeaderboard = false;
        Settings.cryptoDadsLeaderboard = false;
        Settings.gamingApeClubLeaderboard = false;
        Settings.hikeshiLeaderboard = false;
        Settings.spaceRidersLeaderboard = false;
        Settings.tacoTribeLeaderboard = true;
        Settings.thePlagueLeaderboard = false;
        Settings.teamLeaderboard = false;
        Settings.raceLeaderboard = false;
        Settings.raceTeamLeaderboard = false;
        yield return new WaitForSeconds(0.75f);
        SceneManager.LoadScene(tacoTribeLeaderboard);
    }
    public IEnumerator ThePlagueLeaderboards()
    {
        Settings.team1Leaderboard = false;
        Settings.team2Leaderboard = false;
        Settings.team3Leaderboard = false;
        Settings.team4Leaderboard = false;
        Settings.team5Leaderboard = false;
        Settings.apeGangLeaderboard = false;
        Settings.brawlerBearsLeaderboard = false;
        Settings.cryptoDadsLeaderboard = false;
        Settings.gamingApeClubLeaderboard = false;
        Settings.hikeshiLeaderboard = false;
        Settings.spaceRidersLeaderboard = false;
        Settings.tacoTribeLeaderboard = false;
        Settings.thePlagueLeaderboard = true;
        Settings.teamLeaderboard = false;
        Settings.raceLeaderboard = false;
        Settings.raceTeamLeaderboard = false;
        yield return new WaitForSeconds(0.75f);
        SceneManager.LoadScene(thePlagueLeaderboard);
    }
    public IEnumerator RaceLeaderboards()
    {
        Settings.team1Leaderboard = false;
        Settings.team2Leaderboard = false;
        Settings.team3Leaderboard = false;
        Settings.team4Leaderboard = false;
        Settings.team5Leaderboard = false;
        Settings.apeGangLeaderboard = false;
        Settings.brawlerBearsLeaderboard = false;
        Settings.cryptoDadsLeaderboard = false;
        Settings.gamingApeClubLeaderboard = false;
        Settings.hikeshiLeaderboard = false;
        Settings.spaceRidersLeaderboard = false;
        Settings.tacoTribeLeaderboard = false;
        Settings.thePlagueLeaderboard = false;
        Settings.teamLeaderboard = false;
        Settings.raceLeaderboard = true;
        Settings.raceTeamLeaderboard = false;
        yield return new WaitForSeconds(0.75f);
        SceneManager.LoadScene(raceLeaderboard);
    }
    public IEnumerator RaceTeamLeaderboards()
    {
        Settings.team1Leaderboard = false;
        Settings.team2Leaderboard = false;
        Settings.team3Leaderboard = false;
        Settings.team4Leaderboard = false;
        Settings.team5Leaderboard = false;
        Settings.apeGangLeaderboard = false;
        Settings.brawlerBearsLeaderboard = false;
        Settings.cryptoDadsLeaderboard = false;
        Settings.gamingApeClubLeaderboard = false;
        Settings.hikeshiLeaderboard = false;
        Settings.spaceRidersLeaderboard = false;
        Settings.tacoTribeLeaderboard = false;
        Settings.thePlagueLeaderboard = false;
        Settings.teamLeaderboard = false;
        Settings.raceLeaderboard = false;
        Settings.raceTeamLeaderboard = true;
        yield return new WaitForSeconds(0.75f);
        SceneManager.LoadScene(raceTeamLeaderboard);
    }
    public IEnumerator Team1Leaderboards()
    {
        Settings.team1Leaderboard = true;
        Settings.team2Leaderboard = false;
        Settings.team3Leaderboard = false;
        Settings.team4Leaderboard = false;
        Settings.team5Leaderboard = false;
        Settings.apeGangLeaderboard = false;
        Settings.brawlerBearsLeaderboard = false;
        Settings.cryptoDadsLeaderboard = false;
        Settings.gamingApeClubLeaderboard = false;
        Settings.hikeshiLeaderboard = false;
        Settings.spaceRidersLeaderboard = false;
        Settings.tacoTribeLeaderboard = false;
        Settings.thePlagueLeaderboard = false;
        Settings.teamLeaderboard = false;
        Settings.raceLeaderboard = false;
        Settings.raceTeamLeaderboard = false;
        yield return new WaitForSeconds(0.75f);
        SceneManager.LoadScene(team1Leaderboard);
    }
    public IEnumerator Team2Leaderboards()
    {
        Settings.team1Leaderboard = false;
        Settings.team2Leaderboard = true;
        Settings.team3Leaderboard = false;
        Settings.team4Leaderboard = false;
        Settings.team5Leaderboard = false;
        Settings.apeGangLeaderboard = false;
        Settings.brawlerBearsLeaderboard = false;
        Settings.cryptoDadsLeaderboard = false;
        Settings.gamingApeClubLeaderboard = false;
        Settings.hikeshiLeaderboard = false;
        Settings.spaceRidersLeaderboard = false;
        Settings.tacoTribeLeaderboard = false;
        Settings.thePlagueLeaderboard = false;
        Settings.teamLeaderboard = false;
        Settings.raceLeaderboard = false;
        Settings.raceTeamLeaderboard = false;
        yield return new WaitForSeconds(0.75f);
        SceneManager.LoadScene(team2Leaderboard);
    }
    public IEnumerator Team3Leaderboards()
    {
        Settings.team1Leaderboard = false;
        Settings.team2Leaderboard = false;
        Settings.team3Leaderboard = true;
        Settings.team4Leaderboard = false;
        Settings.team5Leaderboard = false;
        Settings.apeGangLeaderboard = false;
        Settings.brawlerBearsLeaderboard = false;
        Settings.cryptoDadsLeaderboard = false;
        Settings.gamingApeClubLeaderboard = false;
        Settings.hikeshiLeaderboard = false;
        Settings.spaceRidersLeaderboard = false;
        Settings.tacoTribeLeaderboard = false;
        Settings.thePlagueLeaderboard = false;
        Settings.teamLeaderboard = false;
        Settings.raceLeaderboard = false;
        Settings.raceTeamLeaderboard = false;
        yield return new WaitForSeconds(0.75f);
        SceneManager.LoadScene(team3Leaderboard);
    }
    public IEnumerator Team4Leaderboards()
    {
        Settings.team1Leaderboard = false;
        Settings.team2Leaderboard = false;
        Settings.team3Leaderboard = false;
        Settings.team4Leaderboard = true;
        Settings.team5Leaderboard = false;
        Settings.apeGangLeaderboard = false;
        Settings.brawlerBearsLeaderboard = false;
        Settings.cryptoDadsLeaderboard = false;
        Settings.gamingApeClubLeaderboard = false;
        Settings.hikeshiLeaderboard = false;
        Settings.spaceRidersLeaderboard = false;
        Settings.tacoTribeLeaderboard = false;
        Settings.thePlagueLeaderboard = false;
        Settings.teamLeaderboard = false;
        Settings.raceLeaderboard = false;
        Settings.raceTeamLeaderboard = false;
        yield return new WaitForSeconds(0.75f);
        SceneManager.LoadScene(team4Leaderboard);
    }
    public IEnumerator Team5Leaderboards()
    {
        Settings.team1Leaderboard = false;
        Settings.team2Leaderboard = false;
        Settings.team3Leaderboard = false;
        Settings.team4Leaderboard = false;
        Settings.team5Leaderboard = true;
        Settings.apeGangLeaderboard = false;
        Settings.brawlerBearsLeaderboard = false;
        Settings.cryptoDadsLeaderboard = false;
        Settings.gamingApeClubLeaderboard = false;
        Settings.hikeshiLeaderboard = false;
        Settings.spaceRidersLeaderboard = false;
        Settings.tacoTribeLeaderboard = false;
        Settings.thePlagueLeaderboard = false;
        Settings.teamLeaderboard = false;
        Settings.raceLeaderboard = false;
        Settings.raceTeamLeaderboard = false;
        yield return new WaitForSeconds(0.75f);
        SceneManager.LoadScene(team5Leaderboard);
    }
    public IEnumerator TeamLeaderboards()
    {
        Settings.team1Leaderboard = false;
        Settings.team2Leaderboard = false;
        Settings.team3Leaderboard = false;
        Settings.team4Leaderboard = false;
        Settings.team5Leaderboard = false;
        Settings.apeGangLeaderboard = false;
        Settings.brawlerBearsLeaderboard = false;
        Settings.cryptoDadsLeaderboard = false;
        Settings.gamingApeClubLeaderboard = false;
        Settings.hikeshiLeaderboard = false;
        Settings.spaceRidersLeaderboard = false;
        Settings.tacoTribeLeaderboard = false;
        Settings.thePlagueLeaderboard = false;
        Settings.teamLeaderboard = true;
        Settings.raceLeaderboard = false;
        Settings.raceTeamLeaderboard = false;
        yield return new WaitForSeconds(0.75f);
        SceneManager.LoadScene(teamLeaderboard);
    }

    public IEnumerator LoginScreen()
    {
        yield return new WaitForSeconds(0.75f);
        PlayfabManager.DeletePlayerPrefs();
        Settings.achievementsEnabled = false;
        Settings.apeGang = false;
        Settings.brawlerBears = false;
        Settings.cryptoDads = false;
        Settings.gamingApeClub = false;
        Settings.hikeshi = false;
        Settings.spaceRiders = false;
        Settings.tacoTribe = false;
        Settings.thePlague = false;
        Settings.teamLeaderboard = false;
        Settings.raceLeaderboard = false;
        SceneManager.LoadScene(loginScreen);
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

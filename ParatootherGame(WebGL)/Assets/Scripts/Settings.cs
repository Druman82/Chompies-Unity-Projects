using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Settings : MonoBehaviour
{
    public PlayfabManager playfabManager;
    public AchievementGet theAchievementGet;
    public static bool apeGang = false;
    public static bool brawlerBears = false;
    public static bool cryptoDads = false;
    public static bool gamingApeClub = false;
    public static bool hikeshi = false;
    public static bool spaceRiders = false;
    public static bool tacoTribe = false;
    public static bool thePlague = false;
    public static bool team1 = false;
    public static bool team2 = false;
    public static bool team3 = false;
    public static bool team4 = false;
    public static bool team5 = false;
    public static bool apeGangLeaderboard = false;
    public static bool brawlerBearsLeaderboard = false;
    public static bool cryptoDadsLeaderboard = false;
    public static bool gamingApeClubLeaderboard = false;
    public static bool hikeshiLeaderboard = false;
    public static bool spaceRidersLeaderboard = false;
    public static bool tacoTribeLeaderboard = false;
    public static bool thePlagueLeaderboard = false;
    public static bool teamLeaderboard = false;
    public static bool raceTeamLeaderboard = false;
    public static bool raceLeaderboard = false;
    public static bool team1Leaderboard = false;
    public static bool team2Leaderboard = false;
    public static bool team3Leaderboard = false;
    public static bool team4Leaderboard = false;
    public static bool team5Leaderboard = false;
    public static bool creditsMenu;
    public static bool levelGame;
    public static bool levelChange;
    public static bool levelSewer;
    public static bool levelCity;
    public static bool levelHouse;
    public static bool levelCandyland;
    public static bool levelSpace;
    public static bool alternateSpace;
    public static bool samuriaPickup;
    public static bool turtlePickup;
    public static bool achievementsEnabled;
    public static string levelMasterAchievement;
    public static string rocketDodgerAchievement1;
    public static string rocketDodgerAchievement2;
    public static string rocketDodgerAchievement3;
    public static string winnerWinnerAchievement;
    public static string jackpotAchievement;
    public static string coinCountAchievement1;
    public static string coinCountAchievement2;
    public static string coinCountAchievement3;
    public static string parachuteCountAchievement1;
    public static string parachuteCountAchievement2;
    public static string parachuteCountAchievement3;
    public static string reckscollieAwardAchievement;
    public static string alternateSpaceAchievement;
    public static string samuriaSent;
    public static string turtleSent;
    private static int levelMasterTog;
    private static int rocketDodge1;
    private static int rocketDodge2;
    private static int rocketDodge3;
    public static int winnerWinnerTog;
    public static int jackpotTog;
    public static int coinCountTog1;
    public static int coinCountTog2;
    public static int coinCountTog3;
    public static int coinCount;
    public static int parachuteCountTog1;
    public static int parachuteCountTog2;
    public static int parachuteCountTog3;
    public static int parachuteCount;
    public static int totalPoints;
    public static int totalPointsTog;
    public static int alternateSpaceTog;
    public static bool samuriaTog;
    public static bool turtleTog;
    public static int target = 1;
    public static bool samuria;
    public static bool samuriaActivated;
    public static bool taco;
    public static bool bear;
    public static bool gac;
    public static bool dad;
    public static bool frog;
    public static bool recksFrog;
    public static bool turtle;
    public static bool turtleActivated;
    public static bool among;
    public static bool amongSelect;
    public static bool none = true;
    public static bool threeD;
    public static bool night;
    public static bool holdTwoD;
    public static bool space;
    public static bool sewer;
    public static bool city;
    public static bool house;
    public static bool candyland;
    public static bool gameLevel;
    public static bool raceLevel;
    public static bool easy;
    public static bool recks;
    public static bool slots = false;
    public static bool slotBG;
    public static int points;
    public static int time;
    public static int rocketCount;
    public static int slotScore;
    public static bool jetpack;
    public static bool jetpackStart;
    public static bool sewerPipe;
    public static bool turtleShell;
    public static bool openHouse;
    public static int ninjaStarCount;
    public static int batteryCount;
    public static bool helmet;
    public static int pillowCount;
    public static int bubblegumCount;
    public static bool bed;
    public static bool spaceship;
    public static bool spaceshipStart;
    public static bool hotAirBalloon;
    public static bool hotAirBalloonStart;
    public static bool glasses;
    public static bool frg;
    public static bool hoverboard;
    public static bool portal;
    public static bool finishLine;
    public static bool goldKey;
    public static bool goldKeyHeld = true;
    public static bool chestUnlock = false;
    public static bool glider;
    public static bool joyImage;
    public static int crownCoin;
    public static int coins;
    public Camera theCamera;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI rocketText;
    public TextMeshProUGUI tokenText;
    public TextMeshProUGUI ninjaStarText;
    public TextMeshProUGUI batteryText;
    public TextMeshProUGUI pillowText;
    public static int tokenNum;
    public bool tokens = false;
    public static bool musicBool = true;
    public static int music;
    public static bool soundFXBool = true;
    public static int soundFX;
    public static int difficulty = 2;
    public AudioSource crystalCaveBGMusic;
    public AudioSource achievementGetSound;
    [SerializeField] public Transform token;
    [SerializeField] public Transform planeCandyland2D;
    [SerializeField] public Transform planeCandyland3D;
    [SerializeField] public Transform planeGameLevel2D;
    [SerializeField] public Transform planeGameLevel3D;
    [SerializeField] public Transform planeGameLevelNight2D;
    [SerializeField] public Transform planeGameLevelNight3D;
    [SerializeField] public Transform planeCyber2D;
    [SerializeField] public Transform planeCyber3D;
    [SerializeField] public Transform planeHouse2D;
    [SerializeField] public Transform planeHouse3D;
    [SerializeField] public Transform planeSewer2D;
    [SerializeField] public Transform planeSewer3D;
    [SerializeField] public Transform planeSpace2D;
    [SerializeField] public Transform planeSpace3D;
    [SerializeField] public GameObject achievementGet;
    [SerializeField] public GameObject alternateSpaceBanner;
    [SerializeField] public GameObject winnerWinnerBanner;
    [SerializeField] public GameObject jackpotBanner;
    [SerializeField] public GameObject travelerBanner;
    [SerializeField] public GameObject reckscollieAwardBanner;
    [SerializeField] public GameObject rocketDodgerIBanner;
    [SerializeField] public GameObject rocketDodgerIIBanner;
    [SerializeField] public GameObject rocketDodgerIIIBanner;
    [SerializeField] public GameObject highRollerI;
    [SerializeField] public GameObject highRollerII;
    [SerializeField] public GameObject highRollerIII;
    [SerializeField] public GameObject parachuteJediI;
    [SerializeField] public GameObject parachuteJediII;
    [SerializeField] public GameObject parachuteJediIII;
    [SerializeField] public GameObject costumeUnlockBanner;


    public void musicToggle()
    {
        if (music == 0)
        {
            musicBool = false;
            crystalCaveBGMusic.Stop();
            music = 1;
        }
        else if (music == 1)
        {
            musicBool = true;
            crystalCaveBGMusic.Play();
            music = 0;
        }     
    }

    public void soundFXToggle()
    {
        if (soundFX == 0)
        {
            soundFXBool = false;
            soundFX = 1;
        }
        else if (soundFX == 1)
        {
            soundFXBool = true;
            soundFX = 0;
        }
    }


    void Update()
    {
        //Achievements

        //Level Master
        if (levelSewer == true && levelCity == true && levelHouse == true && levelCandyland == true && levelSpace == true && levelGame == true)
        {
            if (levelMasterTog == 0 && AchievementGet.levelMasterAchievementGet == null)
            {
                levelMasterAchievement = "levelMaster";
                levelMasterTog = 1;
                StartCoroutine("AchievementsGet");
                StartCoroutine("Traveler");
            }
        }

        //Reckscollie Award
        if (totalPoints >= 1000000f)
        {
            if (totalPointsTog == 0 && AchievementGet.reckscollieAwardAchievementGet == null)
            {
                reckscollieAwardAchievement = "reckscollieAward";
                totalPointsTog = 1;
                StartCoroutine("AchievementsGet");
                StartCoroutine("ReckscollieAward");
            }
        }
        //Rocket Dodger Send
        if (gameLevel == true && levelChange == false)
        {
            if ((points >= 5000 && points < 15000f) && slotBG == false)
            {
                if (rocketDodge1 == 0 && AchievementGet.rocketDodgerAchievement1Get == null)
                {
                    rocketDodgerAchievement1 = "rocketDodger1";
                    rocketDodge1 = 1;
                    StartCoroutine("AchievementsGet");
                    StartCoroutine("RocketDodgerI");
                }
            }
            else if ((points >= 15000f && points < 30000f) && slotBG == false)
            {
                if (rocketDodge2 == 0 && AchievementGet.rocketDodgerAchievement2Get == null)
                {
                    rocketDodgerAchievement2 = "rocketDodger2";
                    rocketDodge2 = 1;
                    StartCoroutine("AchievementsGet");
                    StartCoroutine("RocketDodgerII");
                }
            }
            else if (points >= 30000f && slotBG == false)
            {
                if (rocketDodge3 == 0 && AchievementGet.rocketDodgerAchievement3Get == null)
                {
                    rocketDodgerAchievement3 = "rocketDodger3";
                    rocketDodge3 = 1;
                    StartCoroutine("AchievementsGet");
                    StartCoroutine("RocketDodgerIII");
                }
            }
        }

        //Coin Count
        if (coinCount >= 100f && coinCount < 1000f)
        {
            if (coinCountTog1 == 0)
            {
                coinCountAchievement1 = "coinCount1";
                coinCountTog1 = 1;
                StartCoroutine("AchievementsGet");
                StartCoroutine("HighRollerI");
            }
        }
        if (coinCount >= 1000f && coinCount < 10000f)
        {
            if (coinCountTog2 == 0)
            {
                coinCountAchievement2 = "coinCount2";
                coinCountTog2 = 1;
                StartCoroutine("AchievementsGet");
                StartCoroutine("HighRollerII");
            }
        }
        if (coinCount >= 10000f)
        {
            if (coinCountTog3 == 0)
            {
                coinCountAchievement3 = "coinCount3";
                coinCountTog3 = 1;
                StartCoroutine("AchievementsGet");
                StartCoroutine("HighRollerIII");
            }
        }

        //Parachute Count
        if (parachuteCount >= 50f && parachuteCount < 100f)
        {
            if (parachuteCountTog1 == 0)
            {
                parachuteCountAchievement1 = "parachuteCount1";
                parachuteCountTog1 = 1;
                StartCoroutine("AchievementsGet");
                StartCoroutine("ParachuteJediI");
            }
        }
        if (parachuteCount >= 500f && parachuteCount < 5000f)
        {
            if (parachuteCountTog2 == 0)
            {
                parachuteCountAchievement2 = "parachuteCount2";
                parachuteCountTog2 = 1;
                StartCoroutine("AchievementsGet");
                StartCoroutine("ParachuteJediII");
            }
        }
        if (parachuteCount >= 5000f)
        {
            if (parachuteCountTog3 == 0)
            {
                parachuteCountAchievement3 = "parachuteCount3";
                parachuteCountTog3 = 1;
                StartCoroutine("AchievementsGet");
                StartCoroutine("ParachuteJediIII");
            }
        }

        //Alternate Space
        if (alternateSpace == true)
        {
            if (alternateSpaceTog == 0 && AchievementGet.alternateSpaceAchievementGet == null)
            {
                alternateSpaceAchievement = "alternateSpace";
                alternateSpaceTog = 1;
                StartCoroutine("AchievementsGet");
                StartCoroutine("AlternateSpace");
            }
        }
        /*
        //Among/Bear/GAC/Dad
        if (among == false && bear == false && gac == false && dad == false)
        {
            target = 1;
        }
        else if (among == true && bear == false && gac == false && dad == false)
        {
            target = 2;
        }
        else if (among == false && bear == true && gac == false && dad == false)
        {
            target = 3;
        }
        else if (among == false && bear == false && gac == true && dad == false)
        {
            target = 4;
        }
        else if (among == false && bear == false && gac == false && dad == true)
        {
            target = 5;
        }*/



        //Game Level
        if (gameLevel == true)
        {
            if (night == true)
            {
                if (threeD == true)
                {
                    planeGameLevelNight2D.gameObject.SetActive(false);
                    planeGameLevelNight3D.gameObject.SetActive(true);
                    planeGameLevel3D.gameObject.SetActive(false);
                    planeGameLevel2D.gameObject.SetActive(false);
                }
                else if (threeD == false)
                {
                    planeGameLevelNight2D.gameObject.SetActive(true);
                    planeGameLevelNight3D.gameObject.SetActive(false);
                    planeGameLevel2D.gameObject.SetActive(false);
                    planeGameLevel3D.gameObject.SetActive(false);
                }
            }
            else if (night == false)
            {
                if (threeD == true)
                {
                    planeGameLevel2D.gameObject.SetActive(false);
                    planeGameLevel3D.gameObject.SetActive(true);
                    planeGameLevelNight2D.gameObject.SetActive(false);
                    planeGameLevelNight3D.gameObject.SetActive(false);

                }
                else if (threeD == false)
                {
                    planeGameLevel2D.gameObject.SetActive(true);
                    planeGameLevel3D.gameObject.SetActive(false);
                    planeGameLevelNight3D.gameObject.SetActive(false);
                    planeGameLevelNight2D.gameObject.SetActive(false);

                }
            }
        }
        else if (gameLevel == false)
        {
            planeGameLevel2D.gameObject.SetActive(false);
            planeGameLevel3D.gameObject.SetActive(false);
        }

        //Space
        if (space == true)
        {
            if (threeD == true)
            {
                planeSpace2D.gameObject.SetActive(false);
                planeSpace3D.gameObject.SetActive(true);
            }
            else if (threeD == false)
            {
                planeSpace2D.gameObject.SetActive(true);
                planeSpace3D.gameObject.SetActive(false);
            }
        }
        else if (space == false)
        {
            planeSpace2D.gameObject.SetActive(false);
            planeSpace3D.gameObject.SetActive(false);
        }

        //House
        if (house == true)
        {
            if (threeD == true)
            {
                planeHouse2D.gameObject.SetActive(false);
                planeHouse3D.gameObject.SetActive(true);
            }
            else if (threeD == false)
            {
                planeHouse2D.gameObject.SetActive(true);
                planeHouse3D.gameObject.SetActive(false);
            }
        }
        else if (house == false)
        {
            planeHouse2D.gameObject.SetActive(false);
            planeHouse3D.gameObject.SetActive(false);
        }

        //Sewer
        if (sewer == true)
        {
            if (threeD == true)
            {
                planeSewer2D.gameObject.SetActive(false);
                planeSewer3D.gameObject.SetActive(true);
            }
            else if (threeD == false)
            {
                planeSewer2D.gameObject.SetActive(true);
                planeSewer3D.gameObject.SetActive(false);
            }
        }
        else if (sewer == false)
        {
            planeSewer2D.gameObject.SetActive(false);
            planeSewer3D.gameObject.SetActive(false);
        }

        //City
        if (city == true)
        {
            if (threeD == true)
            {
                planeCyber2D.gameObject.SetActive(false);
                planeCyber3D.gameObject.SetActive(true);
            }
            else if (threeD == false)
            {
                planeCyber2D.gameObject.SetActive(true);
                planeCyber3D.gameObject.SetActive(false);
            }
        }
        else if (city == false)
        {
            planeCyber2D.gameObject.SetActive(false);
            planeCyber3D.gameObject.SetActive(false);
        }

        //Candyland
        if (candyland == true)
        {
            if (threeD == true)
            {
                planeCandyland2D.gameObject.SetActive(false);
                planeCandyland3D.gameObject.SetActive(true);
            }
            else if (threeD == false)
            {
                planeCandyland2D.gameObject.SetActive(true);
                planeCandyland3D.gameObject.SetActive(false);
            }
        }
        else if (city == false)
        {
            planeCandyland2D.gameObject.SetActive(false);
            planeCandyland3D.gameObject.SetActive(false);
        }
        
        //Slots Level
        if (slotBG == true)
        {
            if (threeD == true)
            {
                planeGameLevel3D.gameObject.SetActive(false);
                planeHouse3D.gameObject.SetActive(false);
                planeSewer3D.gameObject.SetActive(false);
                planeCyber3D.gameObject.SetActive(false);
                planeCandyland3D.gameObject.SetActive(false);
                planeSpace2D.gameObject.SetActive(false);
                planeSpace3D.gameObject.SetActive(true);
            }
            else if (threeD == false)
            {
                planeGameLevel2D.gameObject.SetActive(false);
                planeHouse2D.gameObject.SetActive(false);
                planeSewer2D.gameObject.SetActive(false);
                planeCyber2D.gameObject.SetActive(false);
                planeCandyland2D.gameObject.SetActive(false);
                planeSpace2D.gameObject.SetActive(false);
                planeSpace3D.gameObject.SetActive(true);
            }
        }
        else if (slotBG == false)
        {
            if (space == false)
            {
                planeSpace2D.gameObject.SetActive(false);
                planeSpace3D.gameObject.SetActive(false);
            }
        }
   
        if (tokenText != null)
        {
            tokenText.text = " " + tokenNum;
            if(tokenNum <= 0)
            {
                tokenText.text = "0";
            }
        }

        if (rocketText != null)
        {
            rocketText.text = rocketCount + "/5";
        }
        if (scoreText != null)
        {
            scoreText.text = "" + points;
        }
        if (ninjaStarText != null)
        {
            ninjaStarText.text = ninjaStarCount + "/4";
        }
        if (batteryText != null)
        {
            batteryText.text = batteryCount + "/4";
        }
        if (pillowText != null)
        {
            pillowText.text = pillowCount + "/5";
        }

        if (rocketCount >= 5)
        {
            jetpack = true;
        }
        else
        {
            jetpack = false;
        }

        if (ninjaStarCount >= 4)
        {
            turtleShell = true;
        }
        else
        {
            turtleShell = false;
        }

        if (batteryCount >= 4)
        {
            helmet = true;
        }
        else
        {
            helmet = false;
        }

        if (pillowCount >= 5)
        {
            bed = true;
        }
        else
        {
            bed = false;
        }

        if (coins >= 15)
        {
            openHouse = true;
        }

        if (bubblegumCount >= 5)
        {
            hotAirBalloon = true;
        }

        if (threeD == true)
        {
            theCamera.orthographic = false;
        }
        else if (threeD == false)
        {
            theCamera.orthographic = true;
        }
    }

    //Turtle
    public void Turtle()
    {
        if (Settings.soundFXBool == true)
        {
            achievementGetSound.Play();
        }
        turtleSent = "turtle";
        StartCoroutine("CostumeUnlocked");
    }

    
    //Samuria
    public void Samuria()
    {
        if (Settings.soundFXBool == true)
        {
            achievementGetSound.Play();
        }
        samuriaSent = "samuria";
        StartCoroutine("CostumeUnlocked");
    }

    //Achievement Get
    private IEnumerator AchievementsGet()
    {
        if (achievementsEnabled)
        {
            if (Settings.soundFXBool == true)
            {
                achievementGetSound.Play();
            }
            achievementGet.gameObject.SetActive(true);
            yield return new WaitForSeconds(6);
            achievementGet.gameObject.SetActive(false);
        }
    }
    
    private IEnumerator AlternateSpace()
    {
        if (achievementsEnabled)
        {
            playfabManager.SaveAlternateSpace();

            alternateSpaceBanner.gameObject.SetActive(true);
            yield return new WaitForSeconds(6);
            alternateSpaceBanner.gameObject.SetActive(false);
        }
    }

    private IEnumerator Jackpot()
    {
        if (achievementsEnabled)
        {
            playfabManager.SaveJackpot();
            jackpotBanner.gameObject.SetActive(true);
            yield return new WaitForSeconds(6);
            jackpotBanner.gameObject.SetActive(false);
        }
    }

    private IEnumerator Traveler()
    {
        if (achievementsEnabled)
        {
            playfabManager.SaveLevelMaster();
            travelerBanner.gameObject.SetActive(true);
            yield return new WaitForSeconds(6);
            travelerBanner.gameObject.SetActive(false);
        }
    }

    private IEnumerator ReckscollieAward()
    {
        if (achievementsEnabled)
        {
            playfabManager.SaveReckscollieAward();
            reckscollieAwardBanner.gameObject.SetActive(true);
            yield return new WaitForSeconds(6);
            reckscollieAwardBanner.gameObject.SetActive(false);
        }
    }

    private IEnumerator RocketDodgerI()
    {
        if (achievementsEnabled)
        {
            playfabManager.SaveRocketDodger1();
            rocketDodgerIBanner.gameObject.SetActive(true);
            yield return new WaitForSeconds(6);
            rocketDodgerIBanner.gameObject.SetActive(false);
        }
    }

    private IEnumerator RocketDodgerII()
    {
        if (achievementsEnabled)
        {
            playfabManager.SaveRocketDodger2();
            rocketDodgerIIBanner.gameObject.SetActive(true);
            yield return new WaitForSeconds(6);
            rocketDodgerIIBanner.gameObject.SetActive(false);
        }
    }

    private IEnumerator RocketDodgerIII()
    {
        if (achievementsEnabled)
        {
            playfabManager.SaveRocketDodger3();
            rocketDodgerIIIBanner.gameObject.SetActive(true);
            yield return new WaitForSeconds(6);
            rocketDodgerIIIBanner.gameObject.SetActive(false);
        }
    }

    private IEnumerator HighRollerI()
    {
        if (achievementsEnabled)
        {
            highRollerI.gameObject.SetActive(true);
            yield return new WaitForSeconds(6);
            highRollerI.gameObject.SetActive(false);
        }
    }

    private IEnumerator HighRollerII()
    {
        if (achievementsEnabled)
        {
            highRollerII.gameObject.SetActive(true);
            yield return new WaitForSeconds(6);
            highRollerII.gameObject.SetActive(false);
        }
    }

    private IEnumerator HighRollerIII()
    {
        if (achievementsEnabled)
        {
            highRollerIII.gameObject.SetActive(true);
            yield return new WaitForSeconds(6);
            highRollerIII.gameObject.SetActive(false);
        }
    }

    private IEnumerator ParachuteJediI()
    {
        if (achievementsEnabled)
        {
            parachuteJediI.gameObject.SetActive(true);
            yield return new WaitForSeconds(6);
            parachuteJediI.gameObject.SetActive(false);
        }
    }

    private IEnumerator ParachuteJediII()
    {
        if (achievementsEnabled)
        {
            parachuteJediII.gameObject.SetActive(true);
            yield return new WaitForSeconds(6);
            parachuteJediII.gameObject.SetActive(false);
        }
    }

    private IEnumerator ParachuteJediIII()
    {
        if (achievementsEnabled)
        {
            parachuteJediII.gameObject.SetActive(true);
            yield return new WaitForSeconds(6);
            parachuteJediII.gameObject.SetActive(false);
        }
    }

    private IEnumerator CostumeUnlocked()
    {
        if (achievementsEnabled)
        {
            costumeUnlockBanner.gameObject.SetActive(true);
            yield return new WaitForSeconds(6);
            costumeUnlockBanner.gameObject.SetActive(false);
        }
    }
}

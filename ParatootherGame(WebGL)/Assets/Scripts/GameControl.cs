using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class GameControl : MonoBehaviour
{
    public static event Action HandlePulled = delegate { };

    [SerializeField] private TextMeshProUGUI prizeText;
    [SerializeField] private Row[] rows;
    [SerializeField] private Transform handle;
    [SerializeField] private Transform planSlots2D;
    [SerializeField] private Transform planSlots3D;
    [SerializeField] public GameObject achievementGet;
    [SerializeField] public GameObject winnerWinnerBanner;
    [SerializeField] public GameObject jackpotBanner;
    public GameManager theGameManager;
    public ScoreManager theScoreManager;
    public PlayfabManager playfabManager;
    public bool handlePulled;
    public AudioSource handleSound;
    public AudioSource winSound;
    public AudioSource slotSound;
    public AudioSource loseSound;
    public AudioSource spaceSound;
    public AudioSource background2DSound;
    public AudioSource background3DSound;
    public AudioSource backgroundMusicNight;
    public AudioSource backgroundMusicSewer;
    public AudioSource backgroundMusicCity;
    public AudioSource backgroundMusicCityRain;
    public AudioSource backgroundMusicHouse;
    public AudioSource backgroundMusicCandyland;
    public AudioSource backgroundMusicWindLoop;
    public AudioSource achievementGetSound;
    private int prizeValue;
    private int rollCount = 1;
    private bool resultsChecked = false;

    void Awake()
    {
        Cursor.visible = true;
        Settings.slotBG = true;
        planSlots3D.gameObject.SetActive(true);
    }
    void Start()
    {
        if (Settings.musicBool == true)
        {
            slotSound.Play();
        }
        if (Settings.threeD == false)
        {
            Settings.holdTwoD = true;
            Settings.threeD = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (spaceSound.isPlaying)
        {
            spaceSound.Stop();
        }
        if (background2DSound.isPlaying)
        {
            background2DSound.Stop();
        }
        if (background3DSound.isPlaying)
        {
            background3DSound.Stop();
        }
        if (backgroundMusicNight.isPlaying)
        {
            backgroundMusicNight.Stop();
        }
        if (backgroundMusicSewer.isPlaying)
        {
            backgroundMusicSewer.Stop();
        }
        if (backgroundMusicCity.isPlaying)
        {
            backgroundMusicCity.Stop();
        }
        if (backgroundMusicCityRain.isPlaying)
        {
            backgroundMusicCityRain.Stop();
        }
        if (backgroundMusicHouse.isPlaying)
        {
            backgroundMusicHouse.Stop();
        }
        if (backgroundMusicCandyland.isPlaying)
        {
            backgroundMusicCandyland.Stop();
        }
        if (backgroundMusicWindLoop.isPlaying)
        {
            backgroundMusicWindLoop.Stop();
        }

        if (!rows[0].rowStopped || !rows[1].rowStopped || !rows[2].rowStopped)
        {
            prizeValue = 0;
            prizeText.enabled = false;
            resultsChecked = false;
        }

        if (rows[0].rowStopped && rows[1].rowStopped && rows[2].rowStopped && !resultsChecked)
        {
            CheckResults();
            prizeText.enabled = true;
            prizeText.text = "Prize:" + prizeValue;
            theScoreManager.AddSlotScore(prizeValue);
            if (prizeValue > 0 && Settings.soundFXBool == true)
            {
                winSound.Play();
            }
            else if(prizeValue <= 0 && rollCount >= 2 && Settings.soundFXBool == true)
            {
                loseSound.Play();
            }
            
            if (Settings.tokenNum <= 0)
            {
                StartCoroutine("GameOver");
            }
        }

        handlePulled = Input.GetKeyUp(KeyCode.Space);
        if (handlePulled)
            {
                OnMouseDown();
            }
    }

    private void OnMouseDown()
    {
        if (rows[0].rowStopped && rows[1].rowStopped && rows[2].rowStopped)
            if (Settings.tokenNum >= 1)
            {
                StartCoroutine("PullHandle");
                Settings.tokenNum -= 1;
                if (Settings.soundFXBool == true)
                {
                    handleSound.Play();
                }
                rollCount += 1;
            }
    }

    private IEnumerator GameOver()
    {
        yield return new WaitForSeconds(1.0f);
        theGameManager.RestartGame();
        playfabManager.SendLeaderboard(Settings.points);
    }

    private IEnumerator PullHandle()
    {
        for (int i = 0; i < 15; i+= 3)
        {
            handle.Rotate(-i, 0f, 0f);
            yield return new WaitForSeconds(0.05f);
        }

        HandlePulled();
        for (int i = 0; i < 15; i += 3)
        {
            handle.Rotate(i, 0f, 0f);
            yield return new WaitForSeconds(0.05f);
        }
    }

    private IEnumerator AchievementsGet()
    {
        if (Settings.achievementsEnabled)
        {
            achievementGetSound.Play();
            achievementGet.gameObject.SetActive(true);
            yield return new WaitForSeconds(6);
            achievementGet.gameObject.SetActive(false);
        }
    }

    private IEnumerator WinnerWinner()
    {
        if (Settings.achievementsEnabled)
        {
            playfabManager.SaveWinnerWinner();
            winnerWinnerBanner.gameObject.SetActive(true);
            yield return new WaitForSeconds(6);
            winnerWinnerBanner.gameObject.SetActive(false);
        }
    }
    private IEnumerator Jackpot()
    {
        if (Settings.achievementsEnabled)
        {
            playfabManager.SaveJackpot();
            jackpotBanner.gameObject.SetActive(true);
            yield return new WaitForSeconds(6);
            jackpotBanner.gameObject.SetActive(false);
        }
    }

    private void CheckResults()
    {
        if (rows[0].stoppedSlot == "Diamond"
            && rows[1].stoppedSlot == "Diamond"
            && rows[2].stoppedSlot == "Diamond")
        {
            prizeValue = 2222;
            if (Settings.winnerWinnerTog == 0 && AchievementGet.winnerWinnerAchievementGet == null)
            {
                Settings.winnerWinnerAchievement = "winnerWinner";
                Settings.winnerWinnerTog = 1;
                StartCoroutine("AchievementsGet");
                StartCoroutine("WinnerWinner");
            }
        }

        else if (rows[0].stoppedSlot == "Crown"
            && rows[1].stoppedSlot == "Crown"
            && rows[2].stoppedSlot == "Crown")
        {
            prizeValue = 4444;
            if (Settings.winnerWinnerTog == 0 && AchievementGet.winnerWinnerAchievementGet == null)
            {
                Settings.winnerWinnerAchievement = "winnerWinner";
                Settings.winnerWinnerTog = 1;
                StartCoroutine("AchievementsGet");
                StartCoroutine("WinnerWinner");
            }
        }

        else if (rows[0].stoppedSlot == "Mellon"
            && rows[1].stoppedSlot == "Mellon"
            && rows[2].stoppedSlot == "Mellon")
        {
            prizeValue = 8888;
            if (Settings.winnerWinnerTog == 0 && AchievementGet.winnerWinnerAchievementGet == null)
            {
                Settings.winnerWinnerAchievement = "winnerWinner";
                Settings.winnerWinnerTog = 1;
                StartCoroutine("AchievementsGet");
                StartCoroutine("WinnerWinner");
            }
        }

        else if (rows[0].stoppedSlot == "Bar"
            && rows[1].stoppedSlot == "Bar"
            && rows[2].stoppedSlot == "Bar")
        {
            prizeValue = 9999;
            if (Settings.winnerWinnerTog == 0 && AchievementGet.winnerWinnerAchievementGet == null)
            {
                Settings.winnerWinnerAchievement = "winnerWinner";
                Settings.winnerWinnerTog = 1;
                StartCoroutine("AchievementsGet");
                StartCoroutine("WinnerWinner");
            }
        }

        else if (rows[0].stoppedSlot == "Seven"
            && rows[1].stoppedSlot == "Seven"
            && rows[2].stoppedSlot == "Seven")
        {
            prizeValue = 15151;
            if (Settings.winnerWinnerTog == 0 && AchievementGet.winnerWinnerAchievementGet == null)
            {
                Settings.winnerWinnerAchievement = "winnerWinner";
                Settings.winnerWinnerTog = 1;
                StartCoroutine("AchievementsGet");
                StartCoroutine("WinnerWinner");
            }
        }

        else if (rows[0].stoppedSlot == "Cherry"
            && rows[1].stoppedSlot == "Cherry"
            && rows[2].stoppedSlot == "Cherry")
        {
            prizeValue = 34343;
            if (Settings.winnerWinnerTog == 0 && AchievementGet.winnerWinnerAchievementGet == null)
            {
                Settings.winnerWinnerAchievement = "winnerWinner";
                Settings.winnerWinnerTog = 1;
                StartCoroutine("AchievementsGet");
                StartCoroutine("WinnerWinner");
            }
        }

        else if (rows[0].stoppedSlot == "Lemon"
            && rows[1].stoppedSlot == "Lemon"
            && rows[2].stoppedSlot == "Lemon")
        {
            prizeValue = 53535;
            if (Settings.jackpotTog == 0 && AchievementGet.jackpotAchievementGet == null)
            {
                Settings.jackpotAchievement = "jackpot";
                Settings.winnerWinnerAchievement = "winnerWinner";
                Settings.jackpotTog = 1;
                Settings.winnerWinnerTog = 1;
                StartCoroutine("AchievementsGet");
                StartCoroutine("Jackpot");
            }
        }

        else if (((rows[0].stoppedSlot == rows[1].stoppedSlot) && (rows[0].stoppedSlot == "Diamond"))

            || ((rows[0].stoppedSlot == rows[2].stoppedSlot) && (rows[0].stoppedSlot == "Diamond"))

            || ((rows[1].stoppedSlot == rows[2].stoppedSlot) && (rows[1].stoppedSlot == "Diamond")))
        {
            prizeValue = 1111;
            if (Settings.winnerWinnerTog == 0 && AchievementGet.winnerWinnerAchievementGet == null)
            {
                Settings.winnerWinnerAchievement = "winnerWinner";
                Settings.winnerWinnerTog = 1;
                StartCoroutine("AchievementsGet");
                StartCoroutine("WinnerWinner");
            }
        }

        else if (((rows[0].stoppedSlot == rows[1].stoppedSlot) && (rows[0].stoppedSlot == "Crown"))

            || ((rows[0].stoppedSlot == rows[2].stoppedSlot) && (rows[0].stoppedSlot == "Crown"))

            || ((rows[1].stoppedSlot == rows[2].stoppedSlot) && (rows[1].stoppedSlot == "Crown")))
        {
            prizeValue = 3333;
            if (Settings.winnerWinnerTog == 0 && AchievementGet.winnerWinnerAchievementGet == null)
            {
                Settings.winnerWinnerAchievement = "winnerWinner";
                Settings.winnerWinnerTog = 1;
                StartCoroutine("AchievementsGet");
                StartCoroutine("WinnerWinner");
            }
        }

        else if (((rows[0].stoppedSlot == rows[1].stoppedSlot) && (rows[0].stoppedSlot == "Mellon"))

            || ((rows[0].stoppedSlot == rows[2].stoppedSlot) && (rows[0].stoppedSlot == "Mellon"))

            || ((rows[1].stoppedSlot == rows[2].stoppedSlot) && (rows[1].stoppedSlot == "Mellon")))
        {
            prizeValue = 5555;
            if (Settings.winnerWinnerTog == 0 && AchievementGet.winnerWinnerAchievementGet == null)
            {
                Settings.winnerWinnerAchievement = "winnerWinner";
                Settings.winnerWinnerTog = 1;
                StartCoroutine("AchievementsGet");
                StartCoroutine("WinnerWinner");
            }
        }

        else if (((rows[0].stoppedSlot == rows[1].stoppedSlot) && (rows[0].stoppedSlot == "Bar"))

            || ((rows[0].stoppedSlot == rows[2].stoppedSlot) && (rows[0].stoppedSlot == "Bar"))

            || ((rows[1].stoppedSlot == rows[2].stoppedSlot) && (rows[1].stoppedSlot == "Bar")))
        {
            prizeValue = 7777;
            if (Settings.winnerWinnerTog == 0 && AchievementGet.winnerWinnerAchievementGet == null)
            {
                Settings.winnerWinnerAchievement = "winnerWinner";
                Settings.winnerWinnerTog = 1;
                StartCoroutine("AchievementsGet");
                StartCoroutine("WinnerWinner");
            }
        }

        else if (((rows[0].stoppedSlot == rows[1].stoppedSlot) && (rows[0].stoppedSlot == "Seven"))

            || ((rows[0].stoppedSlot == rows[2].stoppedSlot) && (rows[0].stoppedSlot == "Seven"))

            || ((rows[1].stoppedSlot == rows[2].stoppedSlot) && (rows[1].stoppedSlot == "Seven")))
        {
            prizeValue = 11111;
            if (Settings.winnerWinnerTog == 0 && AchievementGet.winnerWinnerAchievementGet == null)
            {
                Settings.winnerWinnerAchievement = "winnerWinner";
                Settings.winnerWinnerTog = 1;
                StartCoroutine("AchievementsGet");
                StartCoroutine("WinnerWinner");
            }
        }

        else if (((rows[0].stoppedSlot == rows[1].stoppedSlot) && (rows[0].stoppedSlot == "Cherry"))

            || ((rows[0].stoppedSlot == rows[2].stoppedSlot) && (rows[0].stoppedSlot == "Cherry"))

            || ((rows[1].stoppedSlot == rows[2].stoppedSlot) && (rows[1].stoppedSlot == "Cherry")))
        {
            prizeValue = 22222;
            if (Settings.winnerWinnerTog == 0 && AchievementGet.winnerWinnerAchievementGet == null)
            {
                Settings.winnerWinnerAchievement = "winnerWinner";
                Settings.winnerWinnerTog = 1;
                StartCoroutine("AchievementsGet");
                StartCoroutine("WinnerWinner");
            }
        }

        else if (((rows[0].stoppedSlot == rows[1].stoppedSlot) && (rows[0].stoppedSlot == "Lemon"))

            || ((rows[0].stoppedSlot == rows[2].stoppedSlot) && (rows[0].stoppedSlot == "Lemon"))

            || ((rows[1].stoppedSlot == rows[2].stoppedSlot) && (rows[1].stoppedSlot == "Lemon")))
        {
            prizeValue = 33333;
            if (Settings.winnerWinnerTog == 0 && AchievementGet.winnerWinnerAchievementGet == null)
            {
                Settings.winnerWinnerAchievement = "winnerWinner";
                Settings.winnerWinnerTog = 1;
                StartCoroutine("AchievementsGet");
                StartCoroutine("WinnerWinner");
            }
        }

        resultsChecked = true;
    }
}

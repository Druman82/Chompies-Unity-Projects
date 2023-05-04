using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using TMPro;

public class AchievementGet : MonoBehaviour
{
    public static bool achievementsEnabled;
    public static string levelMasterAchievementGet;
    public static string rocketDodgerAchievement1Get;
    public static string rocketDodgerAchievement2Get;
    public static string rocketDodgerAchievement3Get;
    public static string winnerWinnerAchievementGet;
    public static string jackpotAchievementGet;
    public static string coinCountAchievement1Get;
    public static string coinCountAchievement2Get;
    public static string coinCountAchievement3Get;
    public static string parachuteCountAchievement1Get;
    public static string parachuteCountAchievement2Get;
    public static string parachuteCountAchievement3Get;
    public static string reckscollieAwardAchievementGet;
    public static string alternateSpaceAchievementGet;
    public static string totalPointsGet;
    public static string parachuteCountGet;
    public static string coinCountGet;
    public TextMeshProUGUI currentPointsText;
    public TextMeshProUGUI currentParachutesText;
    public TextMeshProUGUI currentCoinsText;
    public Text messageText;
    public PlayfabManager playfabManager;
    [SerializeField] public Transform levelMaster;
    [SerializeField] public Transform levelMasterDeactive;
    [SerializeField] public Transform rocketDodger1;
    [SerializeField] public Transform rocketDodgerDeactive1;
    [SerializeField] public Transform rocketDodger2;
    [SerializeField] public Transform rocketDodgerDeactive2;
    [SerializeField] public Transform rocketDodger3;
    [SerializeField] public Transform rocketDodgerDeactive3;
    [SerializeField] public Transform coinCounter1;
    [SerializeField] public Transform coinCounterDeactive1;
    [SerializeField] public Transform coinCounter2;
    [SerializeField] public Transform coinCounterDeactive2;
    [SerializeField] public Transform coinCounter3;
    [SerializeField] public Transform coinCounterDeactive3;
    [SerializeField] public Transform parachuteCounter1;
    [SerializeField] public Transform parachuteCounterDeactive1;
    [SerializeField] public Transform parachuteCounter2;
    [SerializeField] public Transform parachuteCounterDeactive2;
    [SerializeField] public Transform parachuteCounter3;
    [SerializeField] public Transform parachuteCounterDeactive3;
    [SerializeField] public Transform winnerWinner;
    [SerializeField] public Transform winnerWinnerDeactive;
    [SerializeField] public Transform jackpot;
    [SerializeField] public Transform jackpotDeactive;
    [SerializeField] public Transform reckscollieAward;
    [SerializeField] public Transform reckscollieAwardDeactive;
    [SerializeField] public Transform alternateSpace;
    [SerializeField] public Transform alternateSpaceDeactive;

    void Awake()
    {
        GetLevelMaster();
        currentPointsText.text = "Current Points: " + totalPointsGet;
        currentParachutesText.text = "Current Amount: " + parachuteCountGet;
        currentCoinsText.text = "Current Amount: " + coinCountGet;
    }

    public void GetLevelMaster()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), OnDataRecieved, OnError);
    }

    void OnDataRecieved(GetUserDataResult result)
    {
        Debug.Log("Recieved user data!");
        if (result.Data != null)
        {
            if (result.Data.ContainsKey("levelMaster"))
            {
                levelMasterAchievementGet = result.Data["levelMaster"].Value;
            }
            if (result.Data.ContainsKey("reckscollieAward"))
            {
                reckscollieAwardAchievementGet = result.Data["reckscollieAward"].Value;
            }
            if (result.Data.ContainsKey("totalPoints"))
            {
                totalPointsGet = result.Data["totalPoints"].Value;
                Settings.totalPoints = int.Parse(totalPointsGet);
            }
            if (result.Data.ContainsKey("winnerWinner"))
            {
                winnerWinnerAchievementGet = result.Data["winnerWinner"].Value;
            }
            if (result.Data.ContainsKey("jackpot"))
            {
                jackpotAchievementGet = result.Data["jackpot"].Value;
            }
            if (result.Data.ContainsKey("alternateSpace"))
            {
                alternateSpaceAchievementGet = result.Data["alternateSpace"].Value;
            }
            if (result.Data.ContainsKey("rocketDodger1"))
            {
                rocketDodgerAchievement1Get = result.Data["rocketDodger1"].Value;
            }
            if (result.Data.ContainsKey("rocketDodger2"))
            {
                rocketDodgerAchievement2Get = result.Data["rocketDodger2"].Value;
            }
            if (result.Data.ContainsKey("rocketDodger3"))
            {
                rocketDodgerAchievement3Get = result.Data["rocketDodger3"].Value;
            }
            if (result.Data.ContainsKey("coinCount"))
            {
                coinCountGet = result.Data["coinCount"].Value;
                Settings.coinCount = int.Parse(coinCountGet);
            }
            if (result.Data.ContainsKey("coinCount1"))
            {
                coinCountAchievement1Get = result.Data["coinCount1"].Value;
            }
            if (result.Data.ContainsKey("coinCount2"))
            {
                coinCountAchievement2Get = result.Data["coinCount2"].Value;
            }
            if (result.Data.ContainsKey("coinCount3"))
            {
                coinCountAchievement3Get = result.Data["coinCount3"].Value;
            }
            if (result.Data.ContainsKey("parachuteCount"))
            {
                parachuteCountGet = result.Data["parachuteCount"].Value;
                Settings.parachuteCount = int.Parse(parachuteCountGet);
            }
            if (result.Data.ContainsKey("parachuteCount1"))
            {
                parachuteCountAchievement1Get = result.Data["parachuteCount1"].Value;
            }
            if (result.Data.ContainsKey("parachuteCount2"))
            {
                parachuteCountAchievement2Get = result.Data["parachuteCount2"].Value;
            }
            if (result.Data.ContainsKey("parachuteCount3"))
            {
                parachuteCountAchievement3Get = result.Data["parachuteCount3"].Value;
            }

        }
        else
        {
            Debug.Log("Player data not complete!");
        }
    }

    void Update()
    {
        //Achievements

        //Level Master Get
        if (levelMasterAchievementGet == "levelMaster")
        {
            levelMaster.gameObject.SetActive(true);
            levelMasterDeactive.gameObject.SetActive(false);
        }
        else
        {
            levelMaster.gameObject.SetActive(false);
            levelMasterDeactive.gameObject.SetActive(true);
        }
        
        //Reckscollie Award
        if (reckscollieAwardAchievementGet == "reckscollieAward" || Settings.totalPoints > 1000000)
        {
            reckscollieAward.gameObject.SetActive(true);
            reckscollieAwardDeactive.gameObject.SetActive(false);
        }
        else
        {
            reckscollieAward.gameObject.SetActive(false);
            reckscollieAwardDeactive.gameObject.SetActive(true);
        }

        //Alternate Space
        if (alternateSpaceAchievementGet == "alternateSpace")
        {
            alternateSpace.gameObject.SetActive(true);
            alternateSpaceDeactive.gameObject.SetActive(false);
        }
        else
        {
            alternateSpace.gameObject.SetActive(false);
            alternateSpaceDeactive.gameObject.SetActive(true);
        }

        //Rocket Dodger Get
        if (rocketDodgerAchievement1Get == "rocketDodger1")
        {
            rocketDodger1.gameObject.SetActive(true);
            rocketDodgerDeactive1.gameObject.SetActive(false);
        }
        else
        {
            rocketDodger1.gameObject.SetActive(false);
            rocketDodgerDeactive1.gameObject.SetActive(true);
        }
        if (rocketDodgerAchievement2Get == "rocketDodger2")
        {
            rocketDodger2.gameObject.SetActive(true);
            rocketDodgerDeactive2.gameObject.SetActive(false);
        }
        else
        {
            rocketDodger2.gameObject.SetActive(false);
            rocketDodgerDeactive2.gameObject.SetActive(true);
        }
        if (rocketDodgerAchievement3Get == "rocketDodger3")
        {
            rocketDodger3.gameObject.SetActive(true);
            rocketDodgerDeactive3.gameObject.SetActive(false);
        }
        else
        {
            rocketDodger3.gameObject.SetActive(false);
            rocketDodgerDeactive3.gameObject.SetActive(true);
        }

        //Winner Winner Get
        if (winnerWinnerAchievementGet == "winnerWinner")
        {
            winnerWinner.gameObject.SetActive(true);
            winnerWinnerDeactive.gameObject.SetActive(false);
        }
        else
        {
            winnerWinner.gameObject.SetActive(false);
            winnerWinnerDeactive.gameObject.SetActive(true);
        }
        
        //Jackpot Get
        if (jackpotAchievementGet == "jackpot")
        {
            jackpot.gameObject.SetActive(true);
            jackpotDeactive.gameObject.SetActive(false);
        }
        else
        {
            jackpot.gameObject.SetActive(false);
            jackpotDeactive.gameObject.SetActive(true);
        }

        //Coin Count Get
        if (coinCountAchievement1Get == "coinCount1" || Settings.parachuteCount >= 100)
        {
            coinCounter1.gameObject.SetActive(true);
            coinCounterDeactive1.gameObject.SetActive(false);
        }
        else
        {
            coinCounter1.gameObject.SetActive(false);
            coinCounterDeactive1.gameObject.SetActive(true);
        }
        if (coinCountAchievement2Get == "coinCount2" || Settings.parachuteCount >= 1000)
        {
            coinCounter2.gameObject.SetActive(true);
            coinCounterDeactive2.gameObject.SetActive(false);
        }
        else
        {
            coinCounter2.gameObject.SetActive(false);
            coinCounterDeactive2.gameObject.SetActive(true);
        }
        if (coinCountAchievement3Get == "coinCount3" || Settings.parachuteCount >= 10000)
        {
            coinCounter3.gameObject.SetActive(true);
            coinCounterDeactive3.gameObject.SetActive(false);
        }
        else
        {
            coinCounter3.gameObject.SetActive(false);
            coinCounterDeactive3.gameObject.SetActive(true);
        }

        //parachute Count Get
        if (parachuteCountAchievement1Get == "parachuteCount1" || Settings.parachuteCount >= 50)
        {
            parachuteCounter1.gameObject.SetActive(true);
            parachuteCounterDeactive1.gameObject.SetActive(false);
        }
        else
        {
            parachuteCounter1.gameObject.SetActive(false);
            parachuteCounterDeactive1.gameObject.SetActive(true);
        }
        if (parachuteCountAchievement2Get == "parachuteCount2" || Settings.parachuteCount >= 500)
        {
            parachuteCounter2.gameObject.SetActive(true);
            parachuteCounterDeactive2.gameObject.SetActive(false);
        }
        else
        {
            parachuteCounter2.gameObject.SetActive(false);
            parachuteCounterDeactive2.gameObject.SetActive(true);
        }
        if (parachuteCountAchievement3Get == "parachuteCountt3" || Settings.parachuteCount >= 5000)
        {
            parachuteCounter3.gameObject.SetActive(true);
            parachuteCounterDeactive3.gameObject.SetActive(false);
        }
        else
        {
            parachuteCounter3.gameObject.SetActive(false);
            parachuteCounterDeactive3.gameObject.SetActive(true);
        }
    }



    void OnError(PlayFabError error)
    {
        messageText.text = error.ErrorMessage;
        Debug.Log("No Data to send!");
        Debug.Log(error.GenerateErrorReport());
    }
}

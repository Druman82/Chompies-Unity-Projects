using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;


public class PlayfabManager : MonoBehaviour
{   
    public GameObject rowPrefab;
    public Transform rowsParent;
    public GameObject nameWindow;
    public GameObject loginWindow;
    public GameObject optionsWindow;
    public GameObject deleteAccountWindow;
    public GameObject openScreenWindow;
    public GameObject chooseTeamWindow;
    public Text score;
    [Header("UI")]
    public List<double> leaderboardList = new List<double>();
    public Text messageText;
    public Text messageOfTheDayText;
    public Text winterBG;
    public int chompiesNum;
    public int chompies2Num;
    public int hikeshiNum;
    public int apeGangNum;
    public int brawlerBearsNum;
    public int cryptoDadsNum;
    public int gamingApeClubNum;
    public int spaceRidersNum;
    public int tacoTribeNum;
    public int thePlagueNum;
    public int team1Num;
    public int team2Num;
    public int team3Num;
    public int team4Num;
    public int team5Num;
    private int chompiesCount;
    private int chompies2Count;
    private int hikeshiCount;
    private int apeGangCount;
    private int brawlerBearsCount;
    private int cryptoDadsCount;
    private int gamingApeClubCount;
    private int spaceRidersCount;
    private int tacoTribeCount;
    private int thePlagueCount;
    private int team1Count;
    private int team2Count;
    private int team3Count;
    private int team4Count;
    private int team5Count;
    public double chompiesAverageNum;
    public double chompies2AverageNum;
    public double hikeshiAverageNum;
    public double apeGangAverageNum;
    public double brawlerBearsAverageNum;
    public double cryptoDadsAverageNum;
    public double gamingApeClubAverageNum;
    public double spaceRidersAverageNum;
    public double tacoTribeAverageNum;
    public double thePlagueAverageNum;
    public double team1AverageNum;
    public double team2AverageNum;
    public double team3AverageNum;
    public double team4AverageNum;
    public double team5AverageNum;
    public static double chompiesAverageNumber;
    public static double chompies2AverageNumber;
    public static double hikeshiAverageNumber;
    public static double apeGangAverageNumber;
    public static double brawlerBearsAverageNumber;
    public static double cryptoDadsAverageNumber;
    public static double gamingApeClubAverageNumber;
    public static double spaceRidersAverageNumber;
    public static double tacoTribeAverageNumber;
    public static double thePlagueAverageNumber;
    public static double team1AverageNumber;
    public static double team2AverageNumber;
    public static double team3AverageNumber;
    public static double team4AverageNumber;
    public static double team5AverageNumber;
    public Text deleteAccountMessageText;
    public InputField emailInput;
    public InputField usernameInput;
    public InputField passwordInput;
    public string mainMenu;
    public string houseMenu;
    public string raceLevel;
    public InputField recipientEmail;
    public static string cryptoWallet;
    public static string levelMaster;
    public Text crypto;
    string loggedInPlayfabId;
    public Toggle rememberMe;
    
    void Awake()
    {
        emailInput.text = PlayerPrefs.GetString("PlayAccountMail");
        passwordInput.text = PlayerPrefs.GetString("PlayAccountPass");
        // if remember me is checked, set the account to the saved account
        if (PlayerPrefs.HasKey("RememberMe") && PlayerPrefs.HasKey("PlayAccount"))
        {
            if (PlayerPrefs.GetInt("RememberMe") == 1 && PlayerPrefs.GetString("PlayAccount") != "")
            {
                // move to next scene
                loginWindow.SetActive(false);
                openScreenWindow.SetActive(false);
                RememberLogin();
            }
        }
    }

    void Start()
    {
        if (Settings.raceLeaderboard == true)
        {
            GetRaceLeaderboard();
        }
        if (Settings.apeGangLeaderboard == true)
        {
            GetApeGangLeaderboard();
        }
        if (Settings.brawlerBearsLeaderboard == true)
        {
            GetBrawlerBearsLeaderboard();
        }
        if (Settings.cryptoDadsLeaderboard == true)
        {
            GetCryptoDadsLeaderboard();
        }
        if (Settings.gamingApeClubLeaderboard == true)
        {
            GetGamingApeClubLeaderboard();
        }
        if (Settings.hikeshiLeaderboard == true)
        {
            GetHikeshiLeaderboard();
        }
        if (Settings.spaceRidersLeaderboard == true)
        {
            GetSpaceRidersLeaderboard();
        }
        if (Settings.heroGalaxyLeaderboard == true)
        {
            GetHeroGalaxyLeaderboard();
        }
        if (Settings.tacoTribeLeaderboard == true)
        {
            GetTacoTribeLeaderboard();
        }
        if (Settings.thePlagueLeaderboard == true)
        {
            GetThePlagueLeaderboard();
        }
        
        if (Settings.team1Leaderboard == true)
        {
            GetTeam1Leaderboard();
        }
        if (Settings.team2Leaderboard == true)
        {
            GetTeam2Leaderboard();
        }
        if (Settings.team3Leaderboard == true)
        {
            GetTeam3Leaderboard();
        }
        if (Settings.team4Leaderboard == true)
        {
            GetTeam4Leaderboard();
        }
        if (Settings.team5Leaderboard == true)
        {
            GetTeam5Leaderboard();
        }

        else if (Settings.teamLeaderboard == true)
        {
            GetApeGangLeaderboardAverage();
            GetBrawlerBearsLeaderboardAverage();
            //GetChompiesLeaderboardAverage();
            //GetChompiesLeaderboardAverage2();
            GetCryptoDadsLeaderboardAverage();
            //GetHikeshiLeaderboardAverage();
            GetGamingApeClubLeaderboardAverage();
            GetSpaceRidersLeaderboardAverage();
            GetTacoTribeLeaderboardAverage();
            GetThePlagueLeaderboardAverage();
        }
        else if (Settings.raceTeamLeaderboard == true)
        {
            GetTeam1LeaderboardAverage();
            GetTeam2LeaderboardAverage();
            GetTeam3LeaderboardAverage();
            GetTeam4LeaderboardAverage();
            GetTeam5LeaderboardAverage();
        }

        else if (Settings.apeGangLeaderboard == false && Settings.brawlerBearsLeaderboard == false && Settings.cryptoDadsLeaderboard == false && Settings.gamingApeClubLeaderboard == false && Settings.heroGalaxyLeaderboard == false && Settings.hikeshiLeaderboard == false && Settings.spaceRidersLeaderboard == false && Settings.tacoTribeLeaderboard == false && Settings.thePlagueLeaderboard == false && Settings.teamLeaderboard == false && Settings.raceLeaderboard == false && Settings.raceTeamLeaderboard == false && Settings.team1Leaderboard == false && Settings.team2Leaderboard == false && Settings.team3Leaderboard == false && Settings.team4Leaderboard == false && Settings.team5Leaderboard == false)
        {
            GetLeaderboard();
        }
    }

    public static void DeletePlayerPrefs()
    {
        PlayerPrefs.DeleteKey("PlayAccount");
    }

    public void RegisterButton()
    {
        if (passwordInput.text.Length < 6)
        {
            messageText.text = "Password too short!";
            return;
        }
        var request = new RegisterPlayFabUserRequest
        {
            Email = emailInput.text,
            Password = passwordInput.text,
            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
    }

    void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        messageText.text = "Registered and logged in!";
        nameWindow.SetActive(true);
        loginWindow.SetActive(false);
    }

    public void LoginButton()
    {        
        var request = new LoginWithEmailAddressRequest
        {
            Email = emailInput.text,
            Password = passwordInput.text
        };
        PlayerPrefs.SetString("PlayAccountMail", emailInput.text);
        PlayerPrefs.SetString("PlayAccountPass", passwordInput.text);
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnError);
    }

    public void DeleteAccountButton()
    {
        messageText.text = "";
        if (recipientEmail.text.Length < 1)
        {
            deleteAccountMessageText.text = "Invalid input";
            return;
        }
        else 
        {
            SendEmail();
            deleteAccountMessageText.text = "Account deletion request sent to your email. May take up to 24 hours.";
            messageText.text = "Account deletion request sent to your email. May take up to 24 hours.";
            deleteAccountWindow.SetActive(false);
            loginWindow.SetActive(true);
        }
    }

    public void ResetPasswordButton()
    {
        var request = new SendAccountRecoveryEmailRequest
        {
            Email = emailInput.text,
            TitleId = "5CE83"
        };
        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnPasswordReset, OnError);
    }
    void OnPasswordReset(SendAccountRecoveryEmailResult result)
    {
        messageText.text = "Password reset email sent!";
    }

    void Login()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true,

            InfoRequestParameters = new GetPlayerCombinedInfoRequestParams
            {
                GetPlayerProfile = true,
            } 
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnError);
    }
    
    void RememberLogin()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = PlayerPrefs.GetString("PlayAccountMail"),
            Password = PlayerPrefs.GetString("PlayAccountPass")
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnError);
    }

    void OnLoginSuccess(LoginResult result)
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
        };
        loggedInPlayfabId = result.PlayFabId;
        PlayerPrefs.SetString("PlayAccount", request.CustomId.ToString());
        if (rememberMe.isOn)
            PlayerPrefs.SetInt("RememberMe", 1);
        else
            PlayerPrefs.SetInt("RememberMe", 0);
        messageText.text = "Logged in!";
        Settings.achievementsEnabled = true;
        string name = null;
        SetUserDataValue(cryptoWallet, cryptoWallet);
        if (name == null)
        {
            nameWindow.SetActive(true);
            loginWindow.SetActive(false);
        }
        else
        {
            Debug.Log("Successful login/account created!");
            //chooseTeamWindow.SetActive(true);
            MainMenu();
        }
    }

    public void SubmitNameButton()
    {
        var request = new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = usernameInput.text,
        };
        PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnDisplayNameUpdate, OnError);
        //chooseTeamWindow.SetActive(true);
        nameWindow.SetActive(false);
       MainMenu();
    }

    public void SkipUserName()
    {
        //chooseTeamWindow.SetActive(true);
        nameWindow.SetActive(false);
        MainMenu();
    }

    public void TryParatoother()
    {
        StartCoroutine("MainMenus");
    }

    public IEnumerator MainMenus()
    {
        yield return new WaitForSeconds(0.75f);
        MainMenu();
    }

    void OnDisplayNameUpdate(UpdateUserTitleDisplayNameResult result)
    {
        Debug.Log("Updated display name!");
    }

    void OnError(PlayFabError error)
    {
        messageText.text = error.ErrorMessage;
        Debug.Log("Error while logging in/creating account!");
        Debug.Log(error.GenerateErrorReport());
    }


    //Send Leaderboards
    //Race Leaderboards
    public void SendTimeLeaderboard(int time)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "TimeRunner",
                    Value = time
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    }
    public void SendTeam1Leaderboard(int time)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "Electric Chompy",
                    Value = time
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    }
    public void SendTeam2Leaderboard(int time)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "Hoodie Gang",
                    Value = time
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    }
    public void SendTeam3Leaderboard(int time)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "Nude",
                    Value = time
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    }
    public void SendTeam4Leaderboard(int time)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "Money Maker",
                    Value = time
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    }
    public void SendTeam5Leaderboard(int time)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "Sports Illustrated",
                    Value = time
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    }

    //Paratoother Leaderboards
    public void SendLeaderboard(int score)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "PlatformScore",
                    Value = score
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    }
    public void SendHeroGalaxyLeaderboard(int score)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "HeroGalaxy",
                    Value = score
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    }

    public void SendApeGangLeaderboard(int score)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "ApeGang",
                    Value = score
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    }
    public void SendBrawlerBearsLeaderboard(int score)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "BrawlerBears",
                    Value = score
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    }
    public void SendCryptoDadsLeaderboard(int score)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "CryptoDads",
                    Value = score
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    }
    public void SendGamingApeClubLeaderboard(int score)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "GamingApeClub",
                    Value = score
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    }
    public void SendHikeshiLeaderboard(int score)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "HikeshiLeaderboard",
                    Value = score
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    }
    public void SendSpaceRidersLeaderboard(int score)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "SpaceRiders",
                    Value = score
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    }
    public void SendTacoTribeLeaderboard(int score)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "TacoTribe",
                    Value = score
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    }
    public void SendThePlagueLeaderboard(int score)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "ThePlague",
                    Value = score
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    }

    void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Successfull leaderboard sent");
    }


    //Get Leaderboards
    //Race Leaderboards
    public void GetRaceLeaderboard()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "TimeRunner",
            StartPosition = 0,
            MaxResultsCount = 100
        };
        PlayFabClientAPI.GetLeaderboard(request, OnRaceLeaderboardGet, OnError);
        GetTitleData();
    }
    public void GetTeam1Leaderboard()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "Electric Chompy",
            StartPosition = 0,
            MaxResultsCount = 100
        };
        PlayFabClientAPI.GetLeaderboard(request, OnTeam1LeaderboardGet, OnError);
    }
    public void GetTeam2Leaderboard()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "Hoodie Gang",
            StartPosition = 0,
            MaxResultsCount = 100
        };
        PlayFabClientAPI.GetLeaderboard(request, OnTeam2LeaderboardGet, OnError);
    }
    public void GetTeam3Leaderboard()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "Nude",
            StartPosition = 0,
            MaxResultsCount = 100
        };
        PlayFabClientAPI.GetLeaderboard(request, OnTeam3LeaderboardGet, OnError);
    }
    public void GetTeam4Leaderboard()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "Money Maker",
            StartPosition = 0,
            MaxResultsCount = 100
        };
        PlayFabClientAPI.GetLeaderboard(request, OnTeam4LeaderboardGet, OnError);
    }
    public void GetTeam5Leaderboard()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "Sports Illustrated",
            StartPosition = 0,
            MaxResultsCount = 100
        };
        PlayFabClientAPI.GetLeaderboard(request, OnTeam5LeaderboardGet, OnError);
    }

    //Paratoother Leaderboards
    public void GetLeaderboard()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "PlatformScore",
            StartPosition = 0,
            MaxResultsCount = 100
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, OnError);
        GetTitleData();
        //GetUserData();
    }
    public void GetHeroGalaxyLeaderboard()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "HeroGalaxy",
            StartPosition = 0,
            MaxResultsCount = 100
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, OnError);
        GetTitleData();
    }
    public void GetApeGangLeaderboard()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "ApeGang",
            StartPosition = 0,
            MaxResultsCount = 100
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, OnError);
    }
    public void GetBrawlerBearsLeaderboard()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "BrawlerBears",
            StartPosition = 0,
            MaxResultsCount = 100
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, OnError);
    }
    public void GetCryptoDadsLeaderboard()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "CryptoDads",
            StartPosition = 0,
            MaxResultsCount = 100
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, OnError);
    }
    public void GetGamingApeClubLeaderboard()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "GamingApeClub",
            StartPosition = 0,
            MaxResultsCount = 100
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, OnError);
    }
    public void GetHikeshiLeaderboard()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "HikeshiLeaderboard",
            StartPosition = 0,
            MaxResultsCount = 100
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, OnError);
    }
    public void GetSpaceRidersLeaderboard()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "SpaceRiders",
            StartPosition = 0,
            MaxResultsCount = 100
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, OnError);
    }
    public void GetTacoTribeLeaderboard()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "TacoTribe",
            StartPosition = 0,
            MaxResultsCount = 100
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, OnError);
    }
    public void GetThePlagueLeaderboard()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "ThePlague",
            StartPosition = 0,
            MaxResultsCount = 100
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, OnError);
    }


    //Get Leaderboard Averages
    //Race Leaderboard
    public void GetTeam1LeaderboardAverage()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "Electric Chompy",
            StartPosition = 0,
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboard(request, OnTeam1LeaderboardGetAverage, OnError);
    }
    public void GetTeam2LeaderboardAverage()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "Hoodie Gang",
            StartPosition = 0,
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboard(request, OnTeam2LeaderboardGetAverage, OnError);
    }
    public void GetTeam3LeaderboardAverage()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "Nude",
            StartPosition = 0,
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboard(request, OnTeam3LeaderboardGetAverage, OnError);
    }
    public void GetTeam4LeaderboardAverage()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "Money Maker",
            StartPosition = 0,
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboard(request, OnTeam4LeaderboardGetAverage, OnError);
    }
    public void GetTeam5LeaderboardAverage()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "Sports Illustrated",
            StartPosition = 0,
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboard(request, OnTeam5LeaderboardGetAverage, OnError);
    }

    //Paratoother Leaderboard Average
    public void GetChompiesLeaderboardAverage()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "PlatformScore",
            StartPosition = 0,
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboard(request, OnChompiesLeaderboardGetAverage, OnError);
    }
    public void GetChompiesLeaderboardAverage2()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "PlatformScore",
            StartPosition = 11,
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboard(request, OnChompiesLeaderboardGetAverage2, OnError);
    }
    public void GetApeGangLeaderboardAverage()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "ApeGang",
            StartPosition = 0,
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboard(request, OnApeGangLeaderboardGetAverage, OnError);
    }
    public void GetBrawlerBearsLeaderboardAverage()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "BrawlerBears",
            StartPosition = 0,
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboard(request, OnBrawlerBearsLeaderboardGetAverage, OnError);
    }
    public void GetCryptoDadsLeaderboardAverage()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "CryptoDads",
            StartPosition = 0,
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboard(request, OnCryptoDadsLeaderboardGetAverage, OnError);
    }
    public void GetGamingApeClubLeaderboardAverage()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "GamingApeClub",
            StartPosition = 0,
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboard(request, OnGamingApeClubLeaderboardGetAverage, OnError);
    }
    public void GetHikeshiLeaderboardAverage()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "HikeshiLeaderboard",
            StartPosition = 0,
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboard(request, OnHikeshiLeaderboardGetAverage, OnError);
    }
    public void GetSpaceRidersLeaderboardAverage()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "SpaceRiders",
            StartPosition = 0,
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboard(request, OnSpaceRidersLeaderboardGetAverage, OnError);
    }
    public void GetTacoTribeLeaderboardAverage()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "TacoTribe",
            StartPosition = 0,
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboard(request, OnTacoTribeLeaderboardGetAverage, OnError);
    }
    public void GetThePlagueLeaderboardAverage()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "ThePlague",
            StartPosition = 0,
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboard(request, OnThePlagueLeaderboardGetAverage, OnError);
    }


    //On Leaderboard Get Average
    //Race Leaderboard
    void OnTeam1LeaderboardGetAverage(GetLeaderboardResult result)
    {
        foreach (var item in result.Leaderboard)
        {
            team1Num = item.StatValue;
            team1Count++;
            team1AverageNum = team1AverageNum + team1Num;
        }
        team1AverageNumber = Math.Round(team1AverageNum / team1Count);
        leaderboardList.Add(team1AverageNumber / 100);
    }
    void OnTeam2LeaderboardGetAverage(GetLeaderboardResult result)
    {
        foreach (var item in result.Leaderboard)
        {
            team2Num = item.StatValue;
            team2Count++;
            team2AverageNum = team2AverageNum + team2Num;
        }
        team2AverageNumber = Math.Round(team2AverageNum / team2Count);
        leaderboardList.Add(team2AverageNumber / 100);
    }
    void OnTeam3LeaderboardGetAverage(GetLeaderboardResult result)
    {
        foreach (var item in result.Leaderboard)
        {
            team3Num = item.StatValue;
            team3Count++;
            team3AverageNum = team3AverageNum + team3Num;
        }
        team3AverageNumber = Math.Round(team3AverageNum / team3Count);
        leaderboardList.Add(team3AverageNumber / 100);
    }
    void OnTeam4LeaderboardGetAverage(GetLeaderboardResult result)
    {
        foreach (var item in result.Leaderboard)
        {
            team4Num = item.StatValue;
            team4Count++;
            team4AverageNum = team4AverageNum + team4Num;
        }
        team4AverageNumber = Math.Round(team4AverageNum / team4Count);
        leaderboardList.Add(team4AverageNumber / 100);
    }
    void OnTeam5LeaderboardGetAverage(GetLeaderboardResult result)
    {
        foreach (var item in result.Leaderboard)
        {
            team5Num = item.StatValue;
            team5Count++;
            team5AverageNum = team5AverageNum + team5Num;
        }
        team5AverageNumber = Math.Round(team5AverageNum / team5Count);
        leaderboardList.Add(team5AverageNumber / 100);
    }

    //Paratoother Leaderboard Get Average
    void OnChompiesLeaderboardGetAverage(GetLeaderboardResult result)
    {
        foreach (var item in result.Leaderboard)
        {
            chompiesNum = item.StatValue;
            chompiesCount++;
            chompiesAverageNum = chompiesAverageNum + chompiesNum;

            //Debug.Log(item.Position + " " + item.PlayFabId + " " + item.StatValue);
        }
        chompiesAverageNumber = Math.Round(chompiesAverageNum / chompiesCount);
        leaderboardList.Add(chompiesAverageNumber);
    }
        void OnChompiesLeaderboardGetAverage2(GetLeaderboardResult result)
    {
        foreach (var item in result.Leaderboard)
        {
            chompies2Num = item.StatValue;
            chompies2Count++;
            chompies2AverageNum = chompies2AverageNum + chompies2Num;
        }
        chompies2AverageNumber = Math.Round(chompies2AverageNum / chompies2Count);
        leaderboardList.Add(chompies2AverageNumber);
    }
    void OnApeGangLeaderboardGetAverage(GetLeaderboardResult result)
    {
        foreach (var item in result.Leaderboard)
        {
            apeGangNum = item.StatValue;
            apeGangCount++;
            apeGangAverageNum = apeGangAverageNum + apeGangNum;
        }
        apeGangAverageNumber = Math.Round(apeGangAverageNum / apeGangCount);
        leaderboardList.Add(apeGangAverageNumber);
    }
    void OnBrawlerBearsLeaderboardGetAverage(GetLeaderboardResult result)
    {
        foreach (var item in result.Leaderboard)
        {
            brawlerBearsNum = item.StatValue;
            brawlerBearsCount++;
            brawlerBearsAverageNum = brawlerBearsAverageNum + brawlerBearsNum;
        }
        brawlerBearsAverageNumber = Math.Round(brawlerBearsAverageNum / brawlerBearsCount);
        leaderboardList.Add(brawlerBearsAverageNumber);
    }
    void OnCryptoDadsLeaderboardGetAverage(GetLeaderboardResult result)
    {
        foreach (var item in result.Leaderboard)
        {
            cryptoDadsNum = item.StatValue;
            cryptoDadsCount++;
            cryptoDadsAverageNum = cryptoDadsAverageNum + cryptoDadsNum;
        }
        cryptoDadsAverageNumber = Math.Round(cryptoDadsAverageNum / cryptoDadsCount);
        leaderboardList.Add(cryptoDadsAverageNumber);
    }
    void OnGamingApeClubLeaderboardGetAverage(GetLeaderboardResult result)
    {
        foreach (var item in result.Leaderboard)
        {
            gamingApeClubNum = item.StatValue;
            gamingApeClubCount++;
            gamingApeClubAverageNum = gamingApeClubAverageNum + gamingApeClubNum;
        }
        gamingApeClubAverageNumber = Math.Round(gamingApeClubAverageNum / gamingApeClubCount);
        leaderboardList.Add(gamingApeClubAverageNumber);
    }
    void OnHikeshiLeaderboardGetAverage(GetLeaderboardResult result)
    {
        foreach (var item in result.Leaderboard)
        {
            hikeshiNum = item.StatValue;
            hikeshiCount++;
            hikeshiAverageNum = hikeshiAverageNum + hikeshiNum;
        }
        hikeshiAverageNumber = Math.Round(hikeshiAverageNum / hikeshiCount);
        leaderboardList.Add(hikeshiAverageNumber);
        leaderboardList.Sort();
        foreach (int x in leaderboardList){
            Debug.Log("list " + x.ToString());
        }
    }
    void OnSpaceRidersLeaderboardGetAverage(GetLeaderboardResult result)
    {
        foreach (var item in result.Leaderboard)
        {
            spaceRidersNum = item.StatValue;
            spaceRidersCount++;
            spaceRidersAverageNum = spaceRidersAverageNum + spaceRidersNum;
        }
        spaceRidersAverageNumber = Math.Round(spaceRidersAverageNum / spaceRidersCount);
        leaderboardList.Add(spaceRidersAverageNumber);
    }
    void OnTacoTribeLeaderboardGetAverage(GetLeaderboardResult result)
    {
        foreach (var item in result.Leaderboard)
        {
            tacoTribeNum = item.StatValue;
            tacoTribeCount++;
            tacoTribeAverageNum = tacoTribeAverageNum + tacoTribeNum;
        }
        tacoTribeAverageNumber = Math.Round(tacoTribeAverageNum / tacoTribeCount);
        leaderboardList.Add(tacoTribeAverageNumber);
    }
    void OnThePlagueLeaderboardGetAverage(GetLeaderboardResult result)
    {
        foreach (var item in result.Leaderboard)
        {
            thePlagueNum = item.StatValue;
            thePlagueCount++;
            thePlagueAverageNum = thePlagueAverageNum + thePlagueNum;
        }
        thePlagueAverageNumber = Math.Round(thePlagueAverageNum / thePlagueCount);
        leaderboardList.Add(thePlagueAverageNumber);
    }


    //On Leaderboard Get
    //Race Leaderboard
    void OnRaceLeaderboardGet(GetLeaderboardResult result)
    {
        foreach (var item in result.Leaderboard)
        {
            GameObject newGo = Instantiate(rowPrefab, rowsParent);
            Text[] texts = newGo.GetComponentsInChildren<Text>();
            texts[0].text = " ";
            texts[1].text = item.DisplayName;
            float score = (float)item.StatValue;
            score = score / 100;
            texts[2].text = score.ToString("0.00");
        }
    }
    void OnTeam1LeaderboardGet(GetLeaderboardResult result)
    {
        foreach (var item in result.Leaderboard)
        {
            GameObject newGo = Instantiate(rowPrefab, rowsParent);
            Text[] texts = newGo.GetComponentsInChildren<Text>();
            texts[0].text = " ";
            texts[1].text = item.DisplayName;
            float score = (float)item.StatValue;
            score = score / 100;
            texts[2].text = score.ToString("0.00");
        }
    }
    void OnTeam2LeaderboardGet(GetLeaderboardResult result)
    {
        foreach (var item in result.Leaderboard)
        {
            GameObject newGo = Instantiate(rowPrefab, rowsParent);
            Text[] texts = newGo.GetComponentsInChildren<Text>();
            texts[0].text = " ";
            texts[1].text = item.DisplayName;
            float score = (float)item.StatValue;
            score = score / 100;
            texts[2].text = score.ToString("0.00");
        }
    }
    void OnTeam3LeaderboardGet(GetLeaderboardResult result)
    {
        foreach (var item in result.Leaderboard)
        {
            GameObject newGo = Instantiate(rowPrefab, rowsParent);
            Text[] texts = newGo.GetComponentsInChildren<Text>();
            texts[0].text = " ";
            texts[1].text = item.DisplayName;
            float score = (float)item.StatValue;
            score = score / 100;
            texts[2].text = score.ToString("0.00");
        }
    }
    void OnTeam4LeaderboardGet(GetLeaderboardResult result)
    {
        foreach (var item in result.Leaderboard)
        {
            GameObject newGo = Instantiate(rowPrefab, rowsParent);
            Text[] texts = newGo.GetComponentsInChildren<Text>();
            texts[0].text = " ";
            texts[1].text = item.DisplayName;
            float score = (float)item.StatValue;
            score = score / 100;
            texts[2].text = score.ToString("0.00");
        }
    }
    void OnTeam5LeaderboardGet(GetLeaderboardResult result)
    {
        foreach (var item in result.Leaderboard)
        {
            GameObject newGo = Instantiate(rowPrefab, rowsParent);
            Text[] texts = newGo.GetComponentsInChildren<Text>();
            texts[0].text = " ";
            texts[1].text = item.DisplayName;
            float score = (float)item.StatValue;
            score = score / 100;
            texts[2].text = score.ToString("0.00");
        }
    }

    //Paratoother Leaderboard
    void OnLeaderboardGet(GetLeaderboardResult result)
    {
        foreach (var item in result.Leaderboard)
        {
            GameObject newGo = Instantiate(rowPrefab, rowsParent);
            Text[] texts = newGo.GetComponentsInChildren<Text>();
            texts[0].text = (item.Position + 1).ToString();
            texts[1].text = item.DisplayName;
            texts[2].text = item.StatValue.ToString();

            //Debug.Log(item.Position + " " + item.PlayFabId + " item.StatValue");
        }
    }
    void OnHeroGalaxyLeaderboardGet(GetLeaderboardResult result)
    {
        foreach (var item in result.Leaderboard)
        {
            GameObject newGo = Instantiate(rowPrefab, rowsParent);
            Text[] texts = newGo.GetComponentsInChildren<Text>();
            texts[0].text = (item.Position + 1).ToString();
            texts[1].text = item.DisplayName;
            texts[2].text = item.StatValue.ToString();
        }
    }
    void OnApeGangLeaderboardGet(GetLeaderboardResult result)
    {
        foreach (var item in result.Leaderboard)
        {
            GameObject newGo = Instantiate(rowPrefab, rowsParent);
            Text[] texts = newGo.GetComponentsInChildren<Text>();
            texts[0].text = (item.Position + 1).ToString();
            texts[1].text = item.DisplayName;
            texts[2].text = item.StatValue.ToString();
        }
    }
    void OnBrawlerBearsLeaderboardGet(GetLeaderboardResult result)
    {
        foreach (var item in result.Leaderboard)
        {
            GameObject newGo = Instantiate(rowPrefab, rowsParent);
            Text[] texts = newGo.GetComponentsInChildren<Text>();
            texts[0].text = (item.Position + 1).ToString();
            texts[1].text = item.DisplayName;
            texts[2].text = item.StatValue.ToString();
        }
    }
    void OnCryptoDadsLeaderboardGet(GetLeaderboardResult result)
    {
        foreach (var item in result.Leaderboard)
        {
            GameObject newGo = Instantiate(rowPrefab, rowsParent);
            Text[] texts = newGo.GetComponentsInChildren<Text>();
            texts[0].text = (item.Position + 1).ToString();
            texts[1].text = item.DisplayName;
            texts[2].text = item.StatValue.ToString();
        }
    }
    void OnGamingApeClubLeaderboardGet(GetLeaderboardResult result)
    {
        foreach (var item in result.Leaderboard)
        {
            GameObject newGo = Instantiate(rowPrefab, rowsParent);
            Text[] texts = newGo.GetComponentsInChildren<Text>();
            texts[0].text = (item.Position + 1).ToString();
            texts[1].text = item.DisplayName;
            texts[2].text = item.StatValue.ToString();
        }
    }
    void OnHikeshiLeaderboardGet(GetLeaderboardResult result)
    {
        foreach (var item in result.Leaderboard)
        {
            GameObject newGo = Instantiate(rowPrefab, rowsParent);
            Text[] texts = newGo.GetComponentsInChildren<Text>();
            texts[0].text = (item.Position + 1).ToString();
            texts[1].text = item.DisplayName;
            texts[2].text = item.StatValue.ToString();
        }
    }
    void OnSpaceRidersLeaderboardGet(GetLeaderboardResult result)
    {
        foreach (var item in result.Leaderboard)
        {
            GameObject newGo = Instantiate(rowPrefab, rowsParent);
            Text[] texts = newGo.GetComponentsInChildren<Text>();
            texts[0].text = (item.Position + 1).ToString();
            texts[1].text = item.DisplayName;
            texts[2].text = item.StatValue.ToString();
        }
    }
    void OnTacoTribeLeaderboardGet(GetLeaderboardResult result)
    {
        foreach (var item in result.Leaderboard)
        {
            GameObject newGo = Instantiate(rowPrefab, rowsParent);
            Text[] texts = newGo.GetComponentsInChildren<Text>();
            texts[0].text = (item.Position + 1).ToString();
            texts[1].text = item.DisplayName;
            texts[2].text = item.StatValue.ToString();
        }
    }
    void OnThePlagueLeaderboardGet(GetLeaderboardResult result)
    {
        foreach (var item in result.Leaderboard)
        {
            GameObject newGo = Instantiate(rowPrefab, rowsParent);
            Text[] texts = newGo.GetComponentsInChildren<Text>();
            texts[0].text = (item.Position + 1).ToString();
            texts[1].text = item.DisplayName;
            texts[2].text = item.StatValue.ToString();
        }
    }


    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenu);
        //SceneManager.LoadScene(houseMenu);
    }

    public void DeleteAccount()
    {
        deleteAccountWindow.SetActive(true);
        loginWindow.SetActive(false);
    }

    public void Cancel()
    {
        messageText.text = "";
        deleteAccountMessageText.text = "";
        deleteAccountWindow.SetActive(false);
        loginWindow.SetActive(true);
    }

    public void LoginScreen()
    {
        openScreenWindow.SetActive(false);
        loginWindow.SetActive(true);
    }

    public void SendEmail()
    {
        MailMessage mail = new MailMessage();
        SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
        SmtpServer.Timeout = 10000;
        SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
        SmtpServer.UseDefaultCredentials = false;
        SmtpServer.Port = 587;

        mail.From = new MailAddress("NFTeeth.game@gmail.com");
        mail.To.Add(new MailAddress(recipientEmail.text));

        mail.Subject = "Paratoother Account Deletion Request";
        mail.Body = "Reply 'YES' to confirm deleting your Paratoother account";

        SmtpServer.Credentials = new System.Net.NetworkCredential("NFTeeth.game@gmail.com", "awzm kcat ldgg hlis") as ICredentialsByHost; SmtpServer.EnableSsl = true;
        ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        };

        mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
        SmtpServer.Send(mail);
    }

    //Message of the day
    public void GetTitleData()
    {
        PlayFabClientAPI.GetTitleData(new GetTitleDataRequest(), OnTitleDataReceived, OnError);
    }

    void OnTitleDataReceived(GetTitleDataResult result)
    {
        if (result.Data == null || result.Data.ContainsKey("Message") == false)
        {
            Debug.Log("No message!");
            Settings.achievementsEnabled = false;
            return;
        }
        if(messageOfTheDayText != null)
        {
            messageOfTheDayText.text = result.Data["Message"];
            Settings.achievementsEnabled = true;
        }
    }

    public void SaveLevelMaster()
    {
        var request = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>
            {
                {"levelMaster", Settings.levelMasterAchievement}
            }
        };
        PlayFabClientAPI.UpdateUserData(request, OnDataSend, OnError);
    }
    public void SaveReckscollieAward()
    {
        var request = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>
            {

                {"reckscollieAward", Settings.reckscollieAwardAchievement}
            }
        };
        PlayFabClientAPI.UpdateUserData(request, OnDataSend, OnError);
    }

    public void SaveTotalPoints()
    {
        var request = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>
            {

                {"totalPoints", Settings.totalPoints.ToString()}
            }
        };
        PlayFabClientAPI.UpdateUserData(request, OnDataSend, OnError);
    }

    public void SaveWinnerWinner()
    {
        var request = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>
            {
                {"winnerWinner", Settings.winnerWinnerAchievement}
            }
        };
        PlayFabClientAPI.UpdateUserData(request, OnDataSend, OnError);
    }

    public void SaveJackpot()
    {
        var request = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>
            {
                {"jackpot", Settings.jackpotAchievement}
            }
        };
        PlayFabClientAPI.UpdateUserData(request, OnDataSend, OnError);
    }

    public void SaveAlternateSpace()
    {
        var request = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>
            {
                {"alternateSpace", Settings.alternateSpaceAchievement}
            }
        };
        PlayFabClientAPI.UpdateUserData(request, OnDataSend, OnError);
    }

    public void SaveSamuria()
    {
        var request = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>
            {
                {"samuria", Settings.samuriaSent}
            }
        };
        PlayFabClientAPI.UpdateUserData(request, OnDataSend, OnError);
    }
    
    public void SaveTurtle()
    {
        var request = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>
            {
                {"turtle", Settings.turtleSent}
            }
        };
        PlayFabClientAPI.UpdateUserData(request, OnDataSend, OnError);
    }

    public void SaveRocketDodger1()
    {
        var request = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>
            {
                {"rocketDodger1", Settings.rocketDodgerAchievement1}
            }
        };
        PlayFabClientAPI.UpdateUserData(request, OnDataSend, OnError);
    }

    public void SaveRocketDodger2()
    {
        var request = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>
            {
                {"rocketDodger2", Settings.rocketDodgerAchievement2}
            }
        };
        PlayFabClientAPI.UpdateUserData(request, OnDataSend, OnError);
    }

    public void SaveRocketDodger3()
    {
        var request = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>
            {
                {"rocketDodger3", Settings.rocketDodgerAchievement3}
            }
        };
        PlayFabClientAPI.UpdateUserData(request, OnDataSend, OnError);
    }


    public void SaveCoins()
    {
        var request = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>
            {
                {"coinCount1", Settings.coinCountAchievement1},
                {"coinCount2", Settings.coinCountAchievement2},
                {"coinCount3", Settings.coinCountAchievement3},
                {"coinCount", Settings.coinCount.ToString()}
            }
        };
        PlayFabClientAPI.UpdateUserData(request, OnDataSend, OnError);
    }

    public void SaveParachute()
    {
        var request = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>
            {
                {"parachuteCount1", Settings.parachuteCountAchievement1},
                {"parachuteCount2", Settings.parachuteCountAchievement2},
                {"parachuteCount3", Settings.parachuteCountAchievement3},
                {"parachuteCount", Settings.parachuteCount.ToString()}
            }
        };
        PlayFabClientAPI.UpdateUserData(request, OnDataSend, OnError);
    }

    void OnDataSend(UpdateUserDataResult result)
    {
        Debug.Log("Successful user data sent!");
    }

    public void onSetUserDataValue(string key, string value)
    {
        SetUserDataValue(key, value);
    }

    public void SetUserDataValue(string key, string value)
    {
        PlayFabClientAPI.UpdateUserData(new UpdateUserDataRequest()
        {
            Data = new Dictionary<string, string>() {
                {"cryptoWallet", cryptoWallet},
            }
        },


    result => Debug.Log("Successfully updated user data"),
    error => {
        Debug.Log("Got error setting user data wallet");
        Debug.Log(error.GenerateErrorReport());
    });
    }

    public void GetUserData()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest()
        {
            PlayFabId = loggedInPlayfabId,
            Keys = null
        }, result =>
        {
            Debug.Log("Got user data:");
            if (result.Data == null)
            {
                return;
            }
            if (result.Data.ContainsKey("cryptoWallet"))
            {
                cryptoWallet = result.Data["cryptoWallet"].Value;
                crypto.text = result.Data["cryptoWallet"].Value;
            }
            if (result.Data.ContainsKey("among"))
            {
                Settings.amongSelect = true;
            }
            else
            {
                Settings.among = false;
            }
        },
        error =>
        {
            Debug.Log("Not receiving data \n " + error.GenerateErrorReport());
        });
    }
}

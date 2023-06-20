using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RaceTeamLeaderboard : MonoBehaviour
{
    public Text team1Time;
    public Text team2Time;
    public Text team3Time;
    public Text team4Time;
    public Text team5Time;

    void Update()
    {
        team1Time.text = PlayfabManager.team1AverageNumber.ToString();
        team2Time.text = PlayfabManager.team2AverageNumber.ToString();
        team3Time.text = PlayfabManager.team3AverageNumber.ToString();
        team4Time.text = PlayfabManager.team4AverageNumber.ToString();
        team5Time.text = PlayfabManager.team5AverageNumber.ToString();
    }
}

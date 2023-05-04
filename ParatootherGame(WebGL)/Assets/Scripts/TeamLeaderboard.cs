using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TeamLeaderboard : MonoBehaviour
{
    //public Text chompiesScore;
    //public Text chompies2Score;
    public Text apeGangScore;
    public Text brawlerBearsScore;
    public Text cryptoDadsScore;
    public Text gamingApeClubScore;
    //public Text hikeshiScore;
    public Text spaceRidersScore;
    public Text tacoTribeScore;
    public Text thePlagueScore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //chompiesScore.text = PlayfabManager.chompiesAverageNumber.ToString();
        //chompies2Score.text = PlayfabManager.chompies2AverageNumber.ToString();
        apeGangScore.text = PlayfabManager.apeGangAverageNumber.ToString();
        brawlerBearsScore.text = PlayfabManager.brawlerBearsAverageNumber.ToString();
        cryptoDadsScore.text = PlayfabManager.cryptoDadsAverageNumber.ToString();
        gamingApeClubScore.text = PlayfabManager.gamingApeClubAverageNumber.ToString();
        //hikeshiScore.text = PlayfabManager.hikeshiAverageNumber.ToString();
        spaceRidersScore.text = PlayfabManager.spaceRidersAverageNumber.ToString();
        tacoTribeScore.text = PlayfabManager.tacoTribeAverageNumber.ToString();
        thePlagueScore.text = PlayfabManager.thePlagueAverageNumber.ToString();
    }
}

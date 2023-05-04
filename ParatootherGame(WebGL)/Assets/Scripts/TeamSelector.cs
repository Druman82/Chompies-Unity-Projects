using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TeamSelector : MonoBehaviour
{
    public void HandleInputData(int val)
    {
        if (val == 0)
        {
            Settings.apeGang = false;
            Settings.brawlerBears = false;
            Settings.cryptoDads = false;
            Settings.gamingApeClub = false;
            Settings.spaceRiders = false;
            Settings.tacoTribe = false;
            Settings.thePlague = false;
        }
        if (val == 1)
        {
            Settings.apeGang = true;
            Settings.brawlerBears = false;
            Settings.cryptoDads = false;
            Settings.gamingApeClub = false;
            Settings.spaceRiders = false;
            Settings.tacoTribe = false;
            Settings.thePlague = false;
        }
        if (val == 2)
        {
            Settings.apeGang = false;
            Settings.brawlerBears = true;
            Settings.cryptoDads = false;
            Settings.gamingApeClub = false;
            Settings.spaceRiders = false;
            Settings.tacoTribe = false;
            Settings.thePlague = false;
        }
        if (val == 3)
        {
            Settings.apeGang = false;
            Settings.brawlerBears = false;
            Settings.cryptoDads = true;
            Settings.gamingApeClub = false;
            Settings.spaceRiders = false;
            Settings.tacoTribe = false;
            Settings.thePlague = false;
        }
        if (val == 4)
        {
            Settings.apeGang = false;
            Settings.brawlerBears = false;
            Settings.cryptoDads = false;
            Settings.gamingApeClub = true;
            Settings.spaceRiders = false;
            Settings.tacoTribe = false;
            Settings.thePlague = false;
        }
        if (val == 5)
        {
            Settings.apeGang = false;
            Settings.brawlerBears = false;
            Settings.cryptoDads = false;
            Settings.gamingApeClub = false;
            Settings.spaceRiders = true;
            Settings.tacoTribe = false;
            Settings.thePlague = false;
        }
        if (val == 6)
        {
            Settings.apeGang = false;
            Settings.brawlerBears = false;
            Settings.cryptoDads = false;
            Settings.gamingApeClub = false;
            Settings.spaceRiders = false;
            Settings.tacoTribe = true;
            Settings.thePlague = false;
        }
        if (val == 7)
        {
            Settings.apeGang = false;
            Settings.brawlerBears = false;
            Settings.cryptoDads = false;
            Settings.gamingApeClub = false;
            Settings.spaceRiders = false;
            Settings.tacoTribe = false;
            Settings.thePlague = true;
        }
    }

}

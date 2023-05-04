using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
    public int scoreCount;
    public int rocketCount;
    public int ninjaStarCount;
    public int batteryCount;
    public int pillowCount;
    public bool scoreIncreasing;


    public void AddSlotScore(int slotScoreToAdd)
    {
        Settings.points += slotScoreToAdd;
        Settings.totalPoints += slotScoreToAdd;
    }

    public void AddRocket(int rocketsToAdd)
    {
        if(Settings.rocketCount < 5)
        {
            Settings.rocketCount += rocketsToAdd;
        }
    }

    public void AddBattery(int batteriesToAdd)
    {
        if (Settings.batteryCount < 5)
        {
            Settings.batteryCount += batteriesToAdd;
        }
    }

    public void AddNinjaStar(int ninjaStarsToAdd)
    {
        if(Settings.ninjaStarCount < 5)
        {
            Settings.ninjaStarCount += ninjaStarsToAdd;
        }
    }

    public void AddPillow(int pillowsToAdd)
    {
        if (Settings.pillowCount < 5)
        {
            Settings.pillowCount += pillowsToAdd;
        }
    }

    public void AddScore(int pointsToAdd)
    {
        Settings.points += pointsToAdd;
        Settings.totalPoints += pointsToAdd;

    }
}

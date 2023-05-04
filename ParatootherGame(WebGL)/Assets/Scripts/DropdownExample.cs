using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownExample : MonoBehaviour
{
    public void DropdownSample(int index)
    {
        switch (index)
        {
            case 0: Settings.difficulty = 1;
            Settings.easy = true;
            Settings.recks = false; break;
            case 1: Settings.difficulty = 2;
            Settings.easy = false;
            Settings.recks = false; break;
            case 2: Settings.difficulty = 3;
            Settings.recks = true;
            Settings.easy = false; break;
        }
    }
}

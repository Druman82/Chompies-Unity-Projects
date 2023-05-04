using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoConnection : MonoBehaviour
{
    [SerializeField] public Transform openScreen;
    [SerializeField] public Transform usernameScreen;
    [SerializeField] public Transform chooseTeamScreen;

    public void BackToOpenScreen()
    {
        openScreen.gameObject.SetActive(true);
        usernameScreen.gameObject.SetActive(false);
        chooseTeamScreen.gameObject.SetActive(false);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomNum : MonoBehaviour
{
    char[] numbersRand = { '0', '1', '1', '0', '1', '1', '0', '1', '1', '0', '1', '1', '0', '1', '0',
    '2', '2', '0', '2', '2', '0', '2', '2', '0', '2', '2', '0',
    '3', '3', '0', '3', '3', '0', '3', '3', '0', '3', '0',
    '4', '4', '0', '4', '4', '0', '4', '4', '0',
    '5', '5', '0', '5', '5', '0', '5', '0',
    '6', '6', '0', '6', '6', '0',
    '7', '7', '0', '7', '0',
    '8', '8', '0',
    '9', '0' };
    public Text slotNum;
    public float time;
    private bool space;
    public GameManager theGameManager;
    public int num;
    [SerializeField] public Transform startButton;

    void Update()
    {
        Cursor.visible = true;
        startButton.gameObject.SetActive(true);
        slotNum.text = numbersRand[Random.Range(0, numbersRand.Length)].ToString();
    }
    
    public void OffEnable()
    {
        Invoke("DelayNum", time);
    }

    public void OnEnable()
    {
        if(Settings.tokenNum >= 1)
        {
            num += 1;
            enabled = true;
            StartCoroutine("Stop");
        }
    }

    void DelayNum()
    {
        enabled = false;
        if (num >= 2)
        {
            Settings.tokenNum -= 1;
            num = 0;
            if(Settings.tokenNum <= 0)
            {
                startButton.gameObject.SetActive(false);
                StartCoroutine("End");
            }
        }
    }

    private IEnumerator Stop()
    {
        yield return new WaitForSeconds(0.1f);

        OffEnable();
    }

    private IEnumerator End()
    {
        yield return new WaitForSeconds(4.0f);
        theGameManager.RestartGame();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

public class CharacterSelector : MonoBehaviour
{
    public static string samuriaGet;
    public static string turtleGet;
    public GameObject noneText;
    public GameObject noneTextDeselected;
    public GameObject none;
    public GameObject noneDeselected;
    public GameObject tacoText;
    public GameObject tacoTextDeselected;
    public GameObject taco;
    public GameObject tacoDeselected;
    public GameObject plagueText;
    public GameObject plagueTextDeselected;
    public GameObject plague;
    public GameObject plagueDeselected;
    public GameObject turtleText;
    public GameObject turtleTextDeselected;
    public GameObject turtle;
    public GameObject turtleDeselected;
    public GameObject turtleNotActivated;
    public GameObject turtleButton;
    public GameObject bearText;
    public GameObject bearTextDeselected;
    public GameObject bear;
    public GameObject bearDeselected;
    public GameObject gacText;
    public GameObject gacTextDeselected;
    public GameObject gac;
    public GameObject gacDeselected;
    public GameObject dadText;
    public GameObject dadTextDeselected;
    public GameObject dad;
    public GameObject dadDeselected;
    public GameObject amongText;
    public GameObject amongTextDeselected;
    public GameObject among;
    public GameObject amongDeselected;
    public GameObject samuriaText;
    public GameObject samuriaTextDeselected;
    public GameObject samuria;
    public GameObject samuriaDeselected;
    public GameObject samuriaNotActivated;
    public GameObject samuriaButton;
    [SerializeField] public Transform content;

    public void Start()
    {
        GetCharacters();
        if (Settings.none == true)
        {
            content.transform.position = new Vector3(800, 3.1f, transform.position.z);
        }
        else if (Settings.taco == true)
        {
            content.transform.position = new Vector3(800,3.1f, transform.position.z);
        }
        else if (Settings.recksFrog == true)
        {
            content.transform.position = new Vector3(-2800,3.1f, transform.position.z);
        }
        else if (Settings.turtle == true)
        {
            content.transform.position = new Vector3(800, 3.1f, transform.position.z);
        }
        else if (Settings.bear == true)
        {
            content.transform.position = new Vector3(600, 3.1f, transform.position.z);
        }
        else if (Settings.gac == true)
        {
            content.transform.position = new Vector3(800, 3.1f, transform.position.z);
        }
        else if (Settings.dad == true)
        {
            content.transform.position = new Vector3(800, 3.1f, transform.position.z);
        }
        else if (Settings.among == true)
        {
            content.transform.position = new Vector3(-1800, 3.1f, transform.position.z);
        }
        else if (Settings.samuria == true)
        {
            content.transform.position = new Vector3(800, 3.1f, transform.position.z);
        }
    }
    public void Update()
    {
        if (samuriaGet == "samuria")
        {
            Settings.samuriaActivated = true;
        }
        else
        {
            Settings.samuriaActivated = false;
        }
        
        if (turtleGet == "turtle")
        {
            Settings.turtleActivated = true;
        }
        else
        {
            Settings.turtleActivated = false;
        }

        if (Settings.samuriaActivated == false)
        {
            samuriaNotActivated.gameObject.SetActive(true);
            samuriaButton.gameObject.SetActive(false);
            samuriaDeselected.SetActive(false);
        }
        else if (Settings.samuriaActivated == true)
        {
            samuriaNotActivated.gameObject.SetActive(false);
            samuriaButton.gameObject.SetActive(true);
        }
        
        if (Settings.turtleActivated == false)
        {
            turtleNotActivated.gameObject.SetActive(true);
            turtleButton.gameObject.SetActive(false);
            turtleDeselected.SetActive(false);
        }
        else if (Settings.turtleActivated == true)
        {
            turtleNotActivated.gameObject.SetActive(false);
            turtleButton.gameObject.SetActive(true);
        }

        if (Settings.none == true)
        {
            taco.SetActive(false);
            tacoDeselected.SetActive(true);
            tacoText.SetActive(false);
            tacoTextDeselected.SetActive(true);
            plague.SetActive(false);
            plagueDeselected.SetActive(true);
            plagueText.SetActive(false);
            plagueTextDeselected.SetActive(true);
            bear.SetActive(false);
            bearDeselected.SetActive(true);
            bearText.SetActive(false);
            bearTextDeselected.SetActive(true);
            gac.SetActive(false);
            gacDeselected.SetActive(true);
            gacText.SetActive(false);
            gacTextDeselected.SetActive(true);
            dad.SetActive(false);
            dadDeselected.SetActive(true);
            dadText.SetActive(false);
            dadTextDeselected.SetActive(true);
            if (Settings.turtleActivated == true)
            {
                turtleDeselected.SetActive(true);
                turtle.SetActive(false);
                turtleTextDeselected.SetActive(true);
                turtleText.SetActive(false);
            }
            among.SetActive(false);
            amongDeselected.SetActive(true);
            amongText.SetActive(false);
            amongTextDeselected.SetActive(true);
            if (Settings.samuriaActivated == true)
            {
                samuriaDeselected.SetActive(true);
                samuria.SetActive(false);
                samuriaTextDeselected.SetActive(true);
                samuriaText.SetActive(false);
            }
            noneText.SetActive(true);
            noneTextDeselected.SetActive(false);
            none.SetActive(true);
            noneDeselected.SetActive(false);
        }

        else if (Settings.taco == true)
        {
            taco.SetActive(true);
            tacoDeselected.SetActive(false);
            tacoText.SetActive(true);
            tacoTextDeselected.SetActive(false);
            plague.SetActive(false);
            plagueDeselected.SetActive(true);
            plagueText.SetActive(false);
            plagueTextDeselected.SetActive(true);
            bear.SetActive(false);
            bearDeselected.SetActive(true);
            bearText.SetActive(false);
            bearTextDeselected.SetActive(true);
            gac.SetActive(false);
            gacDeselected.SetActive(true);
            gacText.SetActive(false);
            gacTextDeselected.SetActive(true);
            dad.SetActive(false);
            dadDeselected.SetActive(true);
            dadText.SetActive(false);
            dadTextDeselected.SetActive(true);
            if (Settings.turtleActivated == true)
            {
                turtleDeselected.SetActive(true);
                turtle.SetActive(false);
                turtleTextDeselected.SetActive(true);
                turtleText.SetActive(false);
            }
            among.SetActive(false);
            amongDeselected.SetActive(true);
            amongText.SetActive(false);
            amongTextDeselected.SetActive(true);
            if (Settings.samuriaActivated == true)
            {
                samuriaDeselected.SetActive(true);
                samuria.SetActive(false);
                samuriaTextDeselected.SetActive(true);
                samuriaText.SetActive(false);
            }
            none.SetActive(false);
            noneDeselected.SetActive(true);
            noneText.SetActive(false);
            noneTextDeselected.SetActive(true);
        }
        
        else if (Settings.recksFrog == true)
        {
            taco.SetActive(false);
            tacoDeselected.SetActive(true);
            tacoText.SetActive(false);
            tacoTextDeselected.SetActive(true);
            plague.SetActive(true);
            plagueDeselected.SetActive(false);
            plagueText.SetActive(true);
            plagueTextDeselected.SetActive(false);
            bear.SetActive(false);
            bearDeselected.SetActive(true);
            bearText.SetActive(false);
            bearTextDeselected.SetActive(true);
            gac.SetActive(false);
            gacDeselected.SetActive(true);
            gacText.SetActive(false);
            gacTextDeselected.SetActive(true);
            dad.SetActive(false);
            dadDeselected.SetActive(true);
            dadText.SetActive(false);
            dadTextDeselected.SetActive(true);
            if (Settings.turtleActivated == true)
            {
                turtleDeselected.SetActive(true);
                turtle.SetActive(false);
                turtleTextDeselected.SetActive(true);
                turtleText.SetActive(false);
            }
            among.SetActive(false);
            amongDeselected.SetActive(true);
            amongText.SetActive(false);
            amongTextDeselected.SetActive(true);
            if (Settings.samuriaActivated == true)
            {
                samuriaDeselected.SetActive(true);
                samuria.SetActive(false);
                samuriaTextDeselected.SetActive(true);
                samuriaText.SetActive(false);
            }
            none.SetActive(false);
            noneDeselected.SetActive(true);
            noneText.SetActive(false);
            noneTextDeselected.SetActive(true);
        }

        else if (Settings.turtle == true)
        {
            plague.SetActive(false);
            plagueDeselected.SetActive(true);
            plagueText.SetActive(false);
            plagueTextDeselected.SetActive(true);
            turtle.SetActive(true);
            turtleDeselected.SetActive(false);
            turtleText.SetActive(true);
            turtleTextDeselected.SetActive(false);
            bear.SetActive(false);
            bearDeselected.SetActive(true);
            bearText.SetActive(false);
            bearTextDeselected.SetActive(true);
            gac.SetActive(false);
            gacDeselected.SetActive(true);
            gacText.SetActive(false);
            gacTextDeselected.SetActive(true);
            dad.SetActive(false);
            dadDeselected.SetActive(true);
            dadText.SetActive(false);
            dadTextDeselected.SetActive(true);
            among.SetActive(false);
            amongDeselected.SetActive(true);
            amongText.SetActive(false);
            amongTextDeselected.SetActive(true);
            if (Settings.samuriaActivated == true)
            {
                samuriaDeselected.SetActive(true);
                samuria.SetActive(false);
                samuriaTextDeselected.SetActive(true);
                samuriaText.SetActive(false);
            }
            none.SetActive(false);
            noneDeselected.SetActive(true);
            noneText.SetActive(false);
            noneTextDeselected.SetActive(true);
        }

        else if (Settings.bear == true)
        {
            plague.SetActive(false);
            plagueDeselected.SetActive(true);
            plagueText.SetActive(false);
            plagueTextDeselected.SetActive(true);
            bear.SetActive(true);
            bearDeselected.SetActive(false);
            bearText.SetActive(true);
            bearTextDeselected.SetActive(false);
            gac.SetActive(false);
            gacDeselected.SetActive(true);
            gacText.SetActive(false);
            gacTextDeselected.SetActive(true);
            dad.SetActive(false);
            dadDeselected.SetActive(true);
            dadText.SetActive(false);
            dadTextDeselected.SetActive(true);
            if (Settings.turtleActivated == true)
            {
                turtleDeselected.SetActive(true);
                turtle.SetActive(false);
                turtleTextDeselected.SetActive(true);
                turtleText.SetActive(false);
            }
            taco.SetActive(false);
            tacoDeselected.SetActive(true);
            tacoText.SetActive(false);
            tacoTextDeselected.SetActive(true);
            among.SetActive(false);
            amongDeselected.SetActive(true);
            amongText.SetActive(false);
            amongTextDeselected.SetActive(true);
            if (Settings.samuriaActivated == true)
            {
                samuriaDeselected.SetActive(true);
                samuria.SetActive(false);
                samuriaTextDeselected.SetActive(true);
                samuriaText.SetActive(false);
            }
            none.SetActive(false);
            noneDeselected.SetActive(true);
            noneText.SetActive(false);
            noneTextDeselected.SetActive(true);
        }

        else if (Settings.gac == true)
        {
            plague.SetActive(false);
            plagueDeselected.SetActive(true);
            plagueText.SetActive(false);
            plagueTextDeselected.SetActive(true);
            bear.SetActive(false);
            bearDeselected.SetActive(true);
            bearText.SetActive(false);
            bearTextDeselected.SetActive(true);
            gac.SetActive(true);
            gacDeselected.SetActive(false);
            gacText.SetActive(true);
            gacTextDeselected.SetActive(false);
            dad.SetActive(false);
            dadDeselected.SetActive(true);
            dadText.SetActive(false);
            dadTextDeselected.SetActive(true);
            if (Settings.turtleActivated == true)
            {
                turtleDeselected.SetActive(true);
                turtle.SetActive(false);
                turtleTextDeselected.SetActive(true);
                turtleText.SetActive(false);
            }
            taco.SetActive(false);
            tacoDeselected.SetActive(true);
            tacoText.SetActive(false);
            tacoTextDeselected.SetActive(true);
            among.SetActive(false);
            amongDeselected.SetActive(true);
            amongText.SetActive(false);
            amongTextDeselected.SetActive(true);
            if (Settings.samuriaActivated == true)
            {
                samuriaDeselected.SetActive(true);
                samuria.SetActive(false);
                samuriaTextDeselected.SetActive(true);
                samuriaText.SetActive(false);
            }
            none.SetActive(false);
            noneDeselected.SetActive(true);
            noneText.SetActive(false);
            noneTextDeselected.SetActive(true);
        }
        
        else if (Settings.dad == true)
        {
            plague.SetActive(false);
            plagueDeselected.SetActive(true);
            plagueText.SetActive(false);
            plagueTextDeselected.SetActive(true);
            bear.SetActive(false);
            bearDeselected.SetActive(true);
            bearText.SetActive(false);
            bearTextDeselected.SetActive(true);
            gac.SetActive(false);
            gacDeselected.SetActive(true);
            gacText.SetActive(false);
            gacTextDeselected.SetActive(true);
            dad.SetActive(true);
            dadDeselected.SetActive(false);
            dadText.SetActive(true);
            dadTextDeselected.SetActive(false);
            if (Settings.turtleActivated == true)
            {
                turtleDeselected.SetActive(true);
                turtle.SetActive(false);
                turtleTextDeselected.SetActive(true);
                turtleText.SetActive(false);
            }
            taco.SetActive(false);
            tacoDeselected.SetActive(true);
            tacoText.SetActive(false);
            tacoTextDeselected.SetActive(true);
            among.SetActive(false);
            amongDeselected.SetActive(true);
            amongText.SetActive(false);
            amongTextDeselected.SetActive(true);
            if (Settings.samuriaActivated == true)
            {
                samuriaDeselected.SetActive(true);
                samuria.SetActive(false);
                samuriaTextDeselected.SetActive(true);
                samuriaText.SetActive(false);
            }
            none.SetActive(false);
            noneDeselected.SetActive(true);
            noneText.SetActive(false);
            noneTextDeselected.SetActive(true);
        }

        else if (Settings.among == true)
        {
            plague.SetActive(false);
            plagueDeselected.SetActive(true);
            plagueText.SetActive(false);
            plagueTextDeselected.SetActive(true);
            bear.SetActive(false);
            bearDeselected.SetActive(true);
            bearText.SetActive(false);
            bearTextDeselected.SetActive(true);
            gac.SetActive(false);
            gacDeselected.SetActive(true);
            gacText.SetActive(false);
            gacTextDeselected.SetActive(true);
            dad.SetActive(false);
            dadDeselected.SetActive(true);
            dadText.SetActive(false);
            dadTextDeselected.SetActive(true);
            if (Settings.turtleActivated == true)
            {
                turtleDeselected.SetActive(true);
                turtle.SetActive(false);
                turtleTextDeselected.SetActive(true);
                turtleText.SetActive(false);
            }
            taco.SetActive(false);
            tacoDeselected.SetActive(true);
            tacoText.SetActive(false);
            tacoTextDeselected.SetActive(true);
            among.SetActive(true);
            amongDeselected.SetActive(false);
            amongText.SetActive(true);
            amongTextDeselected.SetActive(false);
            if (Settings.samuriaActivated == true)
            {
                samuriaDeselected.SetActive(true);
                samuria.SetActive(false);
                samuriaTextDeselected.SetActive(true);
                samuriaText.SetActive(false);
            }
            none.SetActive(false);
            noneDeselected.SetActive(true);
            noneText.SetActive(false);
            noneTextDeselected.SetActive(true);
        }
        
        else if (Settings.samuria == true)
        {
            plague.SetActive(false);
            plagueDeselected.SetActive(true);
            plagueText.SetActive(false);
            plagueTextDeselected.SetActive(true);
            bear.SetActive(false);
            bearDeselected.SetActive(true);
            bearText.SetActive(false);
            bearTextDeselected.SetActive(true);
            gac.SetActive(false);
            gacDeselected.SetActive(true);
            gacText.SetActive(false);
            gacTextDeselected.SetActive(true);
            dad.SetActive(false);
            dadDeselected.SetActive(true);
            dadText.SetActive(false);
            dadTextDeselected.SetActive(true);
            if (Settings.turtleActivated == true)
            {
                turtleDeselected.SetActive(true);
                turtle.SetActive(false);
                turtleTextDeselected.SetActive(true);
                turtleText.SetActive(false);
            }
            taco.SetActive(false);
            tacoDeselected.SetActive(true);
            tacoText.SetActive(false);
            tacoTextDeselected.SetActive(true);
            among.SetActive(false);
            amongDeselected.SetActive(true);
            amongText.SetActive(false);
            amongTextDeselected.SetActive(true);
            samuriaDeselected.SetActive(false);
            samuria.SetActive(true);
            samuriaTextDeselected.SetActive(false);
            samuriaText.SetActive(true);
            none.SetActive(false);
            noneDeselected.SetActive(true);
            noneText.SetActive(false);
            noneTextDeselected.SetActive(true);
        }
    }

    public void None()
    {
        Settings.none = true;
        Settings.taco = false;
        Settings.recksFrog = false;
        Settings.bear = false;
        Settings.turtle = false;
        Settings.gac = false;
        Settings.dad = false;
        Settings.among = false;
        Settings.samuria = false;
        Settings.target = 1;
    }

    public void Taco()
    {
        Settings.none = false;
        Settings.taco = true;
        Settings.recksFrog = false;
        Settings.bear = false;
        Settings.turtle = false;
        Settings.gac = false;
        Settings.dad = false;
        Settings.among = false;
        Settings.samuria = false;
        Settings.target = 7;
    }

    public void Plague()
    {
        Settings.none = false;
        Settings.taco = false;
        Settings.recksFrog = true;
        Settings.bear = false;
        Settings.turtle = false;
        Settings.gac = false;
        Settings.dad = false;
        Settings.among = false;
        Settings.samuria = false;
        Settings.target = 6;
    }

    public void Turtle()
    {
        Settings.none = false;
        Settings.taco = false;
        Settings.recksFrog = false;
        Settings.bear = false;
        Settings.turtle = true;
        Settings.gac = false;
        Settings.dad = false;
        Settings.among = false;
        Settings.samuria = false;
        Settings.target = 1;
    }

    public void Bear()
    {
        Settings.none = false;
        Settings.taco = false;
        Settings.recksFrog = false;
        Settings.bear = true;
        Settings.turtle = false;
        Settings.gac = false;
        Settings.dad = false;
        Settings.among = false; 
        Settings.samuria = false;
        Settings.target = 3;
    }

    public void GAC()
    {
        Settings.none = false;
        Settings.taco = false;
        Settings.recksFrog = false;
        Settings.bear = false;
        Settings.turtle = false;
        Settings.gac = true;
        Settings.dad = false;
        Settings.among = false; 
        Settings.samuria = false;
        Settings.target = 4;
    }

    public void Dad()
    {
        Settings.none = false;
        Settings.taco = false;
        Settings.recksFrog = false;
        Settings.bear = false;
        Settings.turtle = false;
        Settings.gac = false;
        Settings.dad = true;
        Settings.among = false; 
        Settings.samuria = false;
        Settings.target = 5;
    }

    public void Among()
    {
        Settings.none = false;
        Settings.taco = false;
        Settings.recksFrog = false;
        Settings.bear = false;
        Settings.turtle = false;
        Settings.gac = false;
        Settings.dad = false;
        Settings.among = true;
        Settings.samuria = false;
        Settings.target = 2;
    }

    public void Samuria()
    {
        Settings.none = false;
        Settings.taco = false;
        Settings.recksFrog = false;
        Settings.bear = false;
        Settings.turtle = false;
        Settings.gac = false;
        Settings.dad = false;
        Settings.among = false;
        Settings.samuria = true;
        Settings.target = 1;
    }

    public void GetCharacters()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), OnDataRecieved, OnError);
    }

    void OnDataRecieved(GetUserDataResult result)
    {
        Debug.Log("Recieved user Characters");
        if (result.Data != null)
        {
            if (result.Data.ContainsKey("samuria"))
            {
                samuriaGet = result.Data["samuria"].Value;
            }
            
            if (result.Data.ContainsKey("turtle"))
            {
                turtleGet = result.Data["turtle"].Value;
            }
        }
        else
        {
            Debug.Log("Characters not received!");
        }
    }

    void OnError(PlayFabError error)
    {
        //messageText.text = error.ErrorMessage;
        Debug.Log("No Data to send!");
        Debug.Log(error.GenerateErrorReport());
    }
}

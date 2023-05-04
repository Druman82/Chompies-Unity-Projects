using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ERC721OwnerOfExample : MonoBehaviour
{
    public GameObject ObjToActivate;

    async void Start()
    {
        string chain = "ethereum";
        string network = "mainnet";
        string account = PlayerPrefs.GetString("Account");
        string tokenId = "125";
        string contract = "0x79C2dbC3cED9b873eC0E58d294313c7194C6C4A3";

        string ownerOf = await ERC721.OwnerOf(chain, network, contract, tokenId);
        print(ownerOf);
        //print(account);

        if (ownerOf.Contains(account))
        {
            ObjToActivate.SetActive(true);
        }
        /*
        else if (!ownerOf.Contains(account))
        {
            ObjToActivate.SetActive(false);
        }*/
    }
}

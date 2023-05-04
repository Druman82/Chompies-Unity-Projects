using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrownCoinGenerator : MonoBehaviour
{
    public ObjectPooler crownCoinPool;
    public ObjectPooler hoverboardPool;
    public ObjectPooler sewerPipePool;
    public ObjectPooler ninjaStarPool;
    public ObjectPooler turtleShellPool;
    public ObjectPooler batteryPool;
    public ObjectPooler helmetPool;
    public ObjectPooler spaceshipPool;
    public ObjectPooler portalPool;
    public ObjectPooler pillowPool;  
    public ObjectPooler bedPool;
    public ObjectPooler openHousePool;
    public ObjectPooler housePool;
    public ObjectPooler frgPool;
    public ObjectPooler jetpackPool;
    public ObjectPooler parachutePool;
    public ObjectPooler rocketPool;
    public ObjectPooler coinPool;
    public ObjectPooler bubblegumPool;
    public ObjectPooler hotAirBalloonPool;

    public void SpawnHotAirBalloon(Vector3 startPosition)
    {
        GameObject hotAirBalloon = hotAirBalloonPool.GetPooledObject();
        hotAirBalloon.transform.position = startPosition;
        hotAirBalloon.SetActive(true);
    }

    public void SpawnBubblegum(Vector3 startPosition)
    {
        GameObject bubblegum = bubblegumPool.GetPooledObject();
        bubblegum.transform.position = startPosition;
        bubblegum.SetActive(true);
    }

    public void SpawnCoins(Vector3 startPosition)
    {
        GameObject coin = coinPool.GetPooledObject();
        coin.transform.position = startPosition;
        coin.SetActive(true);
    }

    public void SpawnRockets(Vector3 startPosition)
    {
        GameObject rocket = rocketPool.GetPooledObject();
        rocket.transform.position = startPosition;
        rocket.SetActive(true);
    }

    public void SpawnParachutes(Vector3 startPosition)
    {
        GameObject parachute = parachutePool.GetPooledObject();
        parachute.transform.position = startPosition;
        parachute.SetActive(true);
    }

    public void SpawnJetpack(Vector3 startPosition)
    {
        GameObject jetpack = jetpackPool.GetPooledObject();
        jetpack.transform.position = startPosition;
        jetpack.SetActive(true);
    }

    public void SpawnFrgs(Vector3 startPosition)
    {
        GameObject frg = frgPool.GetPooledObject();
        frg.transform.position = startPosition;
        frg.SetActive(true);
    }

    public void SpawnHouses(Vector3 startPosition)
    {
        GameObject house = housePool.GetPooledObject();
        house.transform.position = startPosition;
        house.SetActive(true);
    }

    public void SpawnBed(Vector3 startPosition)
    {
        GameObject bed = bedPool.GetPooledObject();
        bed.transform.position = startPosition;
        bed.SetActive(true);
    }

    public void SpawnOpenHouse(Vector3 startPosition)
    {
        GameObject openHouse = openHousePool.GetPooledObject();
        openHouse.transform.position = startPosition;
        openHouse.SetActive(true);
    }

    public void SpawnPillow(Vector3 startPosition)
    {
        GameObject pillow = pillowPool.GetPooledObject();
        pillow.transform.position = startPosition;
        pillow.SetActive(true);
    }

    public void SpawnPortal(Vector3 startPosition)
    {
        GameObject portal = portalPool.GetPooledObject();
        portal.transform.position = startPosition;
        portal.SetActive(true);
    }

    public void SpawnSpaceship(Vector3 startPosition)
    {
        GameObject spaceship = spaceshipPool.GetPooledObject();
        spaceship.transform.position = startPosition;
        spaceship.SetActive(true);
    }

    public void SpawnBattery(Vector3 startPosition)
    {
        GameObject battery = batteryPool.GetPooledObject();
        battery.transform.position = startPosition;
        battery.SetActive(true);
    }
    
    public void SpawnHelmet(Vector3 startPosition)
    {
        GameObject helmet = helmetPool.GetPooledObject();
        helmet.transform.position = startPosition;
        helmet.SetActive(true);
    }

    public void SpawnTurtleShell(Vector3 startPosition)
    {
        GameObject turtleShell = turtleShellPool.GetPooledObject();
        turtleShell.transform.position = startPosition;
        turtleShell.SetActive(true);
    }

    public void SpawnNinjaStar(Vector3 startPosition)
    {
        GameObject ninjaStar = ninjaStarPool.GetPooledObject();
        ninjaStar.transform.position = startPosition;
        ninjaStar.SetActive(true);
    }

    public void SpawnSewerPipe(Vector3 startPosition)
    {
        GameObject sewerPipe = sewerPipePool.GetPooledObject();
        sewerPipe.transform.position = startPosition;
        sewerPipe.SetActive(true);
    }

    public void SpawnHoverboards(Vector3 startPosition)
    {
        GameObject hoverboard = hoverboardPool.GetPooledObject();
        hoverboard.transform.position = startPosition;
        hoverboard.SetActive(true);
    }

    public void SpawnCrownCoin(Vector3 startPosition)
    {
        GameObject crownCoin = crownCoinPool.GetPooledObject();
        crownCoin.transform.position = startPosition;
        crownCoin.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public Transform generationPoint;
    public float distanceBetween;
    public float distanceBetweenMin;
    public float distanceBetweenMax;
    private int platformSelector;
    private float[] platformWidths;
    public ObjectPooler[] theObjectPools;
    private float minHeight;
    public Transform maxHeightPoint;
    private float maxHeight;
    public float maxHeightChange;
    private float heightChange;
    private CrownCoinGenerator theCrownCoinGenerator;
    public float randomCoinThreshold;
    public float randomParachuteThreshold;
    public float randomHouseThreshold;
    public float randomOpenHouseThreshold;
    public float randomFrgThreshold;
    public float randomHoverboardThreshold;
    public float randomRocketThreshold;
    public float randomJetpackThreshold;
    public float randomCrownCoinThreshold;
    public float randomSewerPipeThreshold;
    public float randomNinjaStarThreshold;
    public float randomTurtleShellThreshold;
    public float randomBatteryThreshold;
    public float randomSpaceshipThreshold;
    public float randomPortalThreshold;
    public float randomPillowThreshold;
    public float randomBedThreshold;
    public float randomBubblegumThreshold;
    public float randomHotAirBalloonThreshold;
    public float randomHelmetThreshold;
    private float randomX;
    private float randomY;

    // Start is called before the first frame update
    void Start()
    {
        platformWidths = new float[theObjectPools.Length];
        
        for (int i = 0; i < theObjectPools.Length; i++)
        {
            platformWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider>().size.x;
        }

        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;
        theCrownCoinGenerator = FindObjectOfType<CrownCoinGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < generationPoint.position.x)
        {
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);

            platformSelector = Random.Range(0, theObjectPools.Length);

            heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);

            if(heightChange > maxHeight)
            {
                heightChange = maxHeight;
            }else if (heightChange < minHeight)
            {
                heightChange = minHeight;
            }

            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2) + distanceBetween, heightChange, transform.position.z);

            GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject();

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);


            //Coin
            if (Random.Range(0f, 100f) < randomCoinThreshold)
            {
                randomX = Random.Range(0f, 7f);

                theCrownCoinGenerator.SpawnCoins(new Vector3(transform.position.x + randomX, transform.position.y + 2f, transform.position.z));
            }

            //FRG
            if (Random.Range(0f, 100f) < randomFrgThreshold)
            {
                randomX = Random.Range(0f, 7f);

                theCrownCoinGenerator.SpawnFrgs(new Vector3(transform.position.x + randomX, transform.position.y + 2f, transform.position.z));
            }
            
            //Parachute
            if (Random.Range(0f, 100f) < randomParachuteThreshold)
            {
                randomY = Random.Range(0f, 7f);

                theCrownCoinGenerator.SpawnParachutes(new Vector3(transform.position.x + randomY, transform.position.y + 2f, transform.position.z));
            }

            //Hoverboard
            if (Random.Range(0f, 100f) < randomHoverboardThreshold)
            {
                randomX = Random.Range(0f, 7f);

                theCrownCoinGenerator.SpawnHoverboards(new Vector3(transform.position.x + randomX, transform.position.y + 2f, transform.position.z));
            }

            //Open House
            if (Settings.openHouse == true && Settings.night == true)
            {
                if (Random.Range(0f, 100f) < randomOpenHouseThreshold)
                {
                    randomY = Random.Range(0f, 7f);

                    theCrownCoinGenerator.SpawnOpenHouse(new Vector3(transform.position.x + 1, transform.position.y + 0.5f, transform.position.z + 1f));
                }
            }
            //House
            else
            {
                if (Random.Range(0f, 100f) < randomHouseThreshold)
                {
                    randomY = Random.Range(0f, 7f);

                    theCrownCoinGenerator.SpawnHouses(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z + 1f));
                }
            }

            //Jetpack
            if (Settings.jetpack == true)
            {
                if (Random.Range(0f, 100f) < randomJetpackThreshold)
                {
                    randomY = Random.Range(0f, 7f);

                    theCrownCoinGenerator.SpawnJetpack(new Vector3(transform.position.x + randomX, transform.position.y + 1f, transform.position.z));
                }
            }
            //Rocket
            else
            {
                if (Random.Range(0f, 100f) < randomRocketThreshold && Settings.gameLevel == true)
                {
                    randomX = Random.Range(0f, 7f);

                    theCrownCoinGenerator.SpawnRockets(new Vector3(transform.position.x + randomX, transform.position.y + 1f, transform.position.z));
                }
            }

            //Crown Coin
            if (Settings.crownCoin == 0)
            {
                if (Random.Range(0f, 100f) < randomCrownCoinThreshold)
                {
                    randomY = Random.Range(0f, 7f);

                    theCrownCoinGenerator.SpawnCrownCoin(new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z));
                }
            }

            //Sewer Pipe
            if (Settings.sewerPipe == true)
            {
                if (Random.Range(0f, 100f) < randomSewerPipeThreshold)
                {
                    randomY = Random.Range(0f, 7f);

                    theCrownCoinGenerator.SpawnSewerPipe(new Vector3(transform.position.x + 1, transform.position.y + 2f, transform.position.z));
                }
            }
            //Turtle Shell
            else if (Settings.turtleShell == true && Settings.sewerPipe == false)
            {
                if (Random.Range(0f, 100f) < randomTurtleShellThreshold)
                {
                    randomY = Random.Range(0f, 7f);

                    theCrownCoinGenerator.SpawnTurtleShell(new Vector3(transform.position.x + 1, transform.position.y + 2f, transform.position.z));
                }
            }
            //Ninja Star
            else
            {
                if (Random.Range(0f, 100f) < randomNinjaStarThreshold)
                {
                    randomX = Random.Range(0f, 7f);

                    theCrownCoinGenerator.SpawnNinjaStar(new Vector3(transform.position.x + randomX, transform.position.y + 2f, transform.position.z));
                }
            }

            //Spaceship
            if (Settings.spaceship == true)
            {
                if (Random.Range(0f, 100f) < randomSpaceshipThreshold)
                {
                    randomY = Random.Range(0f, 7f);

                    theCrownCoinGenerator.SpawnSpaceship(new Vector3(transform.position.x + 1, transform.position.y + 2f, transform.position.z));
                }
            }

            //Helmet
            else if (Settings.helmet == true && Settings.spaceship == false)
            {
                if (Random.Range(0f, 100f) < randomHelmetThreshold)
                {
                    randomY = Random.Range(0f, 7f);

                    theCrownCoinGenerator.SpawnHelmet(new Vector3(transform.position.x + 1, transform.position.y + 2f, transform.position.z));
                }
            }
            //Battery
            else
            {
                if (Random.Range(0f, 100f) < randomBatteryThreshold)
                {
                    randomX = Random.Range(0f, 7f);

                    theCrownCoinGenerator.SpawnBattery(new Vector3(transform.position.x + randomX, transform.position.y + 2f, transform.position.z));
                }
            }

            //Portal
            if (Random.Range(0f, 100f) < randomPortalThreshold)
                {
                    randomY = Random.Range(0f, 7f);

                    theCrownCoinGenerator.SpawnPortal(new Vector3(transform.position.x + 1, transform.position.y + 2f, transform.position.z));
                }

            //Bed
            if (Settings.bed == true)
            {
                if (Random.Range(0f, 100f) < randomBedThreshold)
                {
                    randomY = Random.Range(0f, 7f);

                    theCrownCoinGenerator.SpawnBed(new Vector3(transform.position.x + 1, transform.position.y + 1f, transform.position.z));
                }
            }
            //Pillow
            else
            {
                if (Random.Range(0f, 100f) < randomPillowThreshold)
                {
                    randomX = Random.Range(0f, 7f);

                    theCrownCoinGenerator.SpawnPillow(new Vector3(transform.position.x + randomX, transform.position.y + 2f, transform.position.z));
                }
            }

            //Bubblegum
            if (Random.Range(0f, 100f) < randomBubblegumThreshold)
            {
                randomX = Random.Range(0f, 7f);

                theCrownCoinGenerator.SpawnBubblegum(new Vector3(transform.position.x + randomX, transform.position.y + 2.5f, transform.position.z));
            }

            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2), transform.position.y, transform.position.z);

            //HotAirBalloon
            if (Settings.hotAirBalloon == true)
            {
                if (Random.Range(0f, 100f) < randomHotAirBalloonThreshold)
                {
                    randomX = Random.Range(0f, 7f);

                    theCrownCoinGenerator.SpawnHotAirBalloon(new Vector3(transform.position.x + randomX, transform.position.y + 4.5f, transform.position.z));
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class RacePlayerMovementKeyboard : MonoBehaviour
{
    [SerializeField] public Transform catcher;
    [SerializeField] public Transform ceiling;
    [SerializeField] LayerMask groundLayers;
    [SerializeField] public float runSpeed;
    [SerializeField] public float jumpHeight;
    [SerializeField] private Transform[] groundChecks;
    [SerializeField] private Transform[] wallChecks;
    [SerializeField] private Transform glasses;
    [SerializeField] private Transform mask;
    [SerializeField] private Transform turtleMask;
    [SerializeField] public Transform frogCostume;
    [SerializeField] public Transform footR;
    [SerializeField] public Transform footL;
    [SerializeField] public Transform turtleCostume;
    [SerializeField] public Transform dayLight;
    [SerializeField] private Transform sunLight;
    [SerializeField] private Transform moonLight;
    [SerializeField] public Transform parachute;
    [SerializeField] public Transform glider;
    [SerializeField] public Transform bubblegumBalloon;
    [SerializeField] public Transform bubblegumPop;
    [SerializeField] public Transform hotAirBalloon;
    [SerializeField] public Transform hotAirBalloonStart;
    [SerializeField] public Transform red;
    [SerializeField] public Transform blue;
    [SerializeField] public Transform planeGameLevel3D;
    [SerializeField] public Transform planeGameLevel2D;
    [SerializeField] public Transform planeGameLevel3DNight;
    [SerializeField] public Transform planeGameLevel2DNight;
    [SerializeField] public Transform rocketText;
    [SerializeField] public Transform tokenText;
    [SerializeField] public Transform jetpack;
    [SerializeField] public Transform jetpackStart;
    [SerializeField] public Transform hoverboard;
    [SerializeField] public Transform spaceship;
    [SerializeField] public Transform helmet;
    [SerializeField] public Transform spaceshipHood;
    [SerializeField] public Transform spaceshipStart;
    [SerializeField] public Transform sleepHat;
    [SerializeField] public Transform pJTop;
    [SerializeField] public Transform pJR1;
    [SerializeField] public Transform pJR2;
    [SerializeField] public Transform pJL1;
    [SerializeField] public Transform pJL2;
    [SerializeField] public Transform flashlight;
    [SerializeField] public Transform turtleShell;
    [SerializeField] public Transform bandannaBlue;
    [SerializeField] public Transform bandannaPurple;
    [SerializeField] public Transform bandannaRed;
    [SerializeField] public Transform bandannaOrange;
    [SerializeField] public Transform showPortal;
    [SerializeField] public Transform bee;
    [SerializeField] public Transform samuriaLegL;
    [SerializeField] public Transform samuriaLegR;
    [SerializeField] public Transform samuriaCostume;
    [SerializeField] public Transform player;
    [SerializeField] public Transform amongPlayer;
    [SerializeField] public Transform bearPlayer;
    [SerializeField] public Transform gacPlayer;
    [SerializeField] public Transform dadPlayer;
    [SerializeField] public Transform plaguePlayer;
    public GameObject joystickCanvas;
    public GameObject finishMessage;


    public float gravity;
    public CharacterController characterController;
    public Vector3 velocity;
    private bool mobile;
    public bool isGrounded;
    public float horizontalInput;
    public bool notMoving;
    private Animator animator;
    public bool jumpPressed;
    public bool touchPressed;
    public float speed;
    private float jumpTimer = -1;
    private float jumpGracePeriod = .1f;
    public GameManager theGameManager;
    public float speedMultiplier;
    public float speedIncreaseMilestone;
    public float speedMilestoneCount;
    private bool rotate;
    private bool bed;
    private bool spaceshipLift;
    private bool portal = false;
    private ScoreManager theScoreManager;
    public int scoreToGive;
    public int rocketsToGive;
    public int ninjaStarsToGive;
    public int batteriesToGive;
    public int pillowsToGive;
    private float jumpPower;
    public float jumpCount;
    public float jumpTime;
    private float jumpTimeCounter;
    private int randomNum;
    private int parachuteCount = 0;
    private int gliderCount = 0;
    private int hoverboardCount = 0;
    public PauseMenu pauseMenu;
    public AudioSource coinSound;
    public AudioSource frogSound;
    public AudioSource parachuteSound;
    public AudioSource jumpSound;
    public AudioSource deathSound;
    public AudioSource recordScratch;
    public AudioSource backgroundMusic2D;
    public AudioSource backgroundMusic3D;
    public AudioSource backgroundMusicNight;
    public AudioSource backgroundMusicSpace;
    public AudioSource backgroundMusicSewer;
    public AudioSource backgroundMusicCity;
    public AudioSource backgroundMusicCityRain;
    public AudioSource backgroundMusicHouse;
    public AudioSource backgroundMusicCandyland;
    public AudioSource backgroundMusicWindLoop;
    public AudioSource backgroundMusicSlot;
    public AudioSource houseSound;
    public AudioSource waterSound;
    public AudioSource jetpackSound;
    public AudioSource rocketSound;
    public AudioSource hoverboardSound;
    public AudioSource portalSound;
    public AudioSource crownCoinSound;
    public AudioSource slotSound;
    public AudioSource ninjaStarSound;
    public AudioSource turtleShellSound;
    public AudioSource batterySound;
    public AudioSource helmetSound;
    public AudioSource spaceshipSound;
    public AudioSource pillowSound;
    public AudioSource balloonInflate;
    public AudioSource balloonPop;
    public AudioSource hotAirBalloonSound;
    public AudioSource beeSound;
    public AudioSource beeMusic;
    public AudioSource finishSound;
    public PlayfabManager playfabManager;
    public Settings settings;
    private bool jumping;
    private bool active;
    public string gameLevel;
    public string spaceLevel;
    public string sewerLevel;
    public string cityLevel;
    public string insideLevel;
    public string candylandLevel;
    public string slotMachine;
    public int randomizer;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI rocket;
    public TextMeshProUGUI ninjaStarText;
    public TextMeshProUGUI batteryText;
    public TextMeshProUGUI pillowText;
    public TextMeshProUGUI crown;
    public FloatingJoystick joystickL;
    public TextMeshProUGUI timeText;
    public float currentTime;
    private bool startingLine = false;
    public bool glide = false;


    void Start()
    {

        if (Settings.gameLevel == true)
        {
            if (Settings.night == false)
            {
                moonLight.gameObject.SetActive(false);
                dayLight.gameObject.SetActive(true);
                sunLight.gameObject.SetActive(true);
            }
            else if (Settings.night == true)
            {
                moonLight.gameObject.SetActive(true);
                dayLight.gameObject.SetActive(false);
                sunLight.gameObject.SetActive(false);
            }
        }
        Cursor.visible = false;
        if (Settings.space == true && Settings.musicBool == true)
        {
            backgroundMusicSpace.Play();
        }
        else if (Settings.sewer == true && Settings.musicBool == true)
        {
            backgroundMusicSewer.Play();
        }
        else if (Settings.city == true && Settings.musicBool == true)
        {
            backgroundMusicCity.Play();
            backgroundMusicCityRain.Play();
        }
        else if (Settings.house == true && Settings.musicBool == true)
        {
            backgroundMusicHouse.Play();
        }
        else if (Settings.candyland == true && Settings.musicBool == true)
        {
            backgroundMusicWindLoop.Play();
            backgroundMusicCandyland.Play();
        }
        else if (Settings.slots == true && Settings.musicBool == true && Settings.gameLevel == false)
        {
            backgroundMusicSlot.Play();
        }
        else if (Settings.night == true && Settings.musicBool == true)
        {
            backgroundMusicNight.Play();
        }
        else if (Settings.threeD == false && Settings.musicBool == true)
        {
            backgroundMusic2D.Play();
        }
        else if (Settings.threeD == true && Settings.musicBool == true)
        {
            backgroundMusic3D.Play();
        }

        //Characters
        if (Settings.turtle == true)
        {
            turtleCostume.gameObject.SetActive(true);
            footL.gameObject.SetActive(true);
            footR.gameObject.SetActive(true);
            mask.gameObject.SetActive(false);
            amongPlayer.gameObject.SetActive(false);
            bearPlayer.gameObject.SetActive(false);
            gacPlayer.gameObject.SetActive(false);
            dadPlayer.gameObject.SetActive(false);
            plaguePlayer.gameObject.SetActive(false);
        }

        if (Settings.samuria == true)
        {
            samuriaCostume.gameObject.SetActive(true);
            samuriaLegL.gameObject.SetActive(true);
            samuriaLegR.gameObject.SetActive(true);
            mask.gameObject.SetActive(false);
            amongPlayer.gameObject.SetActive(false);
            bearPlayer.gameObject.SetActive(false);
            gacPlayer.gameObject.SetActive(false);
            dadPlayer.gameObject.SetActive(false);
            plaguePlayer.gameObject.SetActive(false);
        }

        if (Settings.among == true)
        {
            player.gameObject.SetActive(false);
            amongPlayer.gameObject.SetActive(true);
            bearPlayer.gameObject.SetActive(false);
            gacPlayer.gameObject.SetActive(false);
            dadPlayer.gameObject.SetActive(false);
            plaguePlayer.gameObject.SetActive(false);
        }
        else if (Settings.among == false && Settings.none == true)
        {
            player.gameObject.SetActive(true);
            amongPlayer.gameObject.SetActive(false);
            bearPlayer.gameObject.SetActive(false);
            gacPlayer.gameObject.SetActive(false);
            dadPlayer.gameObject.SetActive(false);
            plaguePlayer.gameObject.SetActive(false);
        }
        else if (Settings.bear == true && Settings.among == false && Settings.none == false)
        {
            player.gameObject.SetActive(false);
            amongPlayer.gameObject.SetActive(false);
            bearPlayer.gameObject.SetActive(true);
            gacPlayer.gameObject.SetActive(false);
            dadPlayer.gameObject.SetActive(false);
            plaguePlayer.gameObject.SetActive(false);
        }
        else if (Settings.bear == false && Settings.among == false && Settings.none == false && Settings.gac == true)
        {
            player.gameObject.SetActive(false);
            amongPlayer.gameObject.SetActive(false);
            bearPlayer.gameObject.SetActive(false);
            gacPlayer.gameObject.SetActive(true);
            dadPlayer.gameObject.SetActive(false);
            plaguePlayer.gameObject.SetActive(false);
        }
        else if (Settings.bear == false && Settings.among == false && Settings.none == false && Settings.gac == false && Settings.dad == true)
        {
            player.gameObject.SetActive(false);
            amongPlayer.gameObject.SetActive(false);
            bearPlayer.gameObject.SetActive(false);
            gacPlayer.gameObject.SetActive(false);
            dadPlayer.gameObject.SetActive(true);
            plaguePlayer.gameObject.SetActive(false);
        }
        else if (Settings.bear == false && Settings.among == false && Settings.none == false && Settings.gac == false && Settings.dad == false && Settings.recksFrog == true)
        {
            player.gameObject.SetActive(false);
            amongPlayer.gameObject.SetActive(false);
            bearPlayer.gameObject.SetActive(false);
            gacPlayer.gameObject.SetActive(false);
            dadPlayer.gameObject.SetActive(false);
            plaguePlayer.gameObject.SetActive(true);
        }

        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        theScoreManager = FindObjectOfType<ScoreManager>();

        //jumpTimeCounter = jumpTime;
        jumpCount = 0;
        jumpPower = -2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (startingLine == true)
        {
            currentTime = currentTime + Time.deltaTime;
            timeText.text = currentTime.ToString("0.00");
        }

 
        if (rotate == true)
        {
            transform.Rotate(Vector3.up * speed * Time.deltaTime);
        }

        if (bed == true)
        {
            transform.Rotate(Vector3.forward * 75 * Time.deltaTime);
        }



        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            joystickCanvas.SetActive(true);
            float x = joystickL.Horizontal;
            Vector2 move = transform.forward * x + transform.forward * -x;
            characterController.Move(move * runSpeed * Time.deltaTime);

            horizontalInput = x;
        }
        else
        {
            //joystickCanvas.SetActive(false);
            float x = Input.GetAxis("Horizontal");
            Vector2 move = transform.forward * x + transform.forward * -x;
            characterController.Move(move * runSpeed * Time.deltaTime);
        
            horizontalInput = x;
        }

        
        if (horizontalInput == 0f)
        {
            notMoving = true;
        }
        else
        {
            notMoving = false;
        }

        if (rotate == false && bed == false)
        {
            transform.forward = new Vector3(horizontalInput, 0, Mathf.Abs(horizontalInput) - 1);
        }

        if (Settings.house)
        {
            if (Settings.samuria)
            {
                sleepHat.gameObject.SetActive(false);
            }
            else
            {
                sleepHat.gameObject.SetActive(true);
            }
        }
        if (Settings.space)
        {
            //Spaceship Start
            if (Settings.spaceshipStart == true)
            {
                spaceshipStart.gameObject.SetActive(true);
                helmet.gameObject.SetActive(true);
            }
            else
            {
                spaceshipStart.gameObject.SetActive(false);
                helmet.gameObject.SetActive(false);
            }

            //Hot Air Balloon Start
            if (Settings.hotAirBalloonStart == true)
            {
                hotAirBalloonStart.gameObject.SetActive(true);
            }
            else
            {
                hotAirBalloonStart.gameObject.SetActive(false);
            }

            //Jetpack Start
            if (Settings.jetpackStart == true)
            {
                jetpackStart.gameObject.SetActive(true);
            }
            else
            {
                jetpackStart.gameObject.SetActive(false);
            }

        }
        //Portal Start
        if (Settings.portal == true)
        {
            showPortal.gameObject.SetActive(true);
        }
        else
        {
            showPortal.gameObject.SetActive(false);
        }



        isGrounded = false;

        if (Settings.tokenNum >= 1)
        {
            tokenText.gameObject.SetActive(true);
        }

        // Speed increase
        if (transform.position.x > speedMilestoneCount)
        {
            Settings.finishLine = true;

            //speedMilestoneCount += speedIncreaseMilestone;
            //speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;
            //runSpeed = runSpeed * speedMultiplier;
        }
        // Ground checking
        foreach (var groundCheck in groundChecks)
        {
            if (Physics.CheckSphere(groundCheck.position, 0.1f, groundLayers, QueryTriggerInteraction.Ignore) && Settings.hoverboard == false)
            {
                isGrounded = true;
                break;
            }
        }

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0;
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }

        //Wallcheck - prevents player from getting stuck when running into a block and jumping
        var blocked = false;
        foreach (var wallCheck in wallChecks)
        {
            if (Physics.CheckSphere(wallCheck.position, 0.01f, groundLayers, QueryTriggerInteraction.Ignore))
            {
                blocked = true;
                break;
            }
        }

        if (!blocked)
        {
            characterController.Move(new Vector3(horizontalInput * runSpeed, 0, 0) * Time.deltaTime);
        }

        // Jumping
        if (isGrounded)
        {
            StopCoroutine("Parachute1");
            StopCoroutine("Parachute2");
            StopCoroutine("Glider1");
            StopCoroutine("Glider2");
            parachute.gameObject.SetActive(false);
            glider.gameObject.SetActive(false);
            bubblegumBalloon.gameObject.SetActive(false);
            balloonInflate.Stop();
            parachuteCount = 0;
            gliderCount = 0;
            hoverboardCount = 0;

            if (Settings.space == false && rotate == false && spaceshipLift == false && Settings.candyland == false && Settings.gameLevel == false && Settings.house == false && Settings.sewer == false)
            {
                gravity = -40f;
            }
            else if (Settings.gameLevel == true)
            {
                gravity = -30;
            }
            else if (Settings.sewer == true)
            {
                gravity = -35;
            }
            else if (Settings.house == true)
            {
                gravity = -35;
            }
            else if (Settings.space == true)
            {
                gravity = -25f;
            }
            else if (Settings.candyland == true)
            {
                gravity = -25f;
            }
            else if (Settings.raceLevel == true)
            {
                gravity = -40f;
            }
            jumpPower = -2f;
        }

        jumpPressed = Input.GetKey(KeyCode.Space);
        //touchPressed = Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began;
        if (jumpPressed || touchPressed)
        {
            jumpTimer = Time.time;
        }

        jumping = true;

        if (pauseMenu.gameObject.activeSelf)
        {
            jumping = false;
        }
        else
        {
            jumping = true;
        }

        //Parachute
        if (parachute.gameObject.activeSelf && jumpPressed)
        {
            if (transform.position.y <= 8)
            {
                if (velocity.y < 10)
                {
                    velocity.y += Mathf.Sqrt((jumpPower * gravity) / 32);
                }
            }
            else if (transform.position.y > 8)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            }
        }
        if (parachute.gameObject.activeSelf && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary)
        {
            if (transform.position.y <= 8)
            {
                if (velocity.y <= 10)
                {
                    velocity.y += Mathf.Sqrt((jumpPower * gravity) / 4);
                }
            }
            else if (transform.position.y > 8)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            }
        }

        //Glider
        if (glider.gameObject.activeSelf && (jumpPressed || glide == true))
        {
            runSpeed = 10;
            if (transform.position.y <= 8)
            {
                if (velocity.y < 10)
                {
                    velocity.y += Mathf.Sqrt((jumpPower * gravity) / 32);
                }
            }
            else if (transform.position.y > 8)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            }
        }
        else if (!glider.gameObject.activeSelf)
        {
            runSpeed = 7;
        }

        if ((jumpPressed && Settings.hoverboard == true && active) || (touchPressed && Settings.hoverboard == true && active))
        {
            Settings.hoverboard = false;
            gravity = -25f;
            velocity.y += Mathf.Sqrt(jumpHeight * jumpPower * gravity);
            hoverboard.gameObject.SetActive(false);
            hoverboardSound.Stop();
        }
        if ((jumpPressed && bubblegumBalloon.gameObject.activeSelf && active) || (touchPressed && bubblegumBalloon.gameObject.activeSelf && active))
        {
            gravity = -25f;
            active = false;
            balloonInflate.Stop();
            StartCoroutine("Bubblegum2");
        }

        if (isGrounded && jumping && (jumpPressed || (jumpTimer > 0 && Time.time < jumpTimer + jumpGracePeriod)))
        {
            velocity.y += Mathf.Sqrt(jumpHeight * jumpPower * gravity);

            if (Settings.soundFXBool == true)
            {
                jumpSound.Play();
            }
            jumpTimer = -1;
        }

        characterController.Move(velocity * Time.deltaTime);

        animator.SetFloat("Speed", horizontalInput);

        animator.SetBool("IsGrounded", isGrounded);

        animator.SetBool("NotMoving", notMoving);

        animator.SetFloat("VerticalSpeed", velocity.y);

    }

    public void Jump()
    {
        jumpTimer = Time.time;

        if (isGrounded)
        {
            if (jumpTimer > 0 && Time.time < jumpTimer + jumpGracePeriod)
            {
                velocity.y += Mathf.Sqrt(jumpHeight * jumpPower * gravity);

                if (Settings.soundFXBool == true)
                {
                    jumpSound.Play();
                }
                jumpTimer = -1;
            }
        }

        //Glider
        if (glider.gameObject.activeSelf)
        {
            glide = true;
            runSpeed = 10;
            if (transform.position.y <= 8)
            {
                if (velocity.y <= 10)
                {
                    velocity.y += Mathf.Sqrt((jumpPower * gravity) / 8);
                }
            }
            else if (transform.position.y > 8)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            }
        }
        else if (!glider.gameObject.activeSelf)
        {
            runSpeed = 7;
        }
    }

    public IEnumerator Colors()
    {
        yield return new WaitForSeconds(0.2f);
        Settings.threeD = true;
        planeGameLevel2D.gameObject.SetActive(false);
        planeGameLevel3D.gameObject.SetActive(true);
        if (Settings.night == true)
        {
            planeGameLevel2DNight.gameObject.SetActive(false);
            planeGameLevel3DNight.gameObject.SetActive(true);
        }
        red.gameObject.SetActive(false);
        blue.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        blue.gameObject.SetActive(false);
    }
    public IEnumerator ChangeBackgroundSong()
    {
        yield return new WaitForSeconds(0.3f);
        backgroundMusic3D.Play();
    }

    public IEnumerator Parachute1()
    {
        if (Settings.recks == true)
        {
            yield return new WaitForSeconds(5);
            if (parachute.gameObject.activeSelf)
            {
                parachute.gameObject.SetActive(false);
            }
        }
        else
        {
            //Debug.Log("Parachute 1");
            //Debug.Log(parachuteCount);
            StopCoroutine("Parachute2");
            yield return new WaitForSeconds(4.1f);

            if (parachute.gameObject.activeSelf)
            {
                if (parachuteCount == 1)
                {
                    parachute.gameObject.SetActive(false);
                }
                else
                {
                    StartCoroutine("Parachute2");
                }
            }
        }
    }

    public IEnumerator Parachute2()
    {
        StopCoroutine("Parachute1");
        Debug.Log("Parachute 2");
        Debug.Log(parachuteCount);
        parachuteCount = 0;
        yield return new WaitForSeconds(4.1f);
        if (parachute.gameObject.activeSelf && parachuteCount != 0)
        {
            StartCoroutine("Parachute1");
        }
        else if (parachute.gameObject.activeSelf && parachuteCount == 0)
        {
            parachute.gameObject.SetActive(false);
        }
    }


    public IEnumerator Glider1()
    {
        StopCoroutine("Glider2");
        yield return new WaitForSeconds(4.1f);

        if (glider.gameObject.activeSelf)
        {
            if (gliderCount == 1)
            {
                glider.gameObject.SetActive(false);
            }
            else
            {
                StartCoroutine("Glider2");
            }
        }
    }

    public IEnumerator Glider2()
    {
        StopCoroutine("Glider1");
        gliderCount = 0;
        yield return new WaitForSeconds(4.1f);
        if (glider.gameObject.activeSelf && parachuteCount != 0)
        {
            StartCoroutine("Glider1");
        }
        else if (glider.gameObject.activeSelf && gliderCount == 0)
        {
            glider.gameObject.SetActive(false);
        }
    }

    public IEnumerator Hover1()
    {
        active = false;
        yield return new WaitForSeconds(0.2f);
        active = true;
        yield return new WaitForSeconds(1.8f);
        if (hoverboardCount == 1)
        {
            Settings.hoverboard = false;
            gravity = -25f;
            hoverboard.gameObject.SetActive(false);
            hoverboardCount = 0;
        }
        else if (hoverboardCount == 2)
        {

            StartCoroutine("Hover2");
        }
    }

    public IEnumerator Hover2()
    {
        hoverboardCount = 0;
        active = false;
        yield return new WaitForSeconds(0.2f);
        active = true;
        yield return new WaitForSeconds(1.8f);
        Settings.hoverboard = false;
        gravity = -25f;
        hoverboard.gameObject.SetActive(false);
    }

    public IEnumerator GoToSpace()
    {
        ceiling.gameObject.SetActive(false);
        StartCoroutine("LevelEndScore");
        Settings.portal = false;
        Settings.jetpackStart = true;
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(spaceLevel);
        Settings.space = true;
        Settings.crownCoin = 0;
        Settings.pillowCount = 0;
        Settings.bubblegumCount = 0;
        Settings.rocketCount = 0;
        CameraFollow.jetpack = false;
        Settings.gameLevel = false;
        Settings.candyland = false;
        Settings.house = false;
        Settings.jetpack = false;
        Settings.bed = false;
        Settings.hotAirBalloon = false;
        Settings.night = false;
        Settings.levelSpace = true;
        Settings.levelChange = true;
    }

    public IEnumerator HotAirBalloonRide()
    {
        ceiling.gameObject.SetActive(false);
        StartCoroutine("LevelEndScore");
        Settings.portal = false;
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(spaceLevel);
        Settings.space = true;
        Settings.crownCoin = 0;
        Settings.pillowCount = 0;
        Settings.bubblegumCount = 0;
        Settings.rocketCount = 0;
        CameraFollow.jetpack = false;
        Settings.gameLevel = false;
        Settings.candyland = false;
        Settings.house = false;
        Settings.jetpack = false;
        Settings.bed = false;
        Settings.hotAirBalloon = false;
        Settings.levelSpace = true;
        Settings.alternateSpace = true;
    }

    public IEnumerator GoToSpace2()
    {
        ceiling.gameObject.SetActive(false);
        StartCoroutine("LevelEndScore");
        Settings.portal = false;
        Settings.spaceshipStart = true;
        yield return new WaitForSeconds(1.75f);
        if (Settings.soundFXBool == true)
        {
            spaceshipSound.Play();
        }
        velocity.y = 15;
        velocity.x = 20;

        yield return new WaitForSeconds(1.75f);
        SceneManager.LoadScene(spaceLevel);
        Settings.space = true;
        Settings.crownCoin = 0;
        Settings.city = false;
        Settings.spaceship = false;
        Settings.batteryCount = 0;
        Settings.levelSpace = true;
        Settings.alternateSpace = true;
    }

    public IEnumerator Sewer()
    {
        StartCoroutine("LevelEndScore");
        Settings.portal = false;
        yield return new WaitForSeconds(0.75f);
        CameraFollow.frogFeet = false;
        Settings.sewer = true;
        SceneManager.LoadScene(sewerLevel);
        Settings.crownCoin = 0;
        Settings.jetpack = false;
        Settings.rocketCount = 0;
        Settings.ninjaStarCount = 0;
        Settings.house = false;
        Settings.gameLevel = false;
        Settings.night = false;
        Settings.levelSewer = true;
        Settings.levelChange = true;
    }

    public IEnumerator GoToCity()
    {
        StartCoroutine("LevelEndScore");
        Settings.portal = false;
        yield return new WaitForSeconds(0.9f);
        Settings.city = true;
        SceneManager.LoadScene(cityLevel);
        Settings.crownCoin = 0;
        Settings.sewer = false;
        Settings.sewerPipe = false;
        Settings.ninjaStarCount = 0;
        Settings.turtleShell = false;
        Settings.city = true;
        Settings.levelCity = true;
    }

    public IEnumerator Randomizer()
    {
        StartCoroutine("LevelEndScore");
        hoverboard.gameObject.SetActive(false);
        yield return new WaitForSeconds(1.6f);
        CameraFollow.portal = false;
        if (randomizer == 0)
        {
            Settings.gameLevel = true;
            Settings.levelGame = true;
            Settings.space = false;
            SceneManager.LoadScene(gameLevel);
        }
        else if (randomizer == 1)
        {
            Settings.sewer = true;
            Settings.levelSewer = true;
            Settings.space = false;
            SceneManager.LoadScene(sewerLevel);
        }
        else if (randomizer == 2)
        {
            Settings.city = true;
            Settings.levelCity = true;
            Settings.space = false;
            SceneManager.LoadScene(cityLevel);
        }

        else if (randomizer == 3)
        {
            Settings.house = true;
            Settings.levelHouse = true;
            Settings.space = false;
            SceneManager.LoadScene(insideLevel);
        }

        else if (randomizer == 4)
        {
            Settings.candyland = true;
            Settings.levelCandyland = true;
            Settings.space = false;
            SceneManager.LoadScene(candylandLevel);
        }
    }

    public IEnumerator GoInside()
    {
        StartCoroutine("LevelEndScore");
        Settings.portal = false;
        yield return new WaitForSeconds(0.5f);
        Settings.gameLevel = false;
        Settings.coins = 0;
        Settings.jetpack = false;
        Settings.rocketCount = 0;
        Settings.openHouse = false;
        Settings.night = false;
        Settings.levelHouse = true;
        Settings.levelChange = true;
        SceneManager.LoadScene(insideLevel);
    }

    public IEnumerator GoToCandyland()
    {
        StartCoroutine("LevelEndScore");
        Settings.portal = false;
        yield return new WaitForSeconds(0.5f);
        Settings.house = false;
        Settings.candyland = true;
        Settings.pillowCount = 0;
        Settings.crownCoin = 0;
        Settings.bed = false;
        Settings.gameLevel = false;
        Settings.night = false;
        Settings.levelCandyland = true;
        SceneManager.LoadScene(candylandLevel);
    }

    public IEnumerator Bubblegum()
    {
        gravity = 0f;
        velocity.y = 3;
        active = false;
        yield return new WaitForSeconds(0.2f);
        active = true;
        yield return new WaitForSeconds(0.8f);
        StartCoroutine("Bubblegum2");
    }

    public IEnumerator Bubblegum2()
    {
        if (bubblegumBalloon.gameObject.activeSelf)
        {
            if (Settings.soundFXBool == true)
            {
                balloonPop.Play();
                balloonInflate.Stop();
            }
            bubblegumPop.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            bubblegumBalloon.gameObject.SetActive(false);
            gravity = -25f;
            jumpPower = -2;
            yield return new WaitForSeconds(0.2f);
            bubblegumPop.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Coin pickup
        if (other.gameObject.layer == 8)
        {
            other.gameObject.SetActive(false);
            currentTime -= 1;
            //Settings.coins++;
            //Settings.coinCount++;
            //StartCoroutine("Pulse");
            if (Settings.soundFXBool == true)
            {
                coinSound.Play();
            }
        }

        //Parachute pickup
        if (other.gameObject.layer == 9)
        {
            other.gameObject.SetActive(false);
            if (Settings.soundFXBool == true)
            {
                if (Settings.recks == true)
                {
                    Settings.night = true;
                    sunLight.gameObject.SetActive(false);
                    balloonInflate.Play();
                    beeSound.Play();
                    if (!beeMusic.isPlaying)
                    {
                        beeMusic.Play();
                    }
                    bee.gameObject.SetActive(true);
                }
                else
                {
                    Settings.parachuteCount++;
                    parachuteSound.Play();
                }
            }

            if (parachuteCount == 0)
            {
                parachuteCount++;
                StartCoroutine("Parachute1");
            }
            else
            {
                StartCoroutine("Parachute2");
            }
            jumpPower *= .3f;
            gravity = -20f;
            velocity.y += Mathf.Sqrt(jumpHeight * jumpPower * gravity);
            parachute.gameObject.SetActive(true);
            //StartCoroutine("PulseParachute");
            if (Settings.soundFXBool == true)
            {
                jumpSound.Play();
            }
        }

        //Glider pickup
        if (other.gameObject.tag == "Glider")
        {
            other.gameObject.SetActive(false);
            if (Settings.soundFXBool == true)
            {
                parachuteSound.Play();
            }

            if (gliderCount == 0)
            {
                gliderCount++;
                StartCoroutine("Glider1");
            }
            else
            {
                StartCoroutine("Glider2");
            }
            jumpPower *= .3f;
            gravity = -20f;
            velocity.y += Mathf.Sqrt(jumpHeight * jumpPower * gravity);
            glider.gameObject.SetActive(true);
            if (Settings.soundFXBool == true)
            {
                jumpSound.Play();
            }
        }

        //Glasses pickup
        if (other.gameObject.layer == 11 && Settings.sewerPipe == false)
        {
            other.gameObject.SetActive(false);
            Settings.glasses = true;
            backgroundMusic2D.Stop();
            red.gameObject.SetActive(true);
            StartCoroutine("Colors");
            if (!backgroundMusicNight.isPlaying && Settings.musicBool == true)
            {
                recordScratch.Play();
                if (Settings.recks == false)
                {
                    StartCoroutine("ChangeBackgroundSong");
                }
            }

        }
        if (Settings.glasses == true && Settings.sewerPipe == false)
        {
            glasses.gameObject.SetActive(true);
            mask.gameObject.SetActive(false);

        }
        else if (Settings.glasses == false && Settings.sewerPipe == false && Settings.none == true)
        {
            glasses.gameObject.SetActive(false);
            mask.gameObject.SetActive(true);

        }

        //House collision
        if (other.gameObject.layer == 13)
        {
            if (Settings.easy == false)
            {
                theScoreManager.AddScore(scoreToGive * 25);
            }
            if (Settings.soundFXBool == true)
            {
                houseSound.Play();
            }
            if (dayLight.gameObject.activeSelf)
            {
                Settings.night = true;
                moonLight.gameObject.SetActive(true);
                flashlight.gameObject.SetActive(true);
                dayLight.gameObject.SetActive(false);
                sunLight.gameObject.SetActive(false);
                if (Settings.samuria == false)
                {
                    sleepHat.gameObject.SetActive(true);
                }
                pJTop.gameObject.SetActive(true);
                pJL1.gameObject.SetActive(true);
                pJL2.gameObject.SetActive(true);
                pJR1.gameObject.SetActive(true);
                pJR2.gameObject.SetActive(true);
                if (Settings.threeD == true)
                {
                    planeGameLevel3DNight.gameObject.SetActive(true);
                }
                else if (Settings.threeD == false)
                {
                    planeGameLevel2DNight.gameObject.SetActive(true);
                }
                planeGameLevel2D.gameObject.SetActive(false);
                planeGameLevel3D.gameObject.SetActive(false);
                if (Settings.musicBool == true)
                {
                    backgroundMusic2D.Stop();
                    backgroundMusic3D.Stop();
                    backgroundMusicNight.Play();
                }
            }
            else
            {
                Settings.night = false;
                dayLight.gameObject.SetActive(true);
                sunLight.gameObject.SetActive(true);
                moonLight.gameObject.SetActive(false);
                flashlight.gameObject.SetActive(false);
                if (Settings.threeD == true)
                {
                    planeGameLevel3D.gameObject.SetActive(true);
                }
                else if (Settings.threeD == false)
                {
                    planeGameLevel2D.gameObject.SetActive(true);
                }
                sleepHat.gameObject.SetActive(false);
                pJTop.gameObject.SetActive(false);
                pJL1.gameObject.SetActive(false);
                pJL2.gameObject.SetActive(false);
                pJR1.gameObject.SetActive(false);
                pJR2.gameObject.SetActive(false);
                planeGameLevel3DNight.gameObject.SetActive(false);
                planeGameLevel2DNight.gameObject.SetActive(false);
                if (Settings.musicBool == true)
                {
                    backgroundMusicNight.Stop();
                    if (Settings.threeD == true)
                    {
                        backgroundMusic3D.Play();
                    }
                    else
                    {
                        backgroundMusic2D.Play();
                    }
                }
            }

        }

        //FRG pickup
        if (other.gameObject.layer == 14)
        {
            other.gameObject.SetActive(false);
            StartCoroutine("PulseFrg");
            if (Settings.soundFXBool == true)
            {
                frogSound.Play();
            }
            if (Settings.frg == false)
            {
                if (!mobile)
                {
                    jumpHeight += 0.5f;
                }
                else
                {
                    jumpHeight += .5f;
                }
            }
            if (Settings.gameLevel == true)
            {
                footR.gameObject.SetActive(true);
                footL.gameObject.SetActive(true);
                frogCostume.gameObject.SetActive(true);
            }
            Settings.frg = true;
        }

        //Water collision
        if (other.gameObject.layer == 4)
        {
            if (Settings.soundFXBool == true)
            {
                waterSound.Play();
            }
            if (Settings.frg == true && Settings.sewer == false)
            {
                catcher.gameObject.SetActive(false);
                CameraFollow.frogFeet = true;
                StartCoroutine("Sewer");
            }
            else if (Settings.frg == false)
            {
                return;
            }
        }

        //Rocket pickup
        if (other.gameObject.layer == 17)
        {
            other.gameObject.SetActive(false);
            rocketText.gameObject.SetActive(true);
            if (Settings.soundFXBool == true)
            {
                rocketSound.Play();
            }
            theScoreManager.AddRocket(rocketsToGive);
            StartCoroutine("PulseRocket");
        }

        //Jetpack pickup
        if (other.gameObject.layer == 18)
        {
            other.gameObject.SetActive(false);
            ceiling.gameObject.SetActive(false);
            jetpack.gameObject.SetActive(true);
            CameraFollow.jetpack = true;
            if (Settings.soundFXBool == true)
            {
                jetpackSound.Play();
            }
            velocity.y = 60;
            StartCoroutine("GoToSpace");
        }

        //Hoverboard pickup
        if (other.gameObject.layer == 19 && portal == false)
        {
            other.gameObject.SetActive(false);
            if (Settings.soundFXBool == true)
            {
                hoverboardSound.Play();
            }
            theScoreManager.AddScore(scoreToGive * 5);
            Settings.hoverboard = true;
            if (Settings.portal == false)
            {
                gravity = 0;
                velocity.y = 1;
                hoverboard.gameObject.SetActive(true);
                hoverboardCount++;
                StartCoroutine("Hover1");
                StartCoroutine("PulseParachute");
            }
        }

        //CrownCoin pickup
        if (other.gameObject.layer == 20)
        {
            other.gameObject.SetActive(false);
            theScoreManager.AddScore(scoreToGive * 10);
            Settings.tokenNum += 1;
            Settings.crownCoin += 1;
            Settings.slots = true;
            if (Settings.soundFXBool == true)
            {
                crownCoinSound.Play();
            }
            StartCoroutine("PulseParachute");
            StartCoroutine("PulseCrown");
        }

        //Pipe entrance
        if (other.gameObject.layer == 22)
        {
            StartCoroutine("GoToCity");
        }

        //NinjaStar pickup
        if (other.gameObject.layer == 23)
        {
            other.gameObject.SetActive(false);
            ninjaStarText.gameObject.SetActive(true);
            if (Settings.soundFXBool == true)
            {
                ninjaStarSound.Play();
            }
            theScoreManager.AddNinjaStar(ninjaStarsToGive);
            StartCoroutine("PulseNinjaStar");
        }

        //PipeScore
        if (other.gameObject.layer == 24)
        {
            other.gameObject.SetActive(false);
            StartCoroutine("PulsePipeScore");
        }

        //TurtleShell Pickup
        if (other.gameObject.layer == 25)
        {
            other.gameObject.SetActive(false);
            if (Settings.none == true || Settings.bear == true || Settings.gac == true || Settings.dad == true || Settings.recksFrog == true)
            {
                turtleShell.gameObject.SetActive(true);
                mask.gameObject.SetActive(false);
                turtleMask.gameObject.SetActive(false);
            }
            glasses.gameObject.SetActive(false);
            if (Settings.soundFXBool == true)
            {
                turtleShellSound.Play();
            }
            Settings.sewerPipe = true;
            randomNum = Random.Range(0, 4);
            if (randomNum == 0)
            {
                bandannaBlue.gameObject.SetActive(true);
            }
            else if (randomNum == 1)
            {
                bandannaOrange.gameObject.SetActive(true);
            }
            else if (randomNum == 2)
            {
                bandannaPurple.gameObject.SetActive(true);
            }
            else if (randomNum == 3)
            {
                bandannaRed.gameObject.SetActive(true);
            }
        }

        //TurtleShell Costume Pickup
        if (other.gameObject.tag == "Turtle")
        {
            if (Settings.turtleTog == false && CharacterSelector.turtleGet == null)
            {
                other.gameObject.SetActive(false);
                if (Settings.none == true || Settings.bear == true || Settings.gac == true || Settings.dad == true || Settings.recksFrog == true)
                {
                    turtleShell.gameObject.SetActive(true);
                    mask.gameObject.SetActive(false);
                    turtleMask.gameObject.SetActive(false);
                }
                bandannaBlue.gameObject.SetActive(true);
                glasses.gameObject.SetActive(false);
                if (Settings.soundFXBool == true)
                {
                    turtleShellSound.Play();
                }
                Settings.sewerPipe = true;
                Settings.turtlePickup = true;
                Settings.turtleTog = true;
                if (Settings.turtleActivated == false)
                {
                    settings.Turtle();
                    playfabManager.SaveTurtle();
                }
            }
            else
            {
                if (Settings.none == true || Settings.bear == true || Settings.gac == true || Settings.dad == true || Settings.recksFrog == true)
                {
                    turtleShell.gameObject.SetActive(true);
                    mask.gameObject.SetActive(false);
                    turtleMask.gameObject.SetActive(false);
                }
                bandannaBlue.gameObject.SetActive(true);
                glasses.gameObject.SetActive(false);
                Settings.sewerPipe = true;
                StartCoroutine("PulsePipeScore");
            }

        }

        //Ladder
        if (other.gameObject.layer == 26)
        {
            velocity.y = 10;
        }

        //Battery
        if (other.gameObject.layer == 27)
        {
            other.gameObject.SetActive(false);
            batteryText.gameObject.SetActive(true);
            if (Settings.soundFXBool == true)
            {
                batterySound.Play();
            }
            theScoreManager.AddBattery(batteriesToGive);
            StartCoroutine("PulseBattery");
        }

        //Helmet
        if (other.gameObject.tag == "Helmet")
        {
            other.gameObject.SetActive(false);
            helmet.gameObject.SetActive(true);
            mask.gameObject.SetActive(false);
            glasses.gameObject.SetActive(false);
            if (Settings.soundFXBool == true)
            {
                helmetSound.Play();
            }
            Settings.spaceship = true;
        }

        //Noodle Shop
        if (other.gameObject.tag == "Samuria")
        {
            if (Settings.samuriaTog == false && CharacterSelector.samuriaGet == null)
            {
                if (Settings.none == true)
                {
                    samuriaCostume.gameObject.SetActive(true);
                    samuriaLegL.gameObject.SetActive(true);
                    samuriaLegR.gameObject.SetActive(true);
                    mask.gameObject.SetActive(false);
                    glasses.gameObject.SetActive(false);
                }
                if (Settings.soundFXBool == true)
                {
                    helmetSound.Play();
                }
                Settings.samuriaPickup = true;
                settings.Samuria();
                Settings.samuriaTog = true;
                if (Settings.samuriaActivated == false)
                {
                    settings.Samuria();
                    playfabManager.SaveSamuria();
                }
            }
            else
            {
                helmetSound.Play();
                StartCoroutine("PulsePipeScore");
            }
        }

        //Spaceship
        if (other.gameObject.layer == 28)
        {
            other.gameObject.SetActive(false);
            ceiling.gameObject.SetActive(false);
            spaceship.gameObject.SetActive(true);
            catcher.gameObject.SetActive(false);
            spaceshipLift = true;
            if (Settings.soundFXBool == true)
            {
                hoverboardSound.Play();
            }
            velocity.x = -3;
            gravity = -6;
            StartCoroutine("GoToSpace2");
        }

        //Portal
        if (other.gameObject.layer == 29)
        {
            CameraFollow.portal = true;
            Settings.hoverboard = false;
            Settings.spaceshipStart = false;
            Settings.hotAirBalloonStart = false;
            portal = true;
            Settings.portal = true;
            if (Settings.soundFXBool == true)
            {
                portalSound.Play();
            }
            randomizer = 1;// Random.Range(0, 5);
            StartCoroutine("Randomizer");
        }

        //Pillow
        if (other.gameObject.layer == 30)
        {
            other.gameObject.SetActive(false);
            pillowText.gameObject.SetActive(true);
            if (Settings.soundFXBool == true)
            {
                pillowSound.Play();
            }
            theScoreManager.AddPillow(pillowsToGive);
            Settings.pillowCount++;
            StartCoroutine("PulsePillow");
        }

        //Bed
        if (other.gameObject.layer == 3)
        {
            bed = true;
            velocity.x = -2;
            StartCoroutine("GoToCandyland");
        }

        //OpenHouse
        if (other.gameObject.layer == 31)
        {
            if (Settings.soundFXBool == true)
            {
                houseSound.Play();
            }
            rotate = true;
            velocity.z = 5;
            velocity.x = -2;
            Settings.house = true;
            StartCoroutine("GoInside");
        }

        //Bubblegum
        if (other.gameObject.tag == "Bubblegum")
        {
            other.gameObject.SetActive(false);
            bubblegumBalloon.gameObject.SetActive(true);
            if (Settings.soundFXBool == true)
            {
                balloonInflate.Play();
            }
            Settings.bubblegumCount++;
            StartCoroutine("Bubblegum");
            StartCoroutine("PulseParachute");
        }

        //HotAirBalloon
        if (other.gameObject.tag == "HotAirBalloon")
        {
            Settings.hotAirBalloonStart = true;
            ceiling.gameObject.SetActive(false);
            catcher.gameObject.SetActive(false);
            other.gameObject.SetActive(false);
            if (Settings.soundFXBool == true)
            {
                hotAirBalloonSound.Play();
            }
            hotAirBalloon.gameObject.SetActive(true);
            CameraFollow.jetpack = true;
            gravity = 0;
            velocity.y = 5;
            StartCoroutine("HotAirBalloonRide");
        }

        //Bee
        if (other.gameObject.tag == "bee")
        {
            parachute.gameObject.SetActive(false);
            if (Settings.soundFXBool == true)
            {
                balloonPop.Play();
            }
        }

        //StartingLine
        if (other.gameObject.tag == "StartingLine")
        {
            startingLine = true;
        }

        //FinishLine
        if (other.gameObject.tag == "FinishLine")
        {
            startingLine = false;
            finishMessage.SetActive(true);
            Time.timeScale = 0f;
            player.gameObject.SetActive(false);
            amongPlayer.gameObject.SetActive(false);
            bearPlayer.gameObject.SetActive(false);
            gacPlayer.gameObject.SetActive(false);
            dadPlayer.gameObject.SetActive(false);
            plaguePlayer.gameObject.SetActive(false);
            currentTime = currentTime * 100;
            Settings.time = (int)currentTime;
            playfabManager.SendTimeLeaderboard(Settings.time);
            finishSound.Play();
        }

        //Killbox collision
        if (other.gameObject.tag == "killbox")
        {
            startingLine = false;
            currentTime = 0;
            timeText.text = ("0");
            if (Settings.recks == true)
            {
                beeSound.Stop();
            }
            if (Settings.tokenNum >= 1)
            {
                Settings.slotBG = true;
                SceneManager.LoadScene(slotMachine);
                Cursor.visible = true;
            }
            else
            {
                if (Settings.soundFXBool == true)
                {
                    deathSound.Play();
                }
                theGameManager.RestartGame();

                if (Settings.apeGang == true)
                {
                    playfabManager.SendApeGangLeaderboard(Settings.points);
                }
                if (Settings.brawlerBears == true)
                {
                    playfabManager.SendBrawlerBearsLeaderboard(Settings.points);
                }
                if (Settings.cryptoDads == true)
                {
                    playfabManager.SendCryptoDadsLeaderboard(Settings.points);
                }
                if (Settings.gamingApeClub == true)
                {
                    playfabManager.SendGamingApeClubLeaderboard(Settings.points);
                }
                if (Settings.hikeshi == true)
                {
                    playfabManager.SendHikeshiLeaderboard(Settings.points);
                }
                if (Settings.spaceRiders == true)
                {
                    playfabManager.SendSpaceRidersLeaderboard(Settings.points);
                }
                if (Settings.tacoTribe == true)
                {
                    playfabManager.SendTacoTribeLeaderboard(Settings.points);
                }
                if (Settings.thePlague == true)
                {
                    playfabManager.SendThePlagueLeaderboard(Settings.points);
                }
                else if (Settings.apeGang == false && Settings.brawlerBears == false && Settings.cryptoDads == false && Settings.gamingApeClub == false && Settings.spaceRiders == false && Settings.tacoTribe == false && Settings.thePlague == false)
                {
                    playfabManager.SendLeaderboard(Settings.points);
                }
                playfabManager.SaveTotalPoints();
                playfabManager.SaveCoins();
                playfabManager.SaveParachute();
            }
        }
    }
    /*
    private IEnumerator Pulse()
    {
        for (float i = 1f; i <= 1.1f; i += 0.05f)
        {
            scoreText.rectTransform.localScale = new Vector3(i, i, i);
            yield return new WaitForEndOfFrame();

        }
        scoreText.rectTransform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
        if (Settings.easy == true)
        {
            scoreText.color = new Color(0, 255, 0, 255);
            Settings.points = 101;
        }
        else if (Settings.easy == false)
        {
            theScoreManager.AddScore(scoreToGive);
        }

        for (float i = 1.1f; i >= 1f; i -= 0.05f)
        {
            scoreText.rectTransform.localScale = new Vector3(i, i, i);
            yield return new WaitForEndOfFrame();
        }
        scoreText.rectTransform.localScale = new Vector3(1f, 1f, 1f);
        scoreText.color = new Color(255, 255, 255, 255);
    }

    private IEnumerator PulseParachute()
    {
        for (float i = 1f; i <= 1.1f; i += 0.05f)
        {
            scoreText.rectTransform.localScale = new Vector3(i, i, i);
            yield return new WaitForEndOfFrame();

        }
        scoreText.rectTransform.localScale = new Vector3(1.1f, 1.1f, 1.1f);

        if (Settings.easy == true)
        {
            scoreText.color = new Color(0, 255, 0, 255);
            Settings.points = 101;
        }
        else if (Settings.easy == false)
        {
            theScoreManager.AddScore(scoreToGive * 5);
        }

        for (float i = 1.1f; i >= 1f; i -= 0.05f)
        {
            scoreText.rectTransform.localScale = new Vector3(i, i, i);
            yield return new WaitForEndOfFrame();
        }
        scoreText.rectTransform.localScale = new Vector3(1f, 1f, 1f);
        scoreText.color = new Color(255, 255, 255, 255);
    }

    private IEnumerator PulseFrg()
    {
        for (float i = 1f; i <= 1.1f; i += 0.05f)
        {
            scoreText.rectTransform.localScale = new Vector3(i, i, i);
            yield return new WaitForEndOfFrame();

        }
        scoreText.rectTransform.localScale = new Vector3(1.1f, 1.1f, 1.1f);

        theScoreManager.AddScore(scoreToGive * 2);

        for (float i = 1.1f; i >= 1f; i -= 0.05f)
        {
            scoreText.rectTransform.localScale = new Vector3(i, i, i);
            yield return new WaitForEndOfFrame();
        }
        scoreText.rectTransform.localScale = new Vector3(1f, 1f, 1f);
    }

    private IEnumerator PulseRocket()
    {
        for (float i = 1f; i <= 1.1f; i += 0.05f)
        {
            rocket.rectTransform.localScale = new Vector3(i, i, i);
            yield return new WaitForEndOfFrame();

        }
        rocket.rectTransform.localScale = new Vector3(1.1f, 1.1f, 1.1f);

        for (float i = 1.1f; i >= 1f; i -= 0.05f)
        {
            rocket.rectTransform.localScale = new Vector3(i, i, i);
            yield return new WaitForEndOfFrame();
        }
        rocket.rectTransform.localScale = new Vector3(1f, 1f, 1f);
    }

    private IEnumerator PulseCrown()
    {
        for (float i = 1f; i <= 1.1f; i += 0.05f)
        {
            crown.rectTransform.localScale = new Vector3(i, i, i);
            yield return new WaitForEndOfFrame();

        }
        crown.rectTransform.localScale = new Vector3(1.1f, 1.1f, 1.1f);

        for (float i = 1.1f; i >= 1f; i -= 0.05f)
        {
            crown.rectTransform.localScale = new Vector3(i, i, i);
            yield return new WaitForEndOfFrame();
        }
        crown.rectTransform.localScale = new Vector3(1f, 1f, 1f);
    }

    private IEnumerator PulseNinjaStar()
    {
        for (float i = 1f; i <= 1.1f; i += 0.05f)
        {
            ninjaStarText.rectTransform.localScale = new Vector3(i, i, i);
            yield return new WaitForEndOfFrame();

        }
        ninjaStarText.rectTransform.localScale = new Vector3(1.1f, 1.1f, 1.1f);

        for (float i = 1.1f; i >= 1f; i -= 0.05f)
        {
            ninjaStarText.rectTransform.localScale = new Vector3(i, i, i);
            yield return new WaitForEndOfFrame();
        }
        ninjaStarText.rectTransform.localScale = new Vector3(1f, 1f, 1f);
    }

    private IEnumerator PulsePipeScore()
    {
        for (float i = 1f; i <= 1.1f; i += 0.05f)
        {
            scoreText.rectTransform.localScale = new Vector3(i, i, i);
            yield return new WaitForEndOfFrame();

        }
        scoreText.rectTransform.localScale = new Vector3(1.1f, 1.1f, 1.1f);

        theScoreManager.AddScore(scoreToGive * 10);

        for (float i = 1.1f; i >= 1f; i -= 0.05f)
        {
            scoreText.rectTransform.localScale = new Vector3(i, i, i);
            yield return new WaitForEndOfFrame();
        }
        scoreText.rectTransform.localScale = new Vector3(1f, 1f, 1f);
    }

    private IEnumerator PulseBattery()
    {
        for (float i = 1f; i <= 1.1f; i += 0.05f)
        {
            batteryText.rectTransform.localScale = new Vector3(i, i, i);
            yield return new WaitForEndOfFrame();

        }
        batteryText.rectTransform.localScale = new Vector3(1.1f, 1.1f, 1.1f);

        for (float i = 1.1f; i >= 1f; i -= 0.05f)
        {
            batteryText.rectTransform.localScale = new Vector3(i, i, i);
            yield return new WaitForEndOfFrame();
        }
        batteryText.rectTransform.localScale = new Vector3(1f, 1f, 1f);
    }

    private IEnumerator PulsePillow()
    {
        for (float i = 1f; i <= 1.1f; i += 0.05f)
        {
            pillowText.rectTransform.localScale = new Vector3(i, i, i);
            yield return new WaitForEndOfFrame();

        }
        pillowText.rectTransform.localScale = new Vector3(1.1f, 1.1f, 1.1f);

        for (float i = 1.1f; i >= 1f; i -= 0.05f)
        {
            pillowText.rectTransform.localScale = new Vector3(i, i, i);
            yield return new WaitForEndOfFrame();
        }
        pillowText.rectTransform.localScale = new Vector3(1f, 1f, 1f);
    }

    private IEnumerator LevelEndScore()
    {
        for (float i = 1f; i <= 1.1f; i += 0.05f)
        {
            scoreText.rectTransform.localScale = new Vector3(i, i, i);
            yield return new WaitForEndOfFrame();

        }
        scoreText.color = new Color(0, 255, 0, 255);
        scoreText.rectTransform.localScale = new Vector3(1.1f, 1.1f, 1.1f);



        theScoreManager.AddScore(scoreToGive * 25);

        for (float i = 1.5f; i >= 1f; i -= 0.05f)
        {
            scoreText.rectTransform.localScale = new Vector3(i, i, i);
            yield return new WaitForEndOfFrame();
        }
        scoreText.rectTransform.localScale = new Vector3(1f, 1f, 1f);
        scoreText.color = new Color(255, 255, 255, 255);
    }*/
}

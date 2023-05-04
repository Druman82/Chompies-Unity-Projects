using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] LayerMask groundLayers;
    [SerializeField] public float runSpeed = 1f;
    [SerializeField] private float jumpHeight = 2f;
    [SerializeField] private Transform[] groundChecks;
    [SerializeField] private Transform[] wallChecks;
    [SerializeField] private Transform glasses;
    [SerializeField] private Transform light;
    [SerializeField] private Transform houseLight1;
    [SerializeField] private Transform houseLight2;
    [SerializeField] private Transform houseLight3;
    [SerializeField] private Transform sunLight;
    [SerializeField] private Transform moonLight;
    [SerializeField] public Transform parachute;
    [SerializeField] public Transform red;
    [SerializeField] public Transform blue;
    [SerializeField] public Transform plane;
    [SerializeField] public Transform planeNight;

    public float gravity = -50f;
    private CharacterController characterController;
    public Vector3 velocity;
    public bool isGrounded;
    public float horizontalInput;
    private Animator animator;
    public bool jumpPressed;
    public bool mousePressed;
    private float jumpTimer;
    private float jumpGracePeriod = 0.2f;
    public GameManager theGameManager;
    public float speedMultiplier;
    public float speedIncreaseMilestone;
    public float speedMilestoneCount;
    private ScoreManager theScoreManager;
    public HighScores highScores;
    public int scoreToGive;
    public int superJumpsRemaining;
    private float jumpPower;
    public float jumpCount;
    public float jumpTime;
    private float jumpTimeCounter;
    public Camera theCamera;
    public PauseMenu pauseMenu;
    public AudioSource coinSound;
    public AudioSource parachuteSound;
    public AudioSource jumpSound;
    public AudioSource deathSound;
    public AudioSource recordScratch;
    public AudioSource backgroundMusic2D;
    public AudioSource backgroundMusic3D;
    public AudioSource backgroundMusicNight;
    public AudioSource houseNoise;
    private bool jumping;
    public InputField memberID;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        backgroundMusic2D.Play();
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        speedMilestoneCount = speedIncreaseMilestone;
        theScoreManager = FindObjectOfType<ScoreManager>();
        jumpTimeCounter = jumpTime;
        jumpCount = 0;
        jumpPower = -2f;
    }


    // Update is called once per frame
    void Update()
    {
        horizontalInput = 1;

        transform.forward = new Vector3(horizontalInput, 0, Mathf.Abs(horizontalInput) - 1);

        isGrounded = false;

        // Speed increase
        if (transform.position.x > speedMilestoneCount)
        {
            speedMilestoneCount += speedIncreaseMilestone;

            speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;

            runSpeed = runSpeed * speedMultiplier;
        }
        // Ground checking
        foreach (var groundCheck in groundChecks)
        {
            if (Physics.CheckSphere(groundCheck.position, 0.1f, groundLayers, QueryTriggerInteraction.Ignore))
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
            parachute.gameObject.SetActive(false);
            gravity = -50f;
            jumpPower = -2f;
        }
        mousePressed = Input.GetMouseButtonDown(0);

        jumpPressed = Input.GetKey(KeyCode.Space);
        if (jumpPressed || mousePressed)
        {/*
            if (superJumpsRemaining > 0)
            {
                parachuteSound.Play();
                jumpPower *= .3f;
                gravity = -15f;
                velocity.y += Mathf.Sqrt(jumpHeight * jumpPower * gravity);
                superJumpsRemaining--;
            }*/
            if (superJumpsRemaining == 0)
            {
                jumpPower = -2f;

            }
            jumpTimer = Time.time;
            if (jumpTimer > 5)
            {
                jumpTimer = jumpTime;
            }
        }

        if (superJumpsRemaining == 0 && (!jumpPressed || mousePressed))
        {
            parachute.gameObject.SetActive(false);
            //gravity = -50f;
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

            if (isGrounded && jumping && (mousePressed || jumpPressed || (jumpTimer > 0 && Time.time < jumpTimer + jumpGracePeriod)))
        {
            velocity.y += Mathf.Sqrt(jumpHeight * jumpPower * gravity);

            jumpSound.Play();
            jumpTimer = -1;
        }
        

        characterController.Move(velocity * Time.deltaTime);

        animator.SetFloat("Speed", horizontalInput);

        animator.SetBool("IsGrounded", isGrounded);

        animator.SetFloat("VerticalSpeed", velocity.y);

    }
    public IEnumerator Colors()
    {
        yield return new WaitForSeconds(0.2f);
        theCamera.orthographic = false;
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            other.gameObject.SetActive(false);
            theScoreManager.AddScore(scoreToGive);
            coinSound.Play();
        }

        if (other.gameObject.layer == 9)
        {
            other.gameObject.SetActive(false);
            parachuteSound.Play();
            jumpPower *= .3f;
            gravity = -20f;
            velocity.y += Mathf.Sqrt(jumpHeight * jumpPower * gravity);
            parachute.gameObject.SetActive(true);
            superJumpsRemaining++;
            theScoreManager.AddScore(scoreToGive * 5);
            jumpSound.Play();
        }

        if (other.gameObject.layer == 11)
        {
            other.gameObject.SetActive(false);
            glasses.gameObject.SetActive(true);
            backgroundMusic2D.Stop();
            recordScratch.Play();
            red.gameObject.SetActive(true);
            StartCoroutine("Colors");
            StartCoroutine("ChangeBackgroundSong");
        }

        if(other.gameObject.layer == 13)
        {
            theScoreManager.AddScore(scoreToGive * 10);
            houseNoise.Play();
            if (light.gameObject.activeSelf)
            {
                moonLight.gameObject.SetActive(true);
                light.gameObject.SetActive(false);
                sunLight.gameObject.SetActive(false);
                houseLight1.gameObject.SetActive(true);
                houseLight2.gameObject.SetActive(true);
                houseLight3.gameObject.SetActive(true);
                planeNight.gameObject.SetActive(true);
                plane.gameObject.SetActive(false);
                backgroundMusic2D.Stop();
                backgroundMusic3D.Stop();
                backgroundMusicNight.Play();
            }
            else
            {
                light.gameObject.SetActive(true);
                sunLight.gameObject.SetActive(true);
                moonLight.gameObject.SetActive(false);
                plane.gameObject.SetActive(true);
                houseLight1.gameObject.SetActive(false);
                houseLight2.gameObject.SetActive(false);
                houseLight3.gameObject.SetActive(false);
                planeNight.gameObject.SetActive(false);
                backgroundMusicNight.Stop();
                backgroundMusic3D.Play();
            }
        }

        if (other.gameObject.tag == "killbox")
        {
            deathSound.Play();
            //HighScores.UploadScore(memberID.text, theScoreManager.highScoreCount);
            PlayfabManager.SendLeaderboard(theScoreManager.highScoreCount)
            theGameManager.RestartGame();
        }
    }

}

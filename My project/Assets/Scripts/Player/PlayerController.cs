


using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    PlayerInput playerInput;
    PlayerInput.MainActions input;

    CharacterController controller;
    Animator animator;

    AudioSource audioSource;


    [Header("Speeds")]
    float moveSpeed = 5;
    public float walkSpeed = 5, crouchSpeed = 2, slideSpeed = 10, AirSpeed = 2;


    [Header("Sprint")]
    public float sprintSpeed = 10;

    private bool sprintingOnCooldown = false;
    private bool isTimerTicking = false;
    private float remainingTime;
    public float sprintDuration = 5;
    public float sprintCooldown = 50;
    public TextMeshProUGUI sprintTimerText;


    [Header("FOV")]
    public float walkFOV = 70;
    public float crouchFOV = 60;
    public float sprintFOV = 80;

    private float fieldOfView;

    [Header("KeyBinds")]

    public KeyCode sprintKey = KeyCode.R;
    public KeyCode crouchKey = KeyCode.LeftShift;
    public KeyCode slideKey = KeyCode.C;

    [Header("Height Settings")]
    public float crouchHeight = 1f;
    public float standHeight = 2f;

    [Header("Player Settings")]

    public UnityEngine.Rendering.PostProcessing.PostProcessVolume postProcessVolume;


    public float gravity = -9.8f;
    public float jumpHeight = 1.2f;


    [Header("Audio")]

    public AudioClip jumpSound;
    public GameObject footstepSound;
    public AudioClip slideSound;
    public GameObject sprintSound;

    bool groundHit = false;


    [Header("Slide Settings")]
    public bool sliding = false;
    public float slideForce = 10f;
    public float slideDuration = 1f;
    public float slideTime = 1f;

    [Header("Camera Settings")]

    public bool lockCamera = false;
    public bool lockMovement = false;
    public bool lockAttack = false;

    Vector3 _PlayerVelocity;
    bool isGrounded;

    [Header("Camera")]
    public Camera cam;
    public float sensitivity;
    float xRotation = 0f;


    void Awake()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        audioSource = GetComponent<AudioSource>();
        playerInput = new PlayerInput();
        input = playerInput.Main; // Properly initialize the input variable
        jumpSound = Resources.Load<AudioClip>("Player/Jumping1");
        slideSound = Resources.Load<AudioClip>("Player/Sliding1");
        postProcessVolume = FindObjectOfType<UnityEngine.Rendering.PostProcessing.PostProcessVolume>();
        AssignInputs();
        //footstepSound = GameObject.Find("FootstepSounds");
        //sprintSound = GameObject.Find("SprintSound");

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Start()
    {
        remainingTime = sprintDuration;
        fieldOfView = walkFOV;
    }
    void Update()
    {
        // Check if the player is grounded
        isGrounded = controller.isGrounded;


        // Play sound when touching the ground

        // Check the velocity of the player in the y direction

        // Repeat Inputs
        if (input.Attack.IsPressed())
        {
            if (lockAttack) return;
            Attack();

        }

        SetAnimations();
        SprintController();
        PlyerSound();

        if (Input.GetKeyDown(slideKey))
        {
            Slide();
        }
        CrouchHandler();

    }
    public float GetFieldOfView()
    {
        return fieldOfView;
    }

    public void SprintController()

    {
        UnityEngine.Rendering.PostProcessing.ChromaticAberration chromaticAberration;
        postProcessVolume.profile.TryGetSettings(out chromaticAberration);

        if (Input.GetKey(sprintKey) && !sprintingOnCooldown) // If the sprint key is pressed
        {
            moveSpeed = sprintSpeed;
            fieldOfView = sprintFOV;
            isTimerTicking = true;
            chromaticAberration.intensity.value = 1f;
            sprintSound.SetActive(true);

            //Debug.Log(remainingTime);

        }
        else if (Input.GetKeyUp(sprintKey))
        {
            sprintSound.SetActive(false);
            moveSpeed = walkSpeed;
            fieldOfView = walkFOV;
            chromaticAberration.intensity.value = 0.2f;


        }

        if (!sprintingOnCooldown && !Input.GetKey(sprintKey)) // If the sprint key is not pressed
        {
            isTimerTicking = false;
        }
        if (isTimerTicking)
        { // If the timer is ticking down, decrease the remaining time
            remainingTime -= Time.deltaTime;
        }

        if (remainingTime < 0) // If the timer has run out, toggle the sprintingOnCooldown boolean and reset the timer
        {
            remainingTime = 0;
            sprintingOnCooldown = !sprintingOnCooldown;
            if (sprintingOnCooldown)
            {
                remainingTime = sprintCooldown;
                moveSpeed = walkSpeed;
                fieldOfView = walkFOV;
                chromaticAberration.intensity.value = 0.2f;
            }
            else
            {
                remainingTime = sprintDuration;
                isTimerTicking = false;
            }
        }
        if (sprintTimerText != null)
        {
            UpdateSprintTimer();
        }




    }

    public void PlyerSound()
    {

        if (controller.velocity.y < -8f)
        {
            groundHit = true;
            Debug.Log(controller.velocity.y);
        }
        if (groundHit && isGrounded)
        {
            audioSource.PlayOneShot(jumpSound);
            groundHit = false;
        }


    }
    void UpdateSprintTimer()
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        sprintTimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void CrouchHandler()
    {
        if (Input.GetKey(crouchKey))
        {
            controller.height = crouchHeight;
            moveSpeed = crouchSpeed;
            fieldOfView = crouchFOV;
            _PlayerVelocity.y = -10f;

        }
        else if (Input.GetKeyUp(crouchKey))
        {
            // Handle crouch key release here
            controller.height = standHeight;
            moveSpeed = walkSpeed;
            fieldOfView = walkFOV;
        }

    }

    void Slide()
    {
        UnityEngine.Rendering.PostProcessing.ChromaticAberration chromaticAberration;

        postProcessVolume.profile.TryGetSettings(out chromaticAberration);
        audioSource.time = slideSound.length / 2; //
        audioSource.PlayOneShot(slideSound);
        StartCoroutine(SlideCoroutine());


        IEnumerator SlideCoroutine()
        {
            sliding = true;
            chromaticAberration.intensity.value = 1f;

            controller.Move(Vector3.zero * slideForce * Time.deltaTime);
            controller.height = crouchHeight;
            _PlayerVelocity.y = -10f;
            fieldOfView = walkFOV + 5;

            yield return new WaitForSeconds(slideDuration);
            chromaticAberration.intensity.value = 0.2f;
            controller.height = standHeight;
            sliding = false;
            fieldOfView = walkFOV;
            audioSource.Stop();

        }

    }

    void FixedUpdate()
    {
        if (!lockMovement)
        { MoveInput(input.Movement.ReadValue<Vector2>()); }
    }

    void LateUpdate()
    {
        if (!lockCamera)
        {
            LookInput(input.Look.ReadValue<Vector2>());
        }
    }



    void MoveInput(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;



        if (moveDirection.magnitude >= 1 && isGrounded && moveSpeed != crouchSpeed && !sliding && footstepSound != null)
        {
            footstepSound.SetActive(true);
        }
        else
        {
            footstepSound.SetActive(false);
        }


        if (!sliding)
        {
            controller.Move(transform.TransformDirection(moveDirection) * moveSpeed * Time.deltaTime);


        }
        else
        {
            controller.Move(transform.forward * slideSpeed * Time.deltaTime);
            if (controller.velocity.magnitude > 0.1f && isGrounded && !audioSource.isPlaying)
            {
                //audioSource.PlayOneShot(footstepSound);
            }
        }

        // Move the player in the direction they are facing 
        _PlayerVelocity.y += gravity * Time.deltaTime;
        if (isGrounded && _PlayerVelocity.y < 0) // If the player is grounded and the y velocity is less than 0 (falling)
            _PlayerVelocity.y = -2f;
        controller.Move(_PlayerVelocity * Time.deltaTime);

    }

    void LookInput(Vector3 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

        xRotation -= (mouseY * Time.deltaTime * sensitivity);
        xRotation = Mathf.Clamp(xRotation, -80, 80);

        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime * sensitivity));
    }

    void OnEnable()
    { input.Enable(); }

    void OnDisable()
    { input.Disable(); }

    void Jump()
    {
        // Adds force to the player rigidbody to jump
        if (isGrounded)
            _PlayerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
    }

    void AssignInputs()
    {
        input.Jump.performed += ctx => Jump();
        input.Attack.started += ctx => Attack();
    }

    // ---------- //
    // ANIMATIONS //
    // ---------- //

    public const string IDLE = "Idle";
    public const string WALK = "Walk";
    public const string ATTACK1 = "Attack 1";
    public const string ATTACK2 = "Attack 2";

    string currentAnimationState;

    public void ChangeAnimationState(string newState)
    {
        // STOP THE SAME ANIMATION FROM INTERRUPTING WITH ITSELF //
        if (currentAnimationState == newState) return;

        // PLAY THE ANIMATION //
        currentAnimationState = newState;
        animator.CrossFadeInFixedTime(currentAnimationState, 0.2f);
    }

    void SetAnimations()
    {
        // If player is not attacking
        if (!attacking)
        {
            if (_PlayerVelocity.x == 0 && _PlayerVelocity.z == 0)
            { ChangeAnimationState(IDLE); }
            else
            { ChangeAnimationState(WALK); }
        }
    }

    // ------------------- //
    // ATTACKING BEHAVIOUR //
    // ------------------- //

    [Header("Attacking")]
    public float attackDistance = 3f;
    public float attackDelay = 0.4f;
    public float attackSpeed = 1f; //
    public int attackDamage = 1;
    public LayerMask attackLayer;


    public AudioClip swordSwing;
    public AudioClip hitSound;

    bool attacking = false;
    public bool readyToAttack = true;
    int attackCount;

    public void Attack()
    {
        if (!readyToAttack || attacking) return;

        readyToAttack = false;
        attacking = true;


        Invoke(nameof(ResetAttack), attackSpeed);
        Invoke(nameof(AttackRaycast), attackDelay);

        audioSource.pitch = Random.Range(0.9f, 1.1f);
        audioSource.PlayOneShot(swordSwing);

        if (attackCount == 0)
        {
            ChangeAnimationState(ATTACK1);
            attackCount++;
        }
        else
        {
            ChangeAnimationState(ATTACK2);
            attackCount = 0;
        }
    }

    void ResetAttack()
    {
        attacking = false;
        readyToAttack = true;
    }

    void AttackRaycast()
    {

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit, attackDistance, attackLayer))
        {
            HitTarget(hit.point);

            Vector3 direction = transform.TransformDirection(Vector3.forward); // Direction the player is facing
            if (hit.transform != null)
            {
                Transform targetTransform = hit.transform;
                Debug.Log(targetTransform.name);
            }
            if (hit.transform.TryGetComponent<Actor>(out Actor T)) // If the object has an Actor component

            { T.TakeDamage(attackDamage, direction); }
        }
    }

    void HitTarget(Vector3 pos)
    {

        audioSource.pitch = 1;
        audioSource.PlayOneShot(hitSound);

        //GameObject GO = Instantiate(hitEffect, pos, Quaternion.identity);
        //Destroy(GO, 20);
    }
}
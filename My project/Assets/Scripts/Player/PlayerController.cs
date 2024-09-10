
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
    public float walkSpeed = 5, crouchSpeed = 2, crawlSpeed = 1, slideSpeed = 10;

    [Header("Sprint")]
    public float sprintSpeed = 10;
    public float sprintFOV = 80;
    public float walkFOV = 70;
    public float crouchFOV = 60;


    public float sprintDuration = 5;
    public float sprintCooldown = 50;

    private bool sprintingOnCooldown = false;
    private float remainingTime;

    [Header("KeysBinds")]

    public KeyCode crouchKey = KeyCode.LeftShift;

    [Header("Player Settings")]
    public float crouchHeight = 1f;
    public float standHeight = 2f;
    public float crawlFOV = 40;
    public float slideTime = 1f;
    public float gravity = -9.8f;
    public float jumpHeight = 1.2f;

    public float backwardForce = 5f;

    public TextMeshProUGUI sprintTimerText;

    Vector3 _PlayerVelocity;

    bool isGrounded;

    [Header("Camera")]
    public Camera cam;
    public float sensitivity;
    float xRotation = 0f;

    void Start()
    {
      
    }

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        audioSource = GetComponent<AudioSource>();

        playerInput = new PlayerInput();
        input = playerInput.Main;
        AssignInputs();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        isGrounded = controller.isGrounded;

        // Repeat Inputs
        if (input.Attack.IsPressed())
        { Attack(); }

        SetAnimations();

        

        /* if (Input.GetKeyDown(KeyCode.R) && !sprintingOnCooldown)
        {
            moveSpeed = sprintSpeed;
            cam.fieldOfView = sprintFOV;
            remainingTime = sprintDuration;
        }
        if (sprintingOnCooldown)
        {
            moveSpeed = walkSpeed;
            cam.fieldOfView = walkFOV;
            remainingTime = sprintCooldown;
        }
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime < 0)
        {
            remainingTime = 0;
            sprintingOnCooldown = !sprintingOnCooldown;
        }
        if  (sprintTimerText != null)
        {
            UpdateSprintTimer();
        } */

        if (Input.GetKeyDown(KeyCode.C)) {
            Slide();
        }
        else if (Input.GetKey(crouchKey)) {
            Crouch();
        } else {
            controller.height = standHeight;
            moveSpeed = walkSpeed;
            cam.fieldOfView = walkFOV;
        }
        


    }
    void UpdateSprintTimer()
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        sprintTimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void Crouch() {
        controller.height = crouchHeight;
        moveSpeed = crouchSpeed;
    }

    void Slide(){
        

    }

    void FixedUpdate()
    { 
        MoveInput(input.Movement.ReadValue<Vector2>());
         }

    void LateUpdate()
    { LookInput(input.Look.ReadValue<Vector2>()); }



    void MoveInput(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;

        controller.Move(transform.TransformDirection(moveDirection) * moveSpeed * Time.deltaTime);
        _PlayerVelocity.y += gravity * Time.deltaTime;
        if (isGrounded && _PlayerVelocity.y < 0)
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
    public float attackSpeed = 1f;
    public int attackDamage = 1;
    public LayerMask attackLayer;

    public GameObject hitEffect;
    public AudioClip swordSwing;
    public AudioClip hitSound;

    bool attacking = false;
    bool readyToAttack = true;
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

        GameObject GO = Instantiate(hitEffect, pos, Quaternion.identity);
        Destroy(GO, 20);
    }
}
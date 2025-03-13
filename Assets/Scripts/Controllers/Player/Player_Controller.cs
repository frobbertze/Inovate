using Assets.Scripts;
using Assets.Scripts.StateMachine.PlayerStateMachine;
using Mono.Cecil;
using Unity.Properties;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Controller : MonoBehaviour
{


    private PlayerMovementStateManager _playerMovementStateManager;

    //public Rigidbody2D RB;

    [Header("Player Controller")]
    //[SerializeField] PlayerActionStatus currentActionStatus = PlayerActionStatus.IDLE;
    private Vector2 velocity;
    private Vector2 allvelocity;
    private Vector2 frontvelocity;



    [SerializeField] 
    PlayerDataModel PlayerData;
    [SerializeField]
    InputActionReference PlayerActionRefrence;
    [SerializeField]
    private Transform _groundCheckPoint;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private Vector2 _groundCheckSize = new Vector2(0.49f, 0.03f);


    private void Awake()
    {


        PlayerData = GetComponent<PlayerDataModel>();


        _playerMovementStateManager = gameObject.GetComponent<PlayerMovementStateManager>();

    }
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {

        PlayerData.yInput = Input.GetAxis("Vertical");
        PlayerData.xInput = Input.GetAxis("Horizontal");

        HandleCollision();

        HandleInput();


        _playerMovementStateManager.Update();



        //HandleAnimation();

        MoveMainCameraWithPlayer();

    }


    private void HandleCollision()
    {
        //_isGrounded = Physics2D.Raycast(transform.position, Vector2.down, _groundCheckDistance, whatIsGround);
        //bool ray1Hit = Physics2D.Raycast(transform.position, new Vector2(PlayerData.GetFacingDirection(),transform.position.y), PlayerData.WallCheckDistance, PlayerData.WhatIsGround);
        //bool ray2Hit = Physics2D.Raycast(transform.position, new Vector2(PlayerData.GetFacingDirection(), transform.position.y - 1.35f), PlayerData.WallCheckDistance, PlayerData.WhatIsGround);
        //bool ray3Hit = Physics2D.Raycast(transform.position, new Vector2(PlayerData.GetFacingDirection(), transform.position.y + 0.5f), PlayerData.WallCheckDistance, PlayerData.WhatIsGround);


        //Debug.Log("Ray1Hit: " + ray1Hit);
        //Debug.Log("Ray2Hit: " + ray2Hit);
        //Debug.Log("Ray3Hit: " + ray3Hit);

        if (Physics2D.OverlapBox(_groundCheckPoint.position, _groundCheckSize, 0, _groundLayer)) //checks if set box overlaps with ground
        {
            PlayerData.IsGrounded = true;
        }
        else
        {
            PlayerData.IsGrounded = false;
        }
        //if (ray1Hit || ray2Hit || ray3Hit)
        //{
        //    PlayerData.IsWallDetected = true;
        //}
        //else
        //{
        //    PlayerData.IsWallDetected = false;
        //}

        //Vector3 wallCheck = new Vector3(PlayerData.transform.position.x + PlayerData.GetFacingDirection() * PlayerData.WallCheckDistance, PlayerData.transform.position.y);
        //Gizmos.DrawLine(transform.position, wallCheck);

        //wallCheck = new Vector3(PlayerData.transform.position.x + PlayerData.GetFacingDirection() * PlayerData.WallCheckDistance, PlayerData.transform.position.y - 1.35f);
        //Gizmos.DrawLine(transform.position, wallCheck);

        //wallCheck = new Vector3(PlayerData.transform.position.x + PlayerData.GetFacingDirection() * PlayerData.WallCheckDistance, PlayerData.transform.position.y + 0.5f);
        //Gizmos.DrawLine(transform.position, wallCheck);

    }




    private void HandleInput()
    {
        PlayerData.PlayerTransForm.Translate(Vector3.right * PlayerData.xInput * PlayerData.GetFacingDirection() * Time.deltaTime * PlayerData.WalkSpeed);
        allvelocity = PlayerData.RB.linearVelocity;
       
        var useGamepad = false;
        if (Gamepad.current != null)
        {
            useGamepad = true;
        }
        PlayerData.isRunning = Keyboard.current.leftShiftKey.isPressed || Keyboard.current.rightShiftKey.isPressed || (useGamepad && Gamepad.current.bButton.isPressed);
        PlayerData.isJumping =  Keyboard.current.spaceKey.wasPressedThisFrame || (useGamepad && Gamepad.current.aButton.wasPressedThisFrame);
        if (PlayerData.isJumping)
        {
            var speed = PlayerData.WalkSpeed;
            if (PlayerData.isRunning)
            {
                speed = PlayerData.RunSpeed;
            }
            float force = PlayerData.JumpPower;
            if (PlayerData.RB.linearVelocity.y < 0)
                force -= PlayerData.RB.linearVelocity.y;

            PlayerData.RB.AddForce(Vector2.up * (force ), ForceMode2D.Impulse);

            //PlayerData.RB.AddForce(new Vector2(PlayerData.RB.linearVelocity.x, PlayerData.JumpPower));
            //PlayerData.RB.AddForce(Vector3.up * PlayerData.JumpPower,ForceMode2D.Impulse);
            velocity = PlayerData.RB.linearVelocity;
        }
    
        PlayerData.isCrouching = Keyboard.current.leftCtrlKey.isPressed || Keyboard.current.rightCtrlKey.isPressed || (useGamepad && Gamepad.current.leftTrigger.isPressed);

        //if (xInput == 0 && isJumping == false && _isGrounded && isCrouching == false)
        //{
        //    HandlePlayerIdle();

        //    return;
        //}

        //if (xInput != 0 && _isGrounded && !_isWallDetected)
        //{
        //    HandlePlayerMovement(xInput, isRunning);


        //}

        //if (xInput == 0 && _isGrounded && isCrouching)
        //{
        //    HandlePlayerCrouch();
        //}

        //if (isJumping && _isGrounded)
        //{
        //    HandlePlayerJump(xInput);

        //    return;

        //}

        //if (!isJumping && !_isGrounded && currentActionStatus != PlayerActionStatus.WALK && currentActionStatus != PlayerActionStatus.RUN)
        //{

        //    currentActionStatus = PlayerActionStatus.FALL;

        //    return;
        //}



    }

    private void HandlePlayerJump(float xInput)
    {

        float _speed;

        //if ((int)currentActionStatus == 15)
        //{
        //    _speed = _runSpeed;
        //}
        //else
        //{
        //    _speed = WalkSpeed;
        //}

        //currentActionStatus = PlayerActionStatus.JUMP;

        //RB.linearVelocity = new Vector2(xInput * _speed, _jumpPower);

    }

    private void HandlePlayerCrouch()
    {

        //currentActionStatus = PlayerActionStatus.CROUCH;

    }

    private void HandlePlayerCrouchWalk()
    {

        //currentActionStatus = PlayerActionStatus.CROUCH_WALK;

    }

    private void HandlePlayerIdle()
    {
        //currentActionStatus = PlayerActionStatus.IDLE;
        //HandleAnimation();
    }

    private void HandlePlayerMovement(float xInput, bool isRunning)
    {
        //currentActionStatus = isRunning ? PlayerActionStatus.RUN : PlayerActionStatus.WALK;

        //float speed = isRunning ? _runSpeed : WalkSpeed;

        //transform.Translate(Vector3.right * xInput * GetFacingDirection() * Time.deltaTime * speed);

        //if (ShouldFlip(xInput))
        //{
        //    FlipPlayer();
        //}
    }

    private void MoveMainCameraWithPlayer()
    {
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z);
    }






    private void OnCollisionEnter2D(Collision2D collision)
    {
        //_playerMovementStateManager.OnCollisionEnter2D(collision);

        if (collision.otherCollider is CapsuleCollider2D)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                PlayerData.IsGrounded = true;
            }
            
        }


        //if (collision.otherCollider is BoxCollider2D)
        //{
            
        //}

      

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //_playerMovementStateManager.OnCollisionExit2D(collision);

        if (collision.otherCollider is CapsuleCollider2D)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                PlayerData.IsGrounded = false;
            }

        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //_playerMovementStateManager.OnTriggerEnter2D(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //_playerMovementStateManager.OnTriggerExit2D(collision);
    }
}



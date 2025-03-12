using Assets.Scripts;
using Assets.Scripts.StateMachine.PlayerStateMachine;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{


    private PlayerMovementStateManager _playerMovementStateManager;

    //public Rigidbody2D RB;

    [Header("Player Controller")]
    //[SerializeField] PlayerActionStatus currentActionStatus = PlayerActionStatus.IDLE;
   
   

    [Header("OnDrawGizmos")]
    [SerializeField] private float _wallCheckDistance = 0.65f;
    [SerializeField] private float _groundCheckDistance = 0.5f;

    [SerializeField] PlayerDataModel PlayerData;


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

        //MoveMainCameraWithPlayer();

    }


    private void HandleCollision()
    {
        //_isGrounded = Physics2D.Raycast(transform.position, Vector2.down, _groundCheckDistance, whatIsGround);
        PlayerData.IsWallDetected = Physics2D.Raycast(transform.position, Vector2.right * PlayerData.GetFacingDirection(), _wallCheckDistance, PlayerData.WhatIsGround);

    }


  

    private void HandleInput()
    {

         PlayerData.isRunning = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
         PlayerData.isJumping = Input.GetKey(KeyCode.Space);
         PlayerData.isCrouching = Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl);

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

   
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Vector3 wallCheck = new Vector3(transform.position.x + (_wallCheckDistance * PlayerData.GetFacingDirection()), transform.position.y, transform.position.z);
        //Gizmos.DrawLine(new Vector3(transform.position.x, transform.position.y, transform.position.z), wallCheck);


        //Gizmos.color = Color.blue;
        //Vector3 groundCheck = new Vector3(transform.position.x, transform.position.y - _groundCheckDistance, transform.position.z);
        //Gizmos.DrawLine(transform.position, groundCheck);


    }

   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //_playerMovementStateManager.OnCollisionEnter2D(collision);

        if (collision.gameObject.CompareTag("Ground"))
        {
            PlayerData.IsGrounded = true;
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //_playerMovementStateManager.OnCollisionExit2D(collision);

        if (collision.gameObject.CompareTag("Ground"))
        {
            PlayerData.IsGrounded = false;
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



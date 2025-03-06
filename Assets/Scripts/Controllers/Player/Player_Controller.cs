using Assets.Scripts.Enums;
using System;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{

    Rigidbody2D _rigidBody2D;

    [Header("Player Controller")]
    [SerializeField] PlayerActionStatus currentActionStatus = PlayerActionStatus.IDLE;
    [SerializeField] FacingDirection _facingDirection = FacingDirection.RIGHT;
    [SerializeField] float _walkSpeed = 5f;
    [SerializeField] float _runSpeed = 8f;
    [SerializeField] float _jumpPower = 3f;
    [SerializeField] bool _isGrounded = true;
    [SerializeField] bool _isWallDetected;
    [SerializeField] LayerMask whatIsGround;
    [SerializeField] Player_AC _playerAnimationController;


    [Header("OnDrawGizmos")]
    [SerializeField] private float _wallCheckDistance = 0.65f;
    [SerializeField] private float _groundCheckDistance = 0.5f;

    private void Awake()
    {

        _playerAnimationController = GetComponent<Player_AC>();
        _rigidBody2D = GetComponent<Rigidbody2D>();


    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        HandleCollision();

        HandleInput();
        HandleAnimation();

        MoveMainCameraWithPlayer();

    }


    private void HandleCollision()
    {
        //_isGrounded = Physics2D.Raycast(transform.position, Vector2.down, _groundCheckDistance, whatIsGround);
        _isWallDetected = Physics2D.Raycast(transform.position, Vector2.right * GetFacingDirection(), _wallCheckDistance, whatIsGround);

    }


    private void HandleAnimation()
    {

        _playerAnimationController.SetAnimationForAction(currentActionStatus);
    }

    private void HandleInput()
    {
        float yInput = Input.GetAxis("Vertical");
        float xInput = Input.GetAxis("Horizontal");
        bool isRunning = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        bool isJumping = Input.GetKey(KeyCode.Space);
        bool isCrouching = Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl);

        if (xInput == 0 && isJumping == false && _isGrounded && isCrouching == false)
        {
            HandlePlayerIdle();

            return;
        }

        if (xInput != 0 && _isGrounded && !_isWallDetected)
        {
            HandlePlayerMovement(xInput, isRunning);


        }

        if(xInput == 0 && _isGrounded && isCrouching)
        {
            HandlePlayerCrouch();
        }

        if (isJumping && _isGrounded)
        {
            HandlePlayerJump(xInput);

            return;

        }

        if (!isJumping && !_isGrounded && currentActionStatus != PlayerActionStatus.WALK && currentActionStatus != PlayerActionStatus.RUN)
        {

            currentActionStatus = PlayerActionStatus.FALL;

            return;
        }



    }

    private void HandlePlayerJump(float xInput)
    {

        float _speed;

        if ((int)currentActionStatus == 15)
        {
            _speed = _runSpeed;
        }
        else
        {
            _speed = _walkSpeed;
        }

        currentActionStatus = PlayerActionStatus.JUMP;

        _rigidBody2D.linearVelocity = new Vector2(xInput * _speed, _jumpPower);

    }

    private void HandlePlayerCrouch()
    {

        currentActionStatus = PlayerActionStatus.CROUCH;

    }

    private void HandlePlayerIdle()
    {
        currentActionStatus = PlayerActionStatus.IDLE;
        HandleAnimation();
    }

    private void HandlePlayerMovement(float xInput, bool isRunning)
    {
        currentActionStatus = isRunning ? PlayerActionStatus.RUN : PlayerActionStatus.WALK;

        float speed = isRunning ? _runSpeed : _walkSpeed;

        transform.Translate(Vector3.right * xInput * GetFacingDirection() * Time.deltaTime * speed);

        if (ShouldFlip(xInput))
        {
            FlipPlayer();
        }
    }

    private void MoveMainCameraWithPlayer()
    {
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z);
    }

    private bool ShouldFlip(float xInput)
    {
        return xInput > 0 && _facingDirection == FacingDirection.LEFT || xInput < 0 && _facingDirection == FacingDirection.RIGHT;
    }

    private void FlipPlayer()
    {
        _facingDirection = _facingDirection == FacingDirection.RIGHT ? FacingDirection.LEFT : FacingDirection.RIGHT;
        transform.Rotate(0f, 180f, 0f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 wallCheck = new Vector3(transform.position.x + (_wallCheckDistance * GetFacingDirection()), transform.position.y, transform.position.z);
        Gizmos.DrawLine(new Vector3(transform.position.x, transform.position.y, transform.position.z), wallCheck);


        Gizmos.color = Color.blue;
        Vector3 groundCheck = new Vector3(transform.position.x, transform.position.y - _groundCheckDistance, transform.position.z);
        Gizmos.DrawLine(transform.position, groundCheck);


    }

    private float GetFacingDirection()
    {
        return _facingDirection == FacingDirection.RIGHT ? 1 : -1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = false;
        }
    }

}

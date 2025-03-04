using Assets.Scripts.Enums;
using System;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{

    [Header("Player Controller")]
    [SerializeField] PlayerActionStatus currentActionStatus = PlayerActionStatus.IDLE;
    [SerializeField] FacingDirection _facingDirection = FacingDirection.RIGHT;
    [SerializeField] float _walkSpeed = 5f;
    [SerializeField] float _runSpeed = 8f;
    [SerializeField] Animator _animator;
    [SerializeField] bool _isGrounded;
    [SerializeField] bool _isWallDetected;
    [SerializeField] LayerMask whatIsGround;

    [Header("OnDrawGizmos")]
    [SerializeField] private float _wallCheckDistance = 0.65f;
    [SerializeField] private float _groundCheckDistance = 0.5f;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        HandleCollision();
        HandleAnimation();
    }


    private void HandleCollision()
    {
        _isGrounded = Physics2D.Raycast(transform.position, Vector2.down, _groundCheckDistance, whatIsGround);
        _isWallDetected = Physics2D.Raycast(transform.position, Vector2.right * GetFacingDirection(), _wallCheckDistance, whatIsGround);

    }


    private void HandleAnimation()
    {
        _animator.SetInteger("MovementAction", (int)currentActionStatus);
    }

    private void HandleInput()
    {
        float yInput = Input.GetAxis("Vertical");
        float xInput = Input.GetAxis("Horizontal");
        bool isRunning = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        if (xInput != 0)
        {
            currentActionStatus = isRunning ? PlayerActionStatus.RUN : PlayerActionStatus.WALK;

            float speed = isRunning ? _runSpeed : _walkSpeed;

            transform.Translate(Vector3.right * xInput * GetFacingDirection() * Time.deltaTime * speed);

            if (ShouldFlip(xInput))
            {
                FlipPlayer();
            }
        }
        else
        {
            currentActionStatus = PlayerActionStatus.IDLE;
        }
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
}

using Assets.Scripts.Enums;
using System;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{

    [SerializeField] PlayerActionStatus currentActionStatus = PlayerActionStatus.IDLE;
    [SerializeField] FacingDirection _facingDirection = FacingDirection.RIGHT;

    [Header("OnDrawGizmos")]
    [SerializeField] private float _wallCheckDistance = 0.65f;
    [SerializeField] private float _groundCheckDistance = 0.5f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FlipPlayer()
    {
        _facingDirection = _facingDirection == FacingDirection.RIGHT ? FacingDirection.LEFT : FacingDirection.RIGHT;
        transform.Rotate(0f, 180f, 0f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 wallCheck = new Vector3(transform.position.x + (_wallCheckDistance * GetFacingDirection()), transform.position.y + _groundCheckDistance,transform.position.z);
        Gizmos.DrawLine(new Vector3(transform.position.x,transform.position.y + _groundCheckDistance, transform.position.z), wallCheck);


        Gizmos.color = Color.blue;
        Vector3 groundCheck = new Vector3(transform.position.x, transform.position.y + _groundCheckDistance, transform.position.z);
        Gizmos.DrawLine(transform.position, groundCheck);


    }

    private float GetFacingDirection()
    {
        return _facingDirection == FacingDirection.RIGHT ? 1 : -1;
    }
}

using Assets.Scripts.Enums;
using UnityEngine;


namespace Assets.Scripts
{
    public class PlayerDataModel : MonoBehaviour
    {
        [Header("OnDrawGizmos")]
        public float WallCheckDistance = 1f;
        public float GroundCheckDistance = 0.5f;


        public float WalkSpeed = 3f;
        public float RunSpeed = 5f;
        public float JumpPower = 11f;
        public bool IsGrounded = true;
        public bool IsWallDetected;
        public LayerMask WhatIsGround;
        public bool isRunning;
        public bool isJumping;
        public bool isCrouching;
        public float yInput;
        public float xInput;
        public Rigidbody2D RB;
        [SerializeField] FacingDirection _facingDirection = FacingDirection.RIGHT;

        public Transform PlayerTransForm;

        [SerializeField] public Player_AC PlayerAnimationController;


        private void Awake()
        {
            PlayerAnimationController = GetComponent<Player_AC>();
            RB = GetComponent<Rigidbody2D>();
            PlayerTransForm = GetComponent<Transform>();
        }

        public void HandleAnimation(PlayerMovementState state)
        {

            PlayerAnimationController.SetAnimationForAction(state);
        }


        public bool ShouldFlip(float xInput)
        {
            return xInput > 0 && _facingDirection == FacingDirection.LEFT || xInput < 0 && _facingDirection == FacingDirection.RIGHT;
        }

        public void FlipPlayer()
        {
            _facingDirection = _facingDirection == FacingDirection.RIGHT ? FacingDirection.LEFT : FacingDirection.RIGHT;
            PlayerTransForm.Rotate(0f, 180f, 0f);
        }


        public float GetFacingDirection()
        {
            return _facingDirection == FacingDirection.RIGHT ? 1 : -1;
        }
    }
}

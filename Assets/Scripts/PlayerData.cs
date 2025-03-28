﻿using Assets.Scripts.Enums;
using UnityEngine;


namespace Assets.Scripts
{
    public class PlayerDataModel : MonoBehaviour
    {
        [Header("Collisions")]
        public bool IsGrounded = true;
        public bool IsWallDetected;
        public LayerMask WhatIsGround;


        [Header("OnDrawGizmos")]
        public float WallCheckDistance = 1f;
        public float GroundCheckDistance = 0.5f;

        [Header("Player attributes")]
        public float JumpArch = 3f;
        public float WalkSpeed = 3f;
        public float RunSpeed = 5f;
        public float JumpPower = 11f;
        [SerializeField] FacingDirection _facingDirection = FacingDirection.RIGHT;

        [Header("Player Movement State")]
        public bool isRunning;
        public bool isJumping;
        public bool isCrouching;

        [Header("Input")]
        public float yInput;
        public float xInput;



        [Header("Player components")]
        public Rigidbody2D RB;
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


        public PlayerMovementState GetNextState()
        {


            if (isJumping && IsGrounded)
            {
                return PlayerMovementState.JUMP;

            }

            if (xInput == 0 && IsGrounded && isCrouching)
            {
                return PlayerMovementState.CROUCH;
            }


            if (!isJumping && !IsGrounded)
            {

                return PlayerMovementState.FALL;

            }

            if (xInput == 0 && isJumping == false && IsGrounded && !isCrouching)
            {
                return PlayerMovementState.IDLE;
            }

            if (xInput != 0 && IsGrounded && !IsWallDetected)
            {
                Debug.Log("Idle to Walk");

                return isRunning ? PlayerMovementState.RUN : PlayerMovementState.WALK;


            }


            Debug.Log("Idle to Idle");
            return PlayerMovementState.IDLE;
        }
    }
}

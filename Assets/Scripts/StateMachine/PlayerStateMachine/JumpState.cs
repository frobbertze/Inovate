﻿using System;
using UnityEngine;

namespace Assets.Scripts.StateMachine.PlayerStateMachine
{
    public class JumpState : BaseState<PlayerMovementState>
    {
        public JumpState(PlayerDataModel playerData) : base(PlayerMovementState.JUMP)
        {
            PlayerData = playerData;
        }

        public PlayerDataModel PlayerData { get; }

        public override void EnterState()
        {
            PlayerData.HandleAnimation(StateKey);
        }

        public override void ExitState()
        {
            
        }

        public override void FixedUpdateState()
        {
            
        }

        public override PlayerMovementState GetNextState()
        {
            if (PlayerData.xInput == 0 && PlayerData.isJumping == false && PlayerData.IsGrounded && !PlayerData.isCrouching)
            {
                return PlayerMovementState.IDLE;
            }

            if (PlayerData.xInput != 0 && PlayerData.IsGrounded && !PlayerData.IsWallDetected)
            {
                Debug.Log("Idle to Walk");

                return PlayerData.isRunning ? PlayerMovementState.RUN : PlayerMovementState.WALK;


            }

            if (PlayerData.xInput == 0 && PlayerData.IsGrounded && PlayerData.isCrouching)
            {
                return PlayerMovementState.CROUCH;
            }

            if (PlayerData.isJumping && PlayerData.IsGrounded)
            {
                return PlayerMovementState.JUMP;

            }

            if (!PlayerData.isJumping && !PlayerData.IsGrounded && Mathf.Abs(PlayerData.xInput) < Mathf.Epsilon)
            {

                return PlayerMovementState.FALL;

            }



            Debug.Log("Idle to Idle");
            return PlayerMovementState.IDLE;
        }

        public override void OnCollisionEnter(Collision2D collision)
        {
            
        }

        public override void OnCollisionExit(Collision2D collision)
        {
            
        }

        public override void OnTriggerEnter(Collider2D collider)
        {
            
        }

        public override void OnTriggerExit(Collider2D collider)
        {
            
        }

        public override void UpdateState()
        {
            //if ((int)currentActionStatus == 15)
            //{
            //    _speed = _runSpeed;
            //}
            //else
            //{
            //    _speed = WalkSpeed;
            //}

            //currentActionStatus = PlayerActionStatus.JUMP;

          PlayerData.RB.linearVelocity = new Vector2(PlayerData.xInput * PlayerData.WalkSpeed, PlayerData.JumpPower);
        }
    }
}

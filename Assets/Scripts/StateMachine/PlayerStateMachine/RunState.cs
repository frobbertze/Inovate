using System;
using UnityEngine;

namespace Assets.Scripts.StateMachine.PlayerStateMachine
{
    public class RunState : BaseState<PlayerMovementState>
    {
        public RunState(PlayerDataModel playerData): base(PlayerMovementState.RUN)
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
            PlayerData.PlayerTransForm.Translate(Vector3.right * PlayerData.xInput * PlayerData.GetFacingDirection() * Time.deltaTime * PlayerData.RunSpeed);


            if (PlayerData.ShouldFlip(PlayerData.xInput))
            {
                PlayerData.FlipPlayer();
            }
        }
    }
}

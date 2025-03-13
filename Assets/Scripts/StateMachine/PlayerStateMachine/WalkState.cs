using System;
using UnityEngine;



namespace Assets.Scripts.StateMachine.PlayerStateMachine
{
    public class WalkState : BaseState<PlayerMovementState>
    {

        

        public WalkState(PlayerDataModel playerData):base(PlayerMovementState.WALK)
        {
            PlayerData = playerData;
        }

        public PlayerDataModel PlayerData { get; }

        public override void EnterState()
        {
            //throw new NotImplementedException();

            PlayerData.HandleAnimation(StateKey);

            Debug.Log("Entered Walk State");
        }

        public override void ExitState()
        {
           

            Debug.Log("Exited Walk State");
            //throw new NotImplementedException();
        }

        public override void FixedUpdateState()
        {
            return;
            //throw new NotImplementedException();
        }

        public override PlayerMovementState GetNextState()
        {


            if (PlayerData.isJumping && PlayerData.IsGrounded)
            {
                return PlayerMovementState.JUMP;

            }

            if (PlayerData.xInput == 0 && PlayerData.IsGrounded && PlayerData.isCrouching)
            {
                return PlayerMovementState.CROUCH;
            }


            if (!PlayerData.isJumping && !PlayerData.IsGrounded )
            {

                return PlayerMovementState.FALL;

            }

            if (PlayerData.xInput == 0 && PlayerData.isJumping == false && PlayerData.IsGrounded && !PlayerData.isCrouching)
            {
                return PlayerMovementState.IDLE;
            }

            if (PlayerData.xInput != 0 && PlayerData.IsGrounded && !PlayerData.IsWallDetected)
            {
                Debug.Log("Idle to Walk");

                return PlayerData.isRunning ? PlayerMovementState.RUN : PlayerMovementState.WALK;


            }

        





            Debug.Log("Idle to Idle");
            return PlayerMovementState.IDLE;
        }

        public override void OnCollisionEnter(Collision2D collision)
        {
            return;
        }

        public override void OnCollisionExit(Collision2D collision)
        {
            return;
        }

        public override void OnTriggerEnter(Collider2D collider)
        {
            return;
        }

        public override void OnTriggerExit(Collider2D collider)
        {
            return;
        }

        public override void UpdateState()
        {
            //currentActionStatus = isRunning ? PlayerActionStatus.RUN : PlayerActionStatus.WALK;
            


       


            if (PlayerData.ShouldFlip(PlayerData.xInput))
            {
                PlayerData.FlipPlayer();
            }
        }

        
    }
}

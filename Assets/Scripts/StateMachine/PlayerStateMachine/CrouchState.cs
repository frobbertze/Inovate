using UnityEngine;

namespace Assets.Scripts.StateMachine.PlayerStateMachine
{
    public class CrouchState : BaseState<PlayerMovementState>
    {
        public CrouchState(PlayerDataModel playerData):base(PlayerMovementState.CROUCH)
        {
            PlayerData = playerData;
        }

        public PlayerDataModel PlayerData { get; }

        public override void EnterState()
        {
            PlayerData.HandleAnimation(PlayerMovementState.CROUCH);
        }

        public override void ExitState()
        {
            
        }

        public override void FixedUpdateState()
        {
            
        }

        public override PlayerMovementState GetNextState()
        {

            if (PlayerData.isJumping && PlayerData.IsGrounded && !PlayerData.IsWallDetected)
            {
                return PlayerMovementState.JUMP;

            }

            if (PlayerData.xInput == 0 && PlayerData.IsGrounded && PlayerData.isCrouching)
            {
                return PlayerMovementState.CROUCH;
            }


            if (!PlayerData.isJumping && !PlayerData.IsGrounded)
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
            
        }
    }
}

using UnityEngine;

namespace Assets.Scripts.StateMachine.PlayerStateMachine
{
    public class IdleState : BaseState<PlayerMovementState>
    {
        public IdleState(PlayerDataModel playerData) : base(PlayerMovementState.IDLE)
        {
            PlayerData = playerData;
        }

        public PlayerDataModel PlayerData { get; }

        public override void EnterState()
        {
            PlayerData.HandleAnimation(StateKey);
            Debug.Log("Entered Idle State");
        }

        public override void ExitState()
        {
            Debug.Log("Exited Idle State");
        }

        public override void FixedUpdateState()
        {
            //throw new System.NotImplementedException();

            return;
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
            return;
            //throw new System.NotImplementedException();
        }
    }
}

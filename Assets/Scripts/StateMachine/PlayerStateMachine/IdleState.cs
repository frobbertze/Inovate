using UnityEngine;

namespace Assets.Scripts.StateMachine.PlayerStateMachine
{
    public class IdleState : BaseState<PlayerMovementState>
    {
        public IdleState(Player_Controller player_Controller) : base(PlayerMovementState.IDLE)
        {
            Player_Controller = player_Controller;
        }

        public Player_Controller Player_Controller { get; }

        public override void EnterState()
        {
            Player_Controller.HandleAnimation(StateKey);
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
           

            if (Player_Controller.xInput == 0 && Player_Controller.isJumping == false && Player_Controller.IsGrounded && !Player_Controller.isCrouching)
            {
              return PlayerMovementState.IDLE;
            }

            if (Player_Controller.xInput != 0 && Player_Controller.IsGrounded && !Player_Controller.IsWallDetected)
            {
                Debug.Log("Idle to Walk");

                return Player_Controller.isRunning ? PlayerMovementState.RUN : PlayerMovementState.WALK;


            }

            if (Player_Controller.xInput == 0 && Player_Controller.IsGrounded && Player_Controller.isCrouching)
            {
                return PlayerMovementState.CROUCH;
            }

            if (Player_Controller.isJumping && Player_Controller.IsGrounded)
            {
                return PlayerMovementState.JUMP;

            }

            if (!Player_Controller.isJumping && !Player_Controller.IsGrounded && Mathf.Abs(Player_Controller.xInput) < Mathf.Epsilon)
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

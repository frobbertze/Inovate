using System;
using UnityEngine;



namespace Assets.Scripts.StateMachine.PlayerStateMachine
{
    public class WalkState : BaseState<PlayerMovementState>
    {

        

        public WalkState(Player_Controller player_Controller):base(PlayerMovementState.WALK)
        {
            Player_Controller = player_Controller;
        }

        public Player_Controller Player_Controller { get; }

        public override void EnterState()
        {
            //throw new NotImplementedException();

            Player_Controller.HandleAnimation(StateKey);

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
            //currentActionStatus = isRunning ? PlayerActionStatus.RUN : PlayerActionStatus.WALK;
            


            Player_Controller.transform.Translate(Vector3.right * Player_Controller.xInput * Player_Controller.GetFacingDirection() * Time.deltaTime * Player_Controller.WalkSpeed);


            if (Player_Controller.ShouldFlip(Player_Controller.xInput))
            {
                Player_Controller.FlipPlayer();
            }
        }

        
    }
}

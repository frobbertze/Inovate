using System;
using UnityEngine;

namespace Assets.Scripts.StateMachine.PlayerStateMachine
{
    public class RunState : BaseState<PlayerMovementState>
    {
        public RunState(Player_Controller player_Controller): base(PlayerMovementState.RUN)
        {
            Player_Controller = player_Controller;
        }

        public Player_Controller Player_Controller { get; }

        public override void EnterState()
        {
            Player_Controller.HandleAnimation(StateKey);
        }

        public override void ExitState()
        {
            
        }

        public override void FixedUpdateState()
        {
            
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
            Player_Controller.transform.Translate(Vector3.right * Player_Controller.xInput * Player_Controller.GetFacingDirection() * Time.deltaTime * Player_Controller.RunSpeed);


            if (Player_Controller.ShouldFlip(Player_Controller.xInput))
            {
                Player_Controller.FlipPlayer();
            }
        }
    }
}

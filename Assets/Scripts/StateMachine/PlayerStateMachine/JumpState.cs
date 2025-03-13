using System;
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


            return PlayerData.GetNextState();
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

            if (PlayerData.ShouldFlip(PlayerData.xInput))
            {
                PlayerData.FlipPlayer();
            }

            PlayerData.RB.linearVelocity = new Vector2(PlayerData.WalkSpeed * PlayerData.GetFacingDirection() * PlayerData.JumpArch, PlayerData.JumpPower);

            //PlayerData.RB.AddForce(new Vector2(PlayerData.WalkSpeed * PlayerData.GetFacingDirection() , PlayerData.JumpPower),ForceMode2D.Impulse);


        }
    }
}

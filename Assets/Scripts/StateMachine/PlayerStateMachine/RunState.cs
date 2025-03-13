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
            PlayerData.PlayerTransForm.Translate(Vector3.right * PlayerData.xInput * PlayerData.GetFacingDirection() * Time.deltaTime * PlayerData.RunSpeed);


            if (PlayerData.ShouldFlip(PlayerData.xInput))
            {
                PlayerData.FlipPlayer();
            }
        }
    }
}

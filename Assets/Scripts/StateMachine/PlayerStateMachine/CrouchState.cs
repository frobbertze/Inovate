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
            
        }
    }
}

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

            return PlayerData.GetNextState();
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

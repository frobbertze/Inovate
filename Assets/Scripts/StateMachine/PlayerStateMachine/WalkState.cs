using System;
using UnityEngine;



namespace Assets.Scripts.StateMachine.PlayerStateMachine
{
    public class WalkState : BaseState<PlayerMovementState>
    {



        public WalkState(PlayerDataModel playerData) : base(PlayerMovementState.WALK)
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
            //currentActionStatus = isRunning ? PlayerActionStatus.RUN : PlayerActionStatus.WALK;


            if (PlayerData.ShouldFlip(PlayerData.xInput))
            {
                PlayerData.FlipPlayer();
            }

            PlayerData.PlayerTransForm.Translate(Vector3.right * PlayerData.xInput * PlayerData.GetFacingDirection() * Time.deltaTime * PlayerData.WalkSpeed);


        }


    }
}

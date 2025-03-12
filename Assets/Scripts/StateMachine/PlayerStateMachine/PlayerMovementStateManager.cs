using Assets.Scripts.StateMachine.States;

using UnityEngine;

namespace Assets.Scripts.StateMachine.PlayerStateMachine
{
    public class PlayerMovementStateManager : StateManager<PlayerMovementState>
    {


        public PlayerDataModel PlayerData;


        private void Awake()
        {

            InitializeStates();

        }



        protected override void InitializeStates()
        {
            States.Add(PlayerMovementState.IDLE, new IdleState(PlayerData));
            States.Add(PlayerMovementState.WALK, new WalkState(PlayerData));
            States.Add(PlayerMovementState.RUN, new RunState(PlayerData));
            States.Add(PlayerMovementState.JUMP, new JumpState(PlayerData));
            States.Add(PlayerMovementState.FALL, new FallState(PlayerData));
            States.Add(PlayerMovementState.CROUCH, new CrouchState(PlayerData));

            CurrentState = States[PlayerMovementState.IDLE];
        }


    }
}

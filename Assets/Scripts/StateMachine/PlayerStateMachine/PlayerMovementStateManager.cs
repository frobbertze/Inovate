using Assets.Scripts.StateMachine.States;

using UnityEngine;

namespace Assets.Scripts.StateMachine.PlayerStateMachine
{
    public class PlayerMovementStateManager : StateManager<PlayerMovementState>
    {


        public Player_Controller Player_Controller;


        private void Awake()
        {

            InitializeStates();

        }



        protected override void InitializeStates()
        {
            States.Add(PlayerMovementState.IDLE, new IdleState(Player_Controller));
            States.Add(PlayerMovementState.WALK, new WalkState(Player_Controller));
            States.Add(PlayerMovementState.RUN, new RunState(Player_Controller));
            States.Add(PlayerMovementState.JUMP, new JumpState(Player_Controller));
            States.Add(PlayerMovementState.FALL, new FallState(Player_Controller));
            States.Add(PlayerMovementState.CROUCH, new CrouchState(Player_Controller));

            CurrentState = States[PlayerMovementState.IDLE];
        }


    }
}

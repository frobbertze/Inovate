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


        


        private void OnDrawGizmos()
        {
            //    RaycastHit2D wallHit = Physics2D.Raycast(transform.position, new Vector2(PlayerData.GetFacingDirection(),0), 1f, PlayerData.WhatIsGround);
            //    if (wallHit.collider != null)
            //    {
            //        Debug.Log("Wall detected!");
            //    }


            Gizmos.color = Color.red;
            Vector3 wallCheck = new Vector3(PlayerData.transform.position.x + PlayerData.GetFacingDirection() * PlayerData.WallCheckDistance, PlayerData.transform.position.y);
            Gizmos.DrawLine(transform.position, wallCheck);

            wallCheck = new Vector3(PlayerData.transform.position.x + PlayerData.GetFacingDirection() * PlayerData.WallCheckDistance, PlayerData.transform.position.y - 1.35f);
            Gizmos.DrawLine(transform.position, wallCheck);

            wallCheck = new Vector3(PlayerData.transform.position.x + PlayerData.GetFacingDirection() * PlayerData.WallCheckDistance, PlayerData.transform.position.y + 0.5f);
            Gizmos.DrawLine(transform.position, wallCheck);


            //Gizmos.color = Color.blue;
            //Vector3 groundCheck = new Vector3(transform.position.x, transform.position.y - _groundCheckDistance, transform.position.z);
            //Gizmos.DrawLine(transform.position, groundCheck);


        }






    }
}

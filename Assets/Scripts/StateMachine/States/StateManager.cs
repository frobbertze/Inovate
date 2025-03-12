using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.StateMachine.States
{
    public abstract class StateManager<TState> : MonoBehaviour where TState : System.Enum
    {

        protected Dictionary<TState, BaseState<TState>> States = new Dictionary<TState, BaseState<TState>>();
        protected BaseState<TState> CurrentState;

        protected bool IsTransitioning = false;

        private void Awake()
        {
            InitializeStates();
        }

        protected abstract void InitializeStates();
       

        public void Start()
        {
            CurrentState.EnterState();
        }

        public void Update()
        {
            

            TState nextState = CurrentState.GetNextState();

           

            if (nextState.Equals(CurrentState.StateKey))
            {
                CurrentState.UpdateState();

                return;
            }

            if (!IsTransitioning)
            {
                
                TransitionToState(nextState);
            }

        }


        public void FixedUpdate()
        {
            //CurrentState.FixedUpdateState();
        }


        public void TransitionToState(TState newState)
        {
                            
            IsTransitioning = true;

            CurrentState.ExitState();
            CurrentState = States[newState];
            
            CurrentState.EnterState();

            IsTransitioning = false;
        }


        public void OnTriggerEnter2D(Collider2D collider)
        {
            CurrentState.OnTriggerEnter(collider);
        }


        public void OnTriggerExit2D(Collider2D collider)
        {
            CurrentState.OnTriggerExit(collider);
        }


        public void OnCollisionEnter2D(Collision2D collision)
        {
            CurrentState.OnCollisionEnter(collision);
        }


        public void OnCollisionExit2D(Collision2D collision)
        {
            CurrentState.OnCollisionExit(collision);
        }
    }
}

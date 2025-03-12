using System;
using UnityEngine;

public abstract class BaseState<TState> where TState : Enum
{
    public TState StateKey;

    protected BaseState(TState state)
    {
        StateKey = state;
    }
    abstract public void EnterState();
    abstract public void ExitState();
    abstract public void UpdateState();
    abstract public void FixedUpdateState();
    abstract public TState GetNextState();

    abstract public void OnTriggerEnter(Collider2D collider);
    abstract public void OnTriggerExit(Collider2D collider);

    abstract public void OnCollisionEnter(Collision2D collision);

    abstract public void OnCollisionExit(Collision2D collision);

}

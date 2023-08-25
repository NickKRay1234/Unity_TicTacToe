using UnityEngine;

public class IdleState : State
{
    public override void Enter()
    {
        base.Enter();
#if UNITY_EDITOR
        Debug.Log("I entered in Idle state");
#endif
    }

    public override void Exit()
    {
        base.Exit();
#if UNITY_EDITOR
        Debug.Log("I came out of my Idle state");
#endif
    }
}
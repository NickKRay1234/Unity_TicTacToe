using UnityEngine;

public class GameState : State
{
    public override void Enter()
    {
        base.Enter();
#if UNITY_EDITOR
        Debug.Log("I entered in Start state");
#endif
    }

    public override void Exit()
    {
        base.Exit();
#if UNITY_EDITOR
        Debug.Log("I came out of my Start state");
#endif
    }
}
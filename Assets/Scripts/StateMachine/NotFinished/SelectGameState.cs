﻿using UnityEngine;

public class SelectGameState : IState
{
    public void Enter()
    {
#if UNITY_EDITOR
        Debug.Log("I entered in Start state");
#endif
    }

    public void Exit()
    {
#if UNITY_EDITOR
        Debug.Log("I came out of my Start state");
#endif
    }

    public void Update()
    {
        throw new System.NotImplementedException();
    }
}
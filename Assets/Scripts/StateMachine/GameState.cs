﻿using MVP.TicTacToeView;
using UnityEngine;

public class GameState : MonoBehaviour, IState
{
    private GridView _grid;
    private CommandInvoker _invoker;
    public void Enter()
    {
        _grid = ServiceLocator.Current.Get<GridView>();
        _invoker = ServiceLocator.Current.Get<CommandInvoker>();
        if (_invoker.IsNotEmpty())
        {
            _invoker.ClearStack();
            _grid.Dispose();
        }
        _grid.InitializeGrid();
        gameObject.SetActive(true);
#if UNITY_EDITOR
        Debug.Log("<color=cyan>I entered in Game state</color>");
#endif
    }

    public void Exit()
    {
        gameObject.SetActive(false);
#if UNITY_EDITOR
        Debug.Log("<color=cyan>I came out of my Game state</color>");
#endif
    }
}
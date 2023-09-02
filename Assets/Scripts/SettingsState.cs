using Unity.VisualScripting;
using UnityEngine;

public class SettingsState : State
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
}
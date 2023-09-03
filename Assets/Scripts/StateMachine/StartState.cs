using UnityEngine;

public class StartState : MonoBehaviour, IState
{
    public void Enter()
    {
        gameObject.SetActive(true);
#if UNITY_EDITOR
        Debug.Log("<color=cyan>I entered in Start state</color>");
#endif
    }

    public void Exit()
    {
        gameObject.SetActive(false);
#if UNITY_EDITOR
        Debug.Log("<color=cyan>I came out of my Start state</color>");
#endif
    }
}
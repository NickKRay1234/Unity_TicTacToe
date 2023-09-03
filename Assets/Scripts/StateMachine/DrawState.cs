using UnityEngine;

public class DrawState : MonoBehaviour, IState, IService
{
    public void Enter()
    {
        gameObject.SetActive(true);
#if UNITY_EDITOR
        Debug.Log("<color=cyan>I entered in Draw state</color>");
#endif
    }
    public void Exit()
    {
        gameObject.SetActive(false);
#if UNITY_EDITOR
        Debug.Log("<color=cyan>I came out of my Draw state</color>");
#endif
    }
}
using UnityEngine;

public class DrawState : MonoBehaviour, IState, IService
{
    public void Enter()
    {
        gameObject.SetActive(true);
#if UNITY_EDITOR
        Debug.Log("I entered in Draw state");
#endif
    }

    public void Exit()
    {
        gameObject.SetActive(false);
#if UNITY_EDITOR
        Debug.Log("I came out of my Draw state");
#endif
    }

    public void Update()
    {
        
    }
}
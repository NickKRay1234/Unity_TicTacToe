using UnityEngine;

public class StartState : MonoBehaviour, IState
{
    public void Enter()
    {
        gameObject.SetActive(true);
#if UNITY_EDITOR
        Debug.Log("I entered in Start state");
#endif
    }

    public void Exit()
    {
        gameObject.SetActive(false);
#if UNITY_EDITOR
        Debug.Log("I came out of my Start state");
#endif
    }
}
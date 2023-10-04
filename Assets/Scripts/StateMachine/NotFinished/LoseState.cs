using UnityEngine;

public class LoseState : MonoBehaviour, IState
{
    public void Enter()
    {
        gameObject.SetActive(true);
#if UNITY_EDITOR
        Debug.Log("I entered in Lose state");
#endif
    }

    public void Exit()
    {
        gameObject.SetActive(false);
#if UNITY_EDITOR
        Debug.Log("I came out of my Lose state");
#endif
    }
}
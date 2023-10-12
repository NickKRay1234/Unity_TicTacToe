using UnityEngine;

public class LoseState : MonoBehaviour, IState
{
    public void Enter() => gameObject.SetActive(true);
    public void Exit() => gameObject.SetActive(false);
}
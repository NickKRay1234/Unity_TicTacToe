using UnityEngine;

public class ShopState : MonoBehaviour, IState
{
    public void Enter() => gameObject.SetActive(true);
    public void Exit() => gameObject.SetActive(false);
}
using UnityEngine;
using UnityEngine.UI;

public class ShopState : MonoBehaviour, IState
{
    [SerializeField] private UIDesignDataContainer _data;
    
    public void Enter()
    {
        gameObject.SetActive(true);
    }
    
    public void Exit() => gameObject.SetActive(false);

    public void ChangeActiveX(Sprite newX)
    {
        _data.ActiveXSprite = newX;
        _data.X.GetComponent<Image>().sprite = _data.ActiveXSprite;
    }
    
    public void ChangeActiveO(Sprite newO)
    {
        _data.ActiveOSprite = newO;
        //_data.O.GetComponent<Image>().sprite = _data.ActiveOSprite;
    }
}
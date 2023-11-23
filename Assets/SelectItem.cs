using UnityEngine;
using UnityEngine.UI;

public class SelectItem : MonoBehaviour
{
    [SerializeField] private UIDesignDataContainer _data;
    private Button _selectedButton;

    private void Awake() => Select(_data.SelectedButton);

    public void Select(Button button)
    {
        if (_selectedButton != null)
        {
            _selectedButton.gameObject.transform.GetChild(_selectedButton.gameObject.transform.childCount - 1)
                .GetComponent<Image>().color = Color.white;
        }

        _selectedButton = button;
        _selectedButton.gameObject.transform.GetChild(_selectedButton.gameObject.transform.childCount - 1)
            .GetComponent<Image>().color = Color.green;
        _selectedButton.gameObject.transform.GetChild(1).gameObject.SetActive(false);
        _data.SelectedButton = _selectedButton;
    }
}
using UnityEngine;
using TMPro;
using DG.Tweening;
//using UnityEngine.Localization.Components;

public class LoadingTextAnimation : MonoBehaviour
{
    [SerializeField] private TMP_Text loadingText;
    [SerializeField] private float speed = 0.25f;
    //private LocalizeStringEvent localizeStringEvent;
    private string localizedBaseText;
    private int dotCount = 0;

    private void Start()
    {
        //localizeStringEvent = GetComponent<LocalizeStringEvent>();
        //localizeStringEvent.OnUpdateString.AddListener(UpdateLocalizedText);
        DOTween.To(() => dotCount, x => dotCount = x, 3, speed)
            .SetLoops(-1, LoopType.Restart)
            .OnUpdate(UpdateText);
    }

    private void UpdateLocalizedText(string localizedText)
    {
        localizedBaseText = localizedText;
        UpdateText();
    }

    private void UpdateText() =>
        loadingText.text = localizedBaseText + new string('.', dotCount % 4);
}

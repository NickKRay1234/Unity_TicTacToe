using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.Serialization;

public class TypewriterEffect : MonoBehaviour
{
    [SerializeField] private TMP_Text _typewriterText;
    [SerializeField] private float _typingSpeed = 0.001f;
    private void Start() => StartCoroutine(TypeText());

    private IEnumerator TypeText()
    {
        _typewriterText.text = "";
        foreach (char letter in DesignDataContainer.LoadingText)
        {
            _typewriterText.text += letter;
            yield return new WaitForSeconds(_typingSpeed);
        }
    }
}
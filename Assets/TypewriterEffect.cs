using UnityEngine;
using TMPro;
using System.Collections;

public class TypewriterEffect : MonoBehaviour
{
    public TMP_Text typewriterText;
    public float typingSpeed = 0.001f;

    private string fullText = "You don't have to say a word, because your actions speak volumes for you";

    void Start()
    {
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        typewriterText.text = "";
        foreach (char letter in fullText)
        {
            typewriterText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
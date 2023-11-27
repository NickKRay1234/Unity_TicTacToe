using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Architecture.Infrastructure
{
    public class LoadingCurtain : MonoBehaviour
    {
        public Slider LoadingBarFill;
        public CanvasGroup Curtain;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public void Show()
        {
            gameObject.SetActive(true);
            Curtain.alpha = 1;
        }

        public void SetProgress(float progress) => LoadingBarFill.value = progress;

        public void Hide() => StartCoroutine(FadeIn());

        private IEnumerator FadeIn()
        {
            while (Curtain.alpha > 0)
            {
                Curtain.alpha -= 0.03f;
                yield return new WaitForSeconds(0.03f);
            }
            gameObject.SetActive(false);
        }
    }
}
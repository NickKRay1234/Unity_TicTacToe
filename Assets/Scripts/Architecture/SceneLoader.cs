using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Architecture.Infrastructure
{
    public class SceneLoader
    {
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly LoadingCurtain _loadingCurtain;

        public SceneLoader(ICoroutineRunner coroutineRunner, LoadingCurtain loadingCurtain)
        {
            _coroutineRunner = coroutineRunner;
            _loadingCurtain = loadingCurtain;
        }

        public void Load(string name, Action onLoaded = null)
        {
            _loadingCurtain.Show();
            _coroutineRunner.StartCoroutine(LoadScene(name, onLoaded));
        }

        private IEnumerator LoadScene(string nextScene, Action onLoaded = null)
        {
            if (SceneManager.GetActiveScene().name == nextScene)
            {
                _loadingCurtain.SetProgress(1);
                onLoaded?.Invoke();
                yield break;
            }
            
            yield return FakeLoading(SceneManager.LoadSceneAsync(nextScene));
            onLoaded?.Invoke();
        }

        private IEnumerator FakeLoading(AsyncOperation nextScene)
        {
            float fakeProgress = 0;
            while (fakeProgress < 1.0f)
            {
                fakeProgress += 0.01f;
                _loadingCurtain.SetProgress(fakeProgress);
                yield return new WaitForSeconds(0.025f);
            }
            _loadingCurtain.Hide();
            if (nextScene.isDone) yield return null;
        }

        private IEnumerator Loading(AsyncOperation nextScene)
        {
            while (!nextScene.isDone)
            {
                float progressValue = Mathf.Clamp01(nextScene.progress / 0.9f);
                _loadingCurtain.SetProgress(progressValue);
                yield return null;
            }
            _loadingCurtain.Hide();
        }
        
    }
}
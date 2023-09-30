using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Architecture.Infrastructure
{
    // Корутина для асинхронной загрузки сцены в Unity.
    public class SceneLoader
    {
        // Интерфейс, представляющий собой обёртку для работы с корутинами в Unity.
        private readonly ICoroutineRunner _coroutineRunner;
        
        // В конструкторе получаем ссылку на сервис для работы с корутинами.
        public SceneLoader(ICoroutineRunner coroutineRunner) =>
            _coroutineRunner = coroutineRunner;

        // Метод для начала загрузки сцены. Запускает корутину LoadScene.
        public void Load(string name, Action onLoaded = null) =>
            _coroutineRunner.StartCoroutine(LoadScene(name, onLoaded));

        // Приватная корутина для загрузки сцены с возможностью выполнять код после загрузки.
        private IEnumerator LoadScene(string name, Action onLoaded = null)
        {
            // Запускаем асинхронную загрузку сцены по имени.
            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(name);
            
            // Ждём завершения загрузки сцены. Если загрузка ещё не завершена,
            // то возвращаем null, и корутина будет продолжена на следующем кадре.
            while (waitNextScene.isDone)
                yield return null;
            
            // Если был передан делегат для вызова после загрузки сцены,
            // вызываем его здесь.
            onLoaded?.Invoke();
        }
    }
}
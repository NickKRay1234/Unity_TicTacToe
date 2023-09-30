using System.Collections;
using UnityEngine;

namespace Architecture.Infrastructure
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}
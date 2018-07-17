using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public static class AsyncOperationExtensions
{
    public static void OnComplete(this AsyncOperation operation, Action callback)
    {
        MainThreadDispatcher.StartCoroutine(OnCompleteAsyncOperation(operation, callback));
    }

    private static IEnumerator OnCompleteAsyncOperation(AsyncOperation operation, Action callback)
    {
        while (!operation.isDone) yield return null;

        callback();
    }
}

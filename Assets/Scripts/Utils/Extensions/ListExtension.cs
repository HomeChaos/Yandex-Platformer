using System;
using System.Collections.Generic;
using UnityEngine.Assertions;

public static class ListExtension
{
    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;

        while (n > 1)
        {
            n--;
            int k = UnityEngine.Random.Range(0, n + 1);
            (list[k], list[n]) = (list[n], list[k]);
        }
    }

    public static T GetRandomValue<T>(this IList<T> list)
    {
        return list[UnityEngine.Random.Range(0, list.Count)];
    }
    
    public static void Iterate<T>(this IList<T> list, Action<T> callback)
    {
        list.Iterate((item, index)=> callback.Invoke(item));
    }

    public static void Iterate<T>(this IList<T> list, Action<T, int> callback)
    {
        int listCount = list.Count;
        list.Iterate(0, listCount, callback);
    }

    public static void Iterate<T>(this IList<T> list, int startIndex, int count, Action<T, int> callback)
    {
        IterateBase(list, startIndex, count, 1, callback, i => i < startIndex + count);
    }
    
    private static void IterateBase<T>(this IList<T> list, int startIndex, int count, int step, Action<T, int> callback, Func<int, bool> comparer)
    {
        Assert.IsTrue(step is 1 or -1);
        Assert.IsNotNull(callback);

        int listCount = list.Count;
        if (listCount > 0)
        {
            for (int i = startIndex; comparer(i); i += step)
            {
                T item = list[i];
                callback?.Invoke(item, i);
            }
        }
    }
}
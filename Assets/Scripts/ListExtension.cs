using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class ListExtension
{
    public static bool ContainsSequence<T>(this List<T> outer, List<T> inner)
    {
        var innerCount = inner.Count;

        for (int i = 0; i < outer.Count - innerCount; i++)
        {
            bool isMatch = true;
            for (int x = 0; x < innerCount; x++)
            {
                Debug.Log(outer[i + x] + "    " + inner[x]);
                if (!outer[i + x].Equals(inner[x]))
                {
                    isMatch = false;
                    break;
                }
            }

            if (isMatch) return true;
        }

        return false;
    }

    public static bool ContainsSubsequence<T>(List<T> sequence, List<T> subsequence)
    {
        if (sequence.Count < subsequence.Count) return false;
        Debug.Log("TESTESTESTEST");
        return
            Enumerable
                .Range(0, sequence.Count - subsequence.Count + 1)
                .Any(n => sequence.Skip(n).Take(subsequence.Count).SequenceEqual(subsequence));
    }

}

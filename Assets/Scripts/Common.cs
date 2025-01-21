using System.Collections;
using UnityEngine;

namespace Delleloper.RPSTechTest.Common
{
    public class Utils
    {
        public static IEnumerator AnimateFade(CanvasGroup element, bool show, float duration)
        {
            float targetAlpha = show ? 1 : 0;
            float startAlpha = element.alpha;
            float time = 0f;

            while (time < duration)
            {
                time += Time.deltaTime;
                element.alpha = Mathf.Lerp(startAlpha, targetAlpha, time / duration);
                yield return null;
            }

            element.alpha = targetAlpha;
        }
    }
}
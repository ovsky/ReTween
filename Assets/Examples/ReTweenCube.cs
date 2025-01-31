using System.Collections;
using ReTween;
using UnityEngine;

namespace ReTween.Examples
{
    public class ReTweenCube : MonoBehaviour
    {
        [SerializeField] Ease scaleEase;
        [SerializeField] Ease anotherEase = EaseType.QuadInOut;

        IEnumerator Start()
        {
            yield return Tween.Scale(transform, Vector3.zero, 1f, 0f, scaleEase);
            yield return Tween.Position(transform, Vector3.right * 3f, 1f, 0f, anotherEase);
            yield return Tween.Position(transform, Vector3.up * 3f, 1f, 0f, anotherEase);
            yield return Tween.Wait(1f);
            yield return Tween.Scale(transform, Vector3.one * 3f, 1f, 0f, anotherEase)
                .Next(Tween.Scale(transform, Vector3.one * 3f, Vector3.one * 0f, 1f, 0f, anotherEase))
                .Next(Tween.Scale(transform, Vector3.one * 4f, 1f, 0f, anotherEase))
                .Next(Tween.Wait(3f))
                .Next(Tween.Scale(transform, Vector3.one * 2f, 1f, 0f, anotherEase));

            yield return Tween.Position(transform, Vector3.right * 3f, 1f, 0f, EaseType.QuadInOut)
                .Join(Tween.Scale(transform, Vector3.zero, 4f, 0f, EaseType.QuadInOut));
        }
    }
}
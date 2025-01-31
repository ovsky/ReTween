using System;
using UnityEngine;

namespace ReTween
{
    public partial class Tween
    {
        #region Transform Height
        public static TweenAction Height(Transform transform, Func<float> begin, Func<float> target, float duration = 1f, float delay = 0f, Ease ease = null)
        => Tween.Height(transform, begin(), target(), duration, delay, ease);

        public static TweenAction Height(Transform transform, Func<float> target, float duration = 1f, float delay = 0f, Ease ease = null)
        => Tween.Height(transform, transform.position.y, target(), duration, delay, ease);

        public static TweenAction Height(Transform transform, float target, float duration = 1f, float delay = 0f, Ease ease = null)
            => Tween.Height(transform, transform.position.y, target, duration, delay, ease);

        public static TweenAction Height(Transform transform, float begin, float target, float duration = 1f, float delay = 0f, Ease ease = null)
            => Tween.Add(new TweenAction((float time) => transform.position = Vector3.LerpUnclamped(new Vector3(transform.position.x, begin, transform.position.z), new Vector3(transform.position.x, target, transform.position.z), time), duration, delay, ease));

        public static TweenAction Height(Transform transform, float begin, Func<float> target, float duration = 1f, float delay = 0f, Ease ease = null)
            => Tween.Add(new TweenAction((float time) => transform.position = Vector3.LerpUnclamped(new Vector3(transform.position.x, begin, transform.position.z), new Vector3(transform.position.x, target(), transform.position.z), time), duration, delay, ease));

        #endregion Transform Height
    }
}
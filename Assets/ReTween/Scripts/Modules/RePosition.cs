using System;
using UnityEngine;

namespace ReTween
{
    public partial class Tween
    {
        #region Transform
        public static TweenAction Position(Transform transform, Func<Vector3> begin, Func<Vector3> target, float duration = 1f, float delay = 0f, Ease ease = null)
            => Tween.Position(transform, begin(), target(), duration, delay, ease);

        public static TweenAction Position(Transform transform, Func<Vector3> target, float duration = 1f, float delay = 0f, Ease ease = null)
            => Tween.Position(transform, transform.position, target(), duration, delay, ease);

        public static TweenAction Position(Transform transform, Vector3 target, float duration = 1f, float delay = 0f, Ease ease = null)
            => Tween.Position(transform, transform.position, target, duration, delay, ease);

        public static TweenAction Position(Transform transform, Vector3 begin, Vector3 target, float duration = 1f, float delay = 0f, Ease ease = null)
            => Tween.Add(new TweenAction((float time) => transform.position = Vector3.LerpUnclamped(begin, target, time), duration, delay, ease));

        public static TweenAction Position(Transform transform, Vector3 begin, Func<Vector3> target, float duration = 1f, float delay = 0f, Ease ease = null)
            => Tween.Add(new TweenAction((float time) => transform.position = Vector3.LerpUnclamped(begin, target(), time), duration, delay, ease));

        #endregion Transform
    }
}
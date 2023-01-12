using System;
using UnityEngine;

namespace ReTween
{
    public partial class Tween
    {
        #region Transform

        public static void Scale(Transform transform, Vector3 target, float duration = 1f, float delay = 0f, AnimationCurve ease = null)
            => Position(transform, transform.localScale, target, duration, delay, ease);

        public static void Scale(Transform transform, Vector3 begin, Vector3 target, float duration = 1f, float delay = 0f, AnimationCurve ease = null)
            => tweenActions.Add(new TweenAction((float time) => transform.localScale = Vector3.LerpUnclamped(begin, target, time), duration, delay, ease));

        public static void Scale(Transform transform, Vector3 begin, Func<Vector3> target, float duration = 1f, float delay = 0f, AnimationCurve ease = null)
            => tweenActions.Add(new TweenAction((float time) => transform.localScale = Vector3.LerpUnclamped(begin, target(), time), duration, delay, ease));

        #endregion Transform
    }
}
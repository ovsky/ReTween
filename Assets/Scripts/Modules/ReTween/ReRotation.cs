using System;
using UnityEngine;

namespace ReTween
{
    public partial class Tween
    {
        #region Tramsform Rotation
        public static TweenAction Rotation(Transform transform, Func<Quaternion> begin, Func<Quaternion> target, float duration = 1f, float delay = 0f, Ease ease = null)
            => Tween.Rotation(transform, begin(), target(), duration, delay, ease);

        public static TweenAction Rotation(Transform transform, Func<Quaternion> target, float duration = 1f, float delay = 0f, Ease ease = null)
            => Tween.Rotation(transform, transform.rotation, target(), duration, delay, ease);

        public static TweenAction Rotation(Transform transform, Quaternion target, float duration = 1f, float delay = 0f, Ease ease = null)
            => Tween.Rotation(transform, transform.rotation, target, duration, delay, ease);

        public static TweenAction Rotation(Transform transform, Quaternion begin, Quaternion target, float duration = 1f, float delay = 0f, Ease ease = null)
            => Tween.Add(new TweenAction((float time) => transform.rotation = Quaternion.LerpUnclamped(begin, target, time), duration, delay, ease));

        public static TweenAction Rotation(Transform transform, Quaternion begin, Func<Quaternion> target, float duration = 1f, float delay = 0f, Ease ease = null)
            => Tween.Add(new TweenAction((float time) => transform.rotation = Quaternion.LerpUnclamped(begin, target(), time), duration, delay, ease));

        #endregion Transform Rotation
    }
}
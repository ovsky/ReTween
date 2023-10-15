using System;
using UnityEngine;

namespace ReTween
{
    public static class ReExtensions
    {
        #region Action Extensions

        public static TweenAction SetEase(this TweenAction tween, Ease ease) => Tween.SetExtension(tween, () => tween.ease = ease);
        public static TweenAction SetDelay(this TweenAction tween, float delay) => Tween.SetExtension(tween, () => tween.delay = delay);
        public static TweenAction SetAction(this TweenAction tween, Action<float> action) => Tween.SetExtension(tween, () => tween.function = action);
        public static TweenAction SetDuration(this TweenAction tween, float duration) => Tween.SetExtension(tween, () => tween.duration = duration);
        public static TweenAction SetStartTime(this TweenAction tween, float startTime) => Tween.SetExtension(tween, () => tween.startTime = startTime);
        public static TweenAction SetBreakPoint(this TweenAction tween, Func<bool> breakPoint) => Tween.SetExtension(tween, () => tween.breakPoint = breakPoint);
        public static TweenAction SetBreakObject(this TweenAction tween, GameObject breakObject) => Tween.SetExtension(tween, () => (tween.breakObject, tween.breakDestroy) = (breakObject, true));

        #endregion Action Extensions
    }
}
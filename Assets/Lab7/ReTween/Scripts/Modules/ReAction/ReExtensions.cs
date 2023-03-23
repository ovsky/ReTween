using System;

namespace ReTween
{
    public static class ReExtensions
    {
        #region Action Extensions

        public static void SetEase(this TweenAction tween, Ease ease) => tween.ease = ease;
        public static void SetDelay(this TweenAction tween, float delay) => tween.delay = delay;
        public static void SetDuration(this TweenAction tween, float duration) => tween.duration = duration;
        public static void SetStart(this TweenAction tween, float start) => tween.start = start;
        public static void SetAction(this TweenAction tween, Action<float> action) => tween.function = action;

        #endregion Action Extensions
    }
}
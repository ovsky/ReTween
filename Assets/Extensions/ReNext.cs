using System;
using UnityEngine;

namespace ReTween
{
    public static class ReStart
    {
        public static TweenAction Start(TweenAction tweenAction)
                 => Tween.Add(tweenAction);

        public static TweenAction Start(Action<float> action, float delay = 0f, float duration = 1f, Ease ease = default)
             => Tween.Add(new TweenAction((float time) => action(time), duration, delay, ease));
    }

    public static class ReNext
    {
        #region ReNext

        public static TweenAction Next(this TweenAction tweenAction, Action action, float delay = 0f, float duration = 1f, Ease ease = default)
                    => Tween.Add(new TweenAction((float _) => action.Invoke(), duration, tweenAction.duration + tweenAction.delay + Time.time - tweenAction.start + delay, ease));

        public static TweenAction Next(this TweenAction tweenAction, Action<float> action, float delay = 0f, float duration = 1f, Ease ease = default)
            => Tween.Add(new TweenAction((float time) => action.Invoke(time), duration, tweenAction.duration + tweenAction.delay + Time.time - tweenAction.start + delay, ease));

        public static TweenAction Next(this TweenAction tweenAction, Action<float> action, float delay = 0f)
                => Tween.Add(new TweenAction((float time) => action.Invoke(time), 0f, tweenAction.duration + tweenAction.delay + Time.time + delay - tweenAction.start, default));

        #endregion ReNext
    }
}
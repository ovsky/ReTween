using System;
using UnityEngine;

namespace ReTween
{
    public static class ReNext
    {
        #region ReNext

        public static TweenAction Next(this TweenAction tweenAction, Action<float> action, float delay = 0f, float duration = 0f)
            => Tween.Add(new TweenAction(action, duration, tweenAction.duration + tweenAction.delay + Time.time + delay - tweenAction.startTime, default));

        public static TweenAction Next(this TweenAction tweenAction, Action action, float delay = 0f, float duration = 0f, Ease ease = default)
            => Tween.Add(new TweenAction((float _) => action.Invoke(), duration, tweenAction.duration + tweenAction.delay + Time.time - tweenAction.startTime + delay, ease));


        public static TweenAction Next(this TweenAction tweenAction, TweenAction action, float delay = 0f, float duration = 0f)
        {
            action.SetDelay(action.delay + tweenAction.duration + tweenAction.delay + Time.time + delay - tweenAction.startTime);
            action.SetDuration(duration);

            return Tween.Add(action);
        }

        #endregion ReNext

        #region ReNext IF

        public static TweenAction NextIf(this TweenAction tweenAction, Func<bool> condition, Action nextAction, float delay = 0f, float duration = 0f)
            => condition.Invoke() ? Next(tweenAction, nextAction, delay, duration) : tweenAction;

        public static TweenAction NextIf(this TweenAction tweenAction, Func<bool> condition, TweenAction nextAction, float delay = 0f, float duration = 0f)
            => condition.Invoke() ? Next(tweenAction, nextAction, delay, duration) : tweenAction;

        #endregion ReNext IF

    }
}
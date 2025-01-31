using System;
using UnityEngine;

namespace ReTween
{
    public static class ReCore
    {
        #region ReCore Start

        public static TweenAction Start(TweenAction tweenAction)
            => Tween.Add(tweenAction);

        public static TweenAction Start(Action<float> action, float delay = 0f, float duration = 0f, Ease ease = default)
             => Tween.Add(new TweenAction(action, duration, delay, ease));

        #endregion ReCore Start

        #region ReCore Join

        public static TweenAction Join(this TweenAction tweenAction, TweenAction action, float delay = 0f)
        {
            action.delay += tweenAction.delay + Time.time + delay - tweenAction.startTime;
            return Tween.Add(action);
        }

        #endregion ReCore Join

        #region ReCore Stop

        public static void Stop(this TweenAction tweenAction)
        {
            Tween.Remove(tweenAction);
        }

        public static void Stop(this TweenAction tweenAction, float delay)
        {
            Tween.Add(new TweenAction((_) => Tween.Remove(tweenAction), 0f, delay, default));
        }

        public static TweenAction StopAction(this TweenAction tweenAction, float delay = 0)
        {
            return Tween.Add(new TweenAction((_) => Tween.Remove(tweenAction), 0f, delay, default));
        }

        #endregion ReCore Stop
    }
}
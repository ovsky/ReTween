using System;
using UnityEngine;

namespace ReTween
{
    public static class ReStart
    {
        public static TweenAction Start(TweenAction tweenAction)
            => Tween.Add(tweenAction);

        public static TweenAction Start(Action<float> action, float delay = 0f, float duration = 1f, Ease ease = default)
             => Tween.Add(new TweenAction(action, duration, delay, ease));
    }

    public static class ReNext
    {
        #region ReNext

        // public static TweenAction Next(this TweenAction tweenAction, Action action, float delay = 0f, float duration = 1f, Ease ease = default)
        // => Tween.Add(new TweenAction((float _) => action.Invoke(), duration, tweenAction.duration + tweenAction.delay + Time.time - tweenAction.start + delay, ease));

        // public static TweenAction Next(this TweenAction tweenAction, Action<float> action, float delay = 0f, float duration = 1f, Ease ease = default)
        // => Tween.Add(new TweenAction(action, duration, tweenAction.duration + tweenAction.delay + Time.time - tweenAction.start + delay, ease));

        public static TweenAction Next(this TweenAction tweenAction, Action<float> action, float delay = 0f)
                // => Tween.Add(new TweenAction(action, 0f, tweenAction.duration + tweenAction.delay + Time.time + delay - tweenAction.start, default));
                => Tween.Add(new TweenAction(action, 1f, tweenAction.duration + tweenAction.delay + Time.time + delay - tweenAction.startTime, default));


        // public static TweenAction Next(this TweenAction tweenAction, Action action, float delay = 0f)
        //         // => Tween.Add(new TweenAction(action, 0f, tweenAction.duration + tweenAction.delay + Time.time + delay - tweenAction.start, default));
        //         => Tween.Add(new TweenAction(action, 1f, tweenAction.duration + tweenAction.delay + Time.time + delay - tweenAction.start, default));


        public static TweenAction Next(this TweenAction tweenAction, Action action, float delay = 0f, float duration = 1f, Ease ease = default)
            => Tween.Add(new TweenAction((float _) => action.Invoke(), duration, tweenAction.duration + tweenAction.delay + Time.time - tweenAction.startTime + delay, ease));


        public static TweenAction Next(this TweenAction tweenAction, TweenAction action, float delay = 0f)
        {
            action.delay += tweenAction.duration + tweenAction.delay + Time.time + delay - tweenAction.startTime;
            return Tween.Add(action);
        }

        public static TweenAction Join(this TweenAction tweenAction, TweenAction action, float delay = 0f)
        {
            action.delay += tweenAction.delay + Time.time + delay - tweenAction.startTime;
            return Tween.Add(action);
        }
        // => Tween.Add(new TweenAction(action, 0f, tweenAction.duration + tweenAction.delay + Time.time + delay - tweenAction.start, default));


        #endregion ReNext
    }
}
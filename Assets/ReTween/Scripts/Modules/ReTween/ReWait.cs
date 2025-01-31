using System;
using UnityEngine;

namespace ReTween
{
    public partial class Tween
    {
        #region Wait
        public static TweenAction Wait(Action<float> action, float delay = 0f, Ease ease = null)
            => Tween.Add(new TweenAction((float time) => action.Invoke(time), 0f, delay, ease));

        public static TweenAction Wait(float delay = 0f, Action action = null)
            => Tween.Add(new TweenAction((_) => action.Invoke(), 0f, delay));

        public static TweenAction Wait(float time = 0f)
            => Tween.Add(new TweenAction((_) => { }, 0f, time));

        public static TweenAction Wait(Func<bool> codition, float delay = 0f, Action action = null)
        {
            if (codition())
            {
                return Tween.Add(new TweenAction((_) => action.Invoke(), 0f, delay));
            }
            else
            {
                return new TweenAction((_) => { }, 0f, delay);
            }
        }

        #endregion Wait
    }
}
using System;
using UnityEngine;

namespace ReTween
{
    public partial class Tween
    {
        #region Wait
        public static TweenAction Wait(Action<float> action, float delay = 0f, Ease ease = null)
            => Tween.Add(new TweenAction((float time) => action.Invoke(time), 0f, delay, ease));

        public static TweenAction Wait(float time = 0f)
            => Tween.Add(new TweenAction((_) => { }, 0f, time));

        #endregion Wait
    }
}
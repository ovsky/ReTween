using System;
using UnityEngine;

namespace ReTween
{
    public partial class Tween
    {
        #region Delay
        [Obsolete("Use Tween.Wait instead!")]
        public static void Delay(Action<float> action, float delay = 0f, Ease ease = null)
            => Tween.Add(new TweenAction((float time) => action.Invoke(time), 0f, delay, ease));

        #endregion Delay
    }
}
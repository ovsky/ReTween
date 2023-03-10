using System;
using UnityEngine;
using UnityEngine.UI;

namespace ReTween
{
    public partial class Tween
    {
        #region  Canvas Group

        public static TweenAction Alpha(CanvasGroup group, float begin, Func<float> target, float duration = 1f, float delay = 0f, Ease ease = null)
            => Tween.Add(new TweenAction((float time) => group.alpha = Mathf.LerpUnclamped(begin, target.Invoke(), time), duration, delay, ease));

        public static TweenAction Alpha(CanvasGroup group, float begin, float target, float duration = 1f, float delay = 0f, Ease ease = null)
            => Tween.Add(new TweenAction((float time) => group.alpha = Mathf.LerpUnclamped(begin, target, time), duration, delay, ease));

        public static TweenAction Alpha(CanvasGroup group, float target, float duration = 1f, float delay = 0f, Ease ease = null)
            => Tween.Add(new TweenAction((float time) => group.alpha = Mathf.LerpUnclamped(group.alpha, target, time), duration, delay, ease));

        #endregion Canvas Group
    }
}
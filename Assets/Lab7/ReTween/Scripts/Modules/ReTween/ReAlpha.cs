using System;
using UnityEngine;
using UnityEngine.UI;

namespace ReTween
{
    public partial class Tween
    {
        #region  Canvas Group

        // public static TweenAction Alpha(CanvasGroup group, Func<float> target, float begin, float duration = 1f, float delay = 0f, Ease ease = null)
        //     => Tween.Add(new TweenAction((float time) => group.alpha = Mathf.LerpUnclamped(begin, target.Invoke(), time), duration, delay, ease));

        // public static TweenAction Alpha(CanvasGroup group, float begin, float target, float duration = 1f, float delay = 0f, Ease ease = null)
        //     => Tween.Add(new TweenAction((float time) => group.alpha = Mathf.LerpUnclamped(begin, target, time), duration, delay, ease));

        public static TweenAction Alpha(CanvasGroup group, float begin, float target, float duration, float delay = 0f, Ease ease = null)
            => Tween.Add(new TweenAction((float time) => group.alpha = Mathf.LerpUnclamped(begin, target, time), duration, delay, ease));

        public static TweenAction Alpha(CanvasGroup group, float target, float duration = 1f, float delay = 0f, Ease ease = null)
            => Tween.Add(new TweenAction((float time) => group.alpha = Mathf.LerpUnclamped(group.alpha, target, time), duration, delay, ease));

        #endregion Canvas Group

        #region  UI.Image

        public static TweenAction Alpha(Image image, float begin, Func<float> target, float duration = 1f, float delay = 0f, Ease ease = null)
            => Tween.Add(new TweenAction((float time) => image.color = new Color(image.color.r, image.color.g, image.color.b, Mathf.LerpUnclamped(begin, target.Invoke(), time)), duration, delay, ease));

        public static TweenAction Alpha(Image image, float begin, float target, float duration = 1f, float delay = 0f, Ease ease = null)
            => Tween.Add(new TweenAction((float time) => image.color = new Color(image.color.r, image.color.g, image.color.b, Mathf.LerpUnclamped(begin, target, time)), duration, delay, ease));

        public static TweenAction Alpha(Image image, float target, float duration = 1f, float delay = 0f, Ease ease = null)
            => Tween.Add(new TweenAction((float time) => image.color = new Color(image.color.r, image.color.g, image.color.b, Mathf.LerpUnclamped(image.color.a, target, time)), duration, delay, ease));

        #endregion UI.Image
    }
}
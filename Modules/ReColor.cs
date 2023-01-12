using System;
using UnityEngine;
using UnityEngine.UI;

namespace ReTween
{
    public partial class Tween
    {
        #region  SprtieRenderer

        public static void Color(SpriteRenderer renderer, Color target, float duration = 1f, float delay = 0f, Ease ease = null)
            => Color(renderer, renderer.color, target, duration, delay, ease);

        public static void Color(SpriteRenderer renderer, Color begin, Color target, float duration = 1f, float delay = 0f, Ease ease = null)
            => tweenActions.Add(new TweenAction((float time) => renderer.color = UnityEngine.Color.LerpUnclamped(begin, target, time), duration, delay, ease));

        public static void Color(SpriteRenderer renderer, Color begin, Func<Color> target, float duration = 1f, float delay = 0f, Ease ease = null)
             => tweenActions.Add(new TweenAction((float time) => renderer.color = UnityEngine.Color.LerpUnclamped(begin, target(), time), duration, delay, ease));

        #endregion SpriteRenderer

        #region  Image

        public static void Color(Image image, Color target, float duration = 1f, float delay = 0f, Ease ease = null)
            => tweenActions.Add(new TweenAction((float time) => image.color = UnityEngine.Color.LerpUnclamped(image.color, target, time), duration, delay, ease));

        public static void Color(Image image, Color begin, Color target, float duration = 1f, float delay = 0f, Ease ease = null)
            => tweenActions.Add(new TweenAction((float time) => image.color = UnityEngine.Color.LerpUnclamped(begin, target, time), duration, delay, ease));

        #endregion Image
    }
}
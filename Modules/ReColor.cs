using System;
using UnityEngine;
using UnityEngine.UI;

namespace ReTween
{
    public partial class Tween
    {
        #region  SprtieRenderer

        public static TweenAction Color(SpriteRenderer renderer, Color target, float duration = 1f, float delay = 0f, Ease ease = null)
            => Tween.Color(renderer, renderer.color, target, duration, delay, ease);

        public static TweenAction Color(SpriteRenderer renderer, Color begin, Color target, float duration = 1f, float delay = 0f, Ease ease = null)
            => Tween.Add(new TweenAction((float time) => renderer.color = UnityEngine.Color.LerpUnclamped(begin, target, time), duration, delay, ease));

        public static TweenAction Color(SpriteRenderer renderer, Color begin, Func<Color> target, float duration = 1f, float delay = 0f, Ease ease = null)
             => Tween.Add(new TweenAction((float time) => renderer.color = UnityEngine.Color.LerpUnclamped(begin, target(), time), duration, delay, ease));

        #endregion SpriteRenderer

        #region  Image

        public static TweenAction Color(Image image, Color target, float duration = 1f, float delay = 0f, Ease ease = null)
            => Tween.Add(new TweenAction((float time) => image.color = UnityEngine.Color.LerpUnclamped(image.color, target, time), duration, delay, ease));

        public static TweenAction Color(Image image, Color begin, Color target, float duration = 1f, float delay = 0f, Ease ease = null)
            => Tween.Add(new TweenAction((float time) => image.color = UnityEngine.Color.LerpUnclamped(begin, target, time), duration, delay, ease));

        #endregion Image
    }
}
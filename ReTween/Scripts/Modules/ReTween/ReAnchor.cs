using System;
using UnityEngine;
using UnityEngine.UI;

namespace ReTween
{
    public partial class Tween
    {
        #region AnchorMax

        public static TweenAction AnchorMax(RectTransform rect, Func<Vector2> target, Vector2 begin, float duration = 1f, float delay = 0f, Ease ease = null)
            => Tween.Add(new TweenAction((float time) => rect.anchorMax = Vector2.LerpUnclamped(begin, target.Invoke(), time), duration, delay, ease));

        public static TweenAction AnchorMax(RectTransform rect, Vector2 begin, Vector2 target, float duration, float delay = 0f, Ease ease = null)
            => Tween.Add(new TweenAction((float time) => rect.anchorMax = Vector2.LerpUnclamped(begin, target, time), duration, delay, ease));

        public static TweenAction AnchorMax(RectTransform rect, Vector2 target, float duration, float delay = 0f, Ease ease = null)
            => Tween.Add(new TweenAction((float time) => rect.anchorMax = Vector2.LerpUnclamped(rect.anchorMax, target, time), duration, delay, ease));

        #endregion AnchorMax

        #region AnchorMin

        public static TweenAction AnchorMin(RectTransform rect, Func<Vector2> target, Vector2 begin, float duration = 1f, float delay = 0f, Ease ease = null)
            => Tween.Add(new TweenAction((float time) => rect.anchorMin = Vector2.LerpUnclamped(begin, target.Invoke(), time), duration, delay, ease));

        public static TweenAction AnchorMin(RectTransform rect, Vector2 begin, Vector2 target, float duration, float delay = 0f, Ease ease = null)
            => Tween.Add(new TweenAction((float time) => rect.anchorMin = Vector2.LerpUnclamped(begin, target, time), duration, delay, ease));

        public static TweenAction AnchorMin(RectTransform rect, Vector2 target, float duration, float delay = 0f, Ease ease = null)
            => Tween.Add(new TweenAction((float time) => rect.anchorMin = Vector2.LerpUnclamped(rect.anchorMin, target, time), duration, delay, ease));

        #endregion AnchorMin

        #region AnchoredPosition

        public static TweenAction AnchoredPosition(RectTransform rect, Func<Vector2> target, Vector2 begin, float duration = 1f, float delay = 0f, Ease ease = null)
            => Tween.Add(new TweenAction((float time) => rect.anchoredPosition = Vector2.LerpUnclamped(begin, target.Invoke(), time), duration, delay, ease));

        public static TweenAction AnchoredPosition(RectTransform rect, Vector2 begin, Vector2 target, float duration, float delay = 0f, Ease ease = null)
            => Tween.Add(new TweenAction((float time) => rect.anchoredPosition = Vector2.LerpUnclamped(begin, target, time), duration, delay, ease));

        public static TweenAction AnchoredPosition(RectTransform rect, Vector2 target, float duration, float delay = 0f, Ease ease = null)
            => Tween.Add(new TweenAction((float time) => rect.anchoredPosition = Vector2.LerpUnclamped(rect.anchoredPosition, target, time), duration, delay, ease));

        #endregion AnchoredPosition
    }
}
using System;
using UnityEngine;

namespace ReTween
{
    public partial class Tween
    {
        #region Material Property

        public static TweenAction MaterialFloat(Material material, string property, float begin, float target, float duration = 1f, float delay = 0f, Ease ease = null)
            => Tween.Add(new TweenAction((float time) => material.SetFloat(property, Mathf.LerpUnclamped(begin, target, time)), duration, delay, ease));

        public static TweenAction MaterialFloat(Material material, string property, float begin, Func<float> target, float duration = 1f, float delay = 0f, Ease ease = null)
             => Tween.Add(new TweenAction((float time) => material.SetFloat(property, Mathf.LerpUnclamped(begin, target(), time)), duration, delay, ease));

        public static TweenAction MaterialFloat(Material material, string property, float target, float duration = 1f, float delay = 0f, Ease ease = null)
                => Tween.Add(new TweenAction((float time) => material.SetFloat(property, Mathf.LerpUnclamped(material.GetFloat(property), target, time)), duration, delay, ease));

        #endregion Material Property
    }
}
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

        #region Set Keyword State

        public static TweenAction EnableKeyword(Material material, string keyword, bool enabled = true, float duration = 1f, float delay = 0f, Ease ease = null) =>
            Tween.Add(new TweenAction((float time) => SetKeywordState(material, keyword, enabled), duration, delay, ease));

        public static TweenAction EnableKeyword(Material material, string keyword, float duration = 1f, float delay = 0f, Ease ease = null) =>
            Tween.Add(new TweenAction((float time) => material.EnableKeyword(keyword), duration, delay, ease));

        public static TweenAction DisableKeyword(Material material, string keyword, float duration = 1f, float delay = 0f, Ease ease = null) =>
            Tween.Add(new TweenAction((float time) => material.DisableKeyword(keyword), duration, delay, ease));

        #endregion Set Keyword State

        #region Set Keyword State Method

        private static void SetKeywordState(Material material, string keyword, bool state)
        {
            switch (state)
            {
                case true: material.EnableKeyword(keyword); break;
                case false: material.DisableKeyword(keyword); break;
            }
        }

        #endregion Set Keyword State Method
    }
}
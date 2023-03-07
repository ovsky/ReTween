using System;
using UnityEngine;

namespace ReTween
{
    public struct TweenAction
    {
        public float delay;
        public float duration;
        public float start;

        public Ease ease;

        public Action<float> action;

        public TweenAction(Action<float> action, float duration = 1f, float delay = 0f, Ease ease = null)
        {
            start = Time.time;
            this.action = action;
            this.duration = duration;
            this.delay = delay;

            if (ease?.easeType == Easing.Custom)
            {
                if (ease.customCurve == null)
                {
                    Debug.LogError($"Ease named [{ease.easeName}] is not valid! Its curve is null.");
                    this.ease = Ease.Default;
                }
                else
                {
                    EaseCalculator.SetCustom(ease.easeName, ease.customCurve, unique: true);
                }
            }

            this.ease = ease ?? Ease.Default;
        }
    }
}
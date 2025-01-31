using System;
using UnityEngine;

namespace ReTween
{
    public class TweenAction : CustomYieldInstruction
    {
        public float delay;
        public float duration;
        public float startTime;

        public Ease ease;

        public Action<float> function;

        public bool finished => Time.time - startTime >= duration + delay;
        public override bool keepWaiting => !finished;

        public Func<bool> breakPoint { get; set; } = null;
        public GameObject breakObject { get; set; } = null;
        public bool breakDestroy { get; set; } = false;

        public TweenAction(Action<float> action, float duration = 1f, float delay = 0f, Ease ease = null)
        {
            startTime = Time.time;
            this.function = action;
            this.duration = duration;
            this.delay = delay;

            if (ease?.easeType == EaseType.Custom)
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
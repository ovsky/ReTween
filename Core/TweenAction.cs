using System;
using UnityEngine;

namespace ReTween
{
    public struct TweenAction
    {
        public float delay;
        public float duration;
        public float start;

        public AnimationCurve ease;

        public Action<float> action;

        public TweenAction(Action<float> action, float duration = 1f, float delay = 0f, AnimationCurve ease = null)
        {
            start = Time.time;
            this.action = action;
            this.duration = duration;
            this.delay = delay;
            this.ease = ease;
        }
    }
}
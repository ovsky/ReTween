using System;
using UnityEngine;

namespace ReTween
{
    public partial class Tween
    {
        #region FOV

        public static TweenAction FOV(Camera cam, float begin = default, float target = default, float duration = 1f, float delay = 0f, Ease ease = null)
            => Tween.Add(new TweenAction((float time) => cam.fieldOfView = Mathf.LerpUnclamped(begin, target, time), duration, delay, ease));

        public static TweenAction FOV(Camera cam, float target = default, float duration = 1f, float delay = 0f, Ease ease = null)
            => Tween.Add(new TweenAction((float time) => cam.fieldOfView = Mathf.LerpUnclamped(cam.fieldOfView, target, time), duration, delay, ease));


        public static TweenAction FOV(Camera cam, Func<float> target, float duration = 1f, float delay = 0f, Ease ease = null)
            => Tween.Add(new TweenAction((float time) => cam.fieldOfView = Mathf.LerpUnclamped(cam.fieldOfView, target(), time), duration, delay, ease));

        #endregion FOV
    }
}
using System;
using UnityEngine;

namespace ReTween
{
    public partial class Tween
    {
        #region Transform

        // public static TweenAction Scale(Transform transform, Vector3 target, float duration = 1f, float delay = 0f, Ease ease = null)
        //     => Scale(transform, transform.localScale, target, duration, delay, ease);


        public static TweenAction Scale(Func<Transform> transform, Vector3 target, float duration = 1f, float delay = 0f, Ease ease = null)
                  => Tween.Add(new TweenAction((float time) => transform().localScale = Vector3.LerpUnclamped(transform().localScale, target, time), duration, delay, ease));


        public static TweenAction Scale(Transform transform, Vector3 target, float duration = 1f, float delay = 0f, Ease ease = null)
        {
            Vector3? initial = null;
            return Tween.Add(new TweenAction((float time) =>
            {
                initial ??= transform.localScale;
                transform.localScale = Vector3.LerpUnclamped(initial.Value, target, time);
            }, duration, delay, ease));
        }


        public static TweenAction Scale(Transform transform, Vector3 begin, Vector3 target, float duration = 1f, float delay = 0f, Ease ease = null)
            => Tween.Add(new TweenAction((float time) => transform.localScale = Vector3.LerpUnclamped(begin, target, time), duration, delay, ease));

        public static TweenAction Scale(Transform transform, Vector3 begin, Func<Vector3> target, float duration = 1f, float delay = 0f, Ease ease = null)
            => Tween.Add(new TweenAction((float time) => transform.localScale = Vector3.LerpUnclamped(begin, target(), time), duration, delay, ease));

        #endregion Transform
    }
}
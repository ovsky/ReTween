using System;
using UnityEngine;

namespace ReTween
{
    public partial class Tween
    {
        #region Animator

        public static TweenAction OnAnimatorState(Animator animator, string stateName, float duration = 1f, float delay = 0f, Ease ease = null, int layerIndex = 0) =>
            Tween.Add(new TweenAction((float time) => animator.GetCurrentAnimatorStateInfo(layerIndex).IsName(stateName), duration, delay, ease));

        public static TweenAction OnAnimatorState(Animator animator, string stateName, Action action, float duration = 1f, float delay = 0f, Ease ease = null, int layerIndex = 0)
        {
            return Tween.Add(new TweenAction((float time) =>
            {
                Debug.Log(animator.GetCurrentAnimatorStateInfo(layerIndex).IsName(stateName));
                if (animator.GetCurrentAnimatorStateInfo(layerIndex).IsName(stateName))
                {
                    action.Invoke();
                }
            }, duration, delay, ease));
        }

        public static TweenAction OnStateComplete(Animator animator, string stateName, Action action, float duration = 1f, float delay = 0f, Ease ease = null, int layerIndex = 0)
        {
            return Tween.Add(new TweenAction((float time) =>
            {
                if (animator.GetCurrentAnimatorStateInfo(layerIndex).IsName(stateName) && animator.GetCurrentAnimatorStateInfo(layerIndex).normalizedTime >= 1)
                {
                    action.Invoke();
                }
            }, duration, delay, ease));
        }

        #endregion Animator
    }
}
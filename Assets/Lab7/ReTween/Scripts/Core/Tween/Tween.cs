using System;
using System.Collections;
using System.Collections.Generic;
using ReTween.Utilities;
using UnityEngine;

namespace ReTween
{
    [DefaultExecutionOrder(100)]
    public partial class Tween : AutoBehaviour<Tween>
    {
        #region  Properties

        private readonly List<TweenAction> tweenActions = new List<TweenAction>();

        #endregion  Properties

        #region  Tween Loop

        [RuntimeInitializeOnLoadMethod]
        public static void OnLoad() => AutoInitialize();

        public override void OnInitialized()
        {
            // #if UNITY_EDITOR
            //             UnityEditor.MonoScript monoScript = UnityEditor.MonoScript.FromMonoBehaviour(this);
            //             UnityEditor.MonoImporter.SetExecutionOrder(monoScript, 100);
            // #endif

            Instance.StartCoroutine(Loop());
        }

        private IEnumerator Loop()
        {
            while (true)
            {
                TweenAction action;

                for (int i = 0; i < tweenActions.Count; i++)
                {
                    action = tweenActions[i];

                    float time = (Time.time - action.startTime - action.delay) / action.duration;

                    if (time >= 0f)
                    {
                        if ((action.breakDestroy && action.breakObject == null) || action.breakPoint != null && action.breakPoint())
                        {
                            tweenActions.RemoveAt(i);
                            continue;
                        }

                        if (time >= 1f)
                        {
                            time = 1f;
                            tweenActions.RemoveAt(i);
                        }

                        action.function(EaseCalculator.Evaluate(time, action.ease));
                    }
                }

                yield return null;
            }
        }

        public static TweenAction Add(TweenAction action)
        {
            Instance.tweenActions.Add(action);
            return action;
        }

        public static TweenAction SetExtension(TweenAction tween, Action action)
        {
            action.Invoke();
            return tween;
        }

        public static TweenAction Remove(TweenAction action)
        {
            Instance.tweenActions.Remove(action);
            return action;
        }

        public static void Clear() => Instance.tweenActions.Clear();

        #endregion Tween Loop
    }
}
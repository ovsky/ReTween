using System.Collections;
using System.Collections.Generic;
using ReTween.Utilities;
using UnityEngine;

namespace ReTween
{
    public partial class Tween : AutoBehaviour<Tween>
    {
        #region  Properties

        private readonly List<TweenAction> tweenActions = new List<TweenAction>();
        private readonly List<TweenAction> removeActions = new List<TweenAction>();

        #endregion  Properties

        #region  Tween Loop

        [RuntimeInitializeOnLoadMethod]
        public static void OnLoad() => AutoInitialize();

        private IEnumerator Loop()
        {
            while (true)
            {
                yield return new WaitForEndOfFrame();

                foreach (TweenAction action in tweenActions)
                {
                    float time = (Time.time - action.start - action.delay) / action.duration;

                    if (time > 0f)
                    {
                        if (time >= 1f)
                        {
                            time = 1f;
                            removeActions.Add(action);
                        }

                        action.action(EaseCalculator.Evaluate(time, action.ease));
                    }
                }

                foreach (TweenAction remove in removeActions)
                {
                    tweenActions.Remove(remove);
                }
            }
        }

        public override void OnInitialized() => Instance.StartCoroutine(Loop());

        public static TweenAction Add(TweenAction action)
        {
            Instance.tweenActions.Add(action);
            return action;
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
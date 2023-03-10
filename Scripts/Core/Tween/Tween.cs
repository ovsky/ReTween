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
        // private readonly List<TweenAction> removeActions = new List<TweenAction>();
        // private readonly List<int> removeIndex = new List<int>();


        #endregion  Properties

        #region  Tween Loop

        [RuntimeInitializeOnLoadMethod]
        public static void OnLoad() => AutoInitialize();

        public override void OnInitialized() => Instance.StartCoroutine(Loop());

        private IEnumerator Loop()
        {
            while (true)
            {
                yield return new WaitForEndOfFrame();

                Debug.Log("Tween Loop");
                Debug.Log(tweenActions.Count);

                TweenAction action;

                for (int i = 0; i < tweenActions.Count; i++)
                {
                    action = tweenActions[i];
                    float time = (Time.time - action.start - action.delay) / action.duration;

                    if (time > 0f)
                    {
                        if (time >= 1f)
                        {
                            time = 1f;
                            tweenActions.RemoveAt(i);
                        }

                        action.function(EaseCalculator.Evaluate(time, action.ease));
                    }
                }
            }
        }

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
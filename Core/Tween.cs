using System.Collections;
using System.Collections.Generic;
using ReTween.Utilities;
using UnityEngine;

namespace ReTween
{
    public partial class Tween : AutoBehaviour<Tween>
    {
        #region  Properties

        private static readonly List<TweenAction> tweenActions = new List<TweenAction>();
        private static readonly List<TweenAction> removeActions = new List<TweenAction>();

        #endregion  Properties

        #region  Tween Loop

        private static IEnumerator Loop()
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

                        action.action(Easing.Evaluate(time));
                    }
                }

                foreach (TweenAction remove in removeActions)
                {
                    tweenActions.Remove(remove);
                }
            }
        }

        public void Add(TweenAction action) => tweenActions.Add(action);

        public void Remove(TweenAction action) => tweenActions.Remove(action);

        public void Clear(TweenAction action) => tweenActions.Clear();

        #endregion Tween Loop
    }
}
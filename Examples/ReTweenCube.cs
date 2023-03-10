using System;
using System.Collections;
using System.Collections.Generic;
using ReTween;
using ReTween.Utilities;
using UnityEngine;

namespace ReTween.Examples
{

    public class ReTweenCube : MonoBehaviour
    {
        [SerializeField] Ease ep2;
        [SerializeField] Ease ep4;
        [SerializeField] EaseType ep1;
        [SerializeField] EaseType ep12;

        // void Start()
        // {
        //     Tween.Scale(transform, Vector3.one * 2, 1f, 0f, EaseType.ElasticOut);
        //     // Tween.Position(transform, Vector3.right * 3f, 1f, 0f, EaseType.QuadInOut).Next(() => Tween.Position(transform, Vector3.left * 3f, 1f, 0f, EaseType.QuadInOut)).Next(() => Tween.Position(transform, Vector3.zero, 1f, 0f, EaseType.QuadInOut));
        //     Tween.Position(transform, Vector3.right * 3f, 1f, 0f, EaseType.QuadInOut)
        //     .Next((_) => Tween.Position(transform, transform.position + Vector3.right * 3f, Vector3.up * 3f, 1f, 0f), 1f);


        //     // Tween.Position(transform, Vector3.left * 3f, 1f, 8f, EaseType.QuadInOut);
        //     // Tween.Position(transform, Vector3.zero, 1f, 12f, EaseType.QuadInOut);

        //     // Tween.Position(transform, transform.position + Vector3.right * 3f, Vector3.up * 5f, 1f, 1.5f, EaseType.QuadInOut);
        // }

        IEnumerator Start()
        {
            yield return Tween.Scale(transform, Vector3.one * 2, 1f, 0f, EaseType.ElasticOut);
            yield return Tween.Position(transform, Vector3.right * 3f, 1f, 0f, EaseType.QuadInOut);
            yield return Tween.Position(transform, Vector3.up * 3f, 1f, 0f, EaseType.QuadInOut);
            yield return Tween.Wait(1f);
            yield return Tween.Scale(transform, Vector3.one * 3f, 1f, 0f, EaseType.QuadInOut)
                .Next(Tween.Scale(transform, Vector3.one * 3f, Vector3.one * 0f, 1f, 0f, EaseType.QuadInOut))
                .Next(Tween.Scale(transform, Vector3.one * 4f, 1f, 0f, EaseType.QuadInOut))
                .Next(Tween.Wait(3f))
                .Next(Tween.Scale(transform, Vector3.one * 2f, 1f, 0f, EaseType.QuadInOut));

            yield return Tween.Position(transform, Vector3.right * 3f, 1f, 0f, EaseType.QuadInOut)
                .Join(Tween.Scale(transform, Vector3.zero, 4f, 0f, EaseType.QuadInOut));

            // yield return Tween.Position(transform, Vector3.right * 3f, 1f, 0f, EaseType.QuadInOut).Next((_) => Tween.Position(transform, transform.position + Vector3.right * 3f, Vector3.up * 3f, 1f, 0f), 1f);
        }
    }

    public class WaitForTweenAction : CustomYieldInstruction
    {
        TweenAction action;

        public WaitForTweenAction(TweenAction x)
        {
            action = x;
        }

        public override bool keepWaiting
        {
            get
            {
                return !action.finished;
            }
        }
    }

    class WaitWhile1 : CustomYieldInstruction
    {
        Func<bool> m_Predicate;

        public override bool keepWaiting { get { return m_Predicate(); } }

        public WaitWhile1(Func<bool> predicate) { m_Predicate = predicate; }
    }
}

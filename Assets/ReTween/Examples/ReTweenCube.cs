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

        void Start()
        {
            ReTween.Tween.Scale(transform, Vector3.one * 2, 1f, 0f, EaseType.ElasticOut);
        }
    }
}

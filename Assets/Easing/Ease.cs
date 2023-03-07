using System;
using UnityEngine;

namespace ReTween
{
    [Serializable]
    public class Ease
    {
        [HideInInspector] public string easeName;
        [HideInInspector] public AnimationCurve customCurve;

        public EaseType easeType = EaseType.QuadOut;

        public static Ease Default => EaseManager.Default;

        public Ease(EaseType easeType, string easeName = default) => (this.easeType, this.easeName) = (easeType, easeName);
        public Ease(AnimationCurve customCurve, string easeName = default) => (this.customCurve, this.easeName) = (customCurve, easeName);

        public Ease SeteaseName(string easeName)
        {
            this.easeName = easeName;
            return this;
        }

        public static Ease GetCustom(string easeName) => EaseManager.GetCustom(easeName);
        public static Ease SetCustom(string easeName, AnimationCurve curve) => EaseManager.SetCustom(easeName, curve);

        public static implicit operator EaseType(Ease ease) => ease.easeType;
        public static implicit operator Ease(AnimationCurve customCurve) => new Ease(customCurve);
        public static implicit operator Ease(EaseType easeType) => new Ease(easeType, easeType.ToString());
    }
}
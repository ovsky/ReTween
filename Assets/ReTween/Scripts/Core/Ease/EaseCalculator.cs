using UnityEngine;

namespace ReTween
{
    #region Ease Evaluation

    public partial class EaseCalculator
    {
        public static float Evaluate(float time, AnimationCurve ease = default)
            => ease.Evaluate(time);

        public static float Evaluate(float time, Easing ease = default)
            => Calculate(ease, time);

        public static float Evaluate(float time, Ease ease = null)
            => Calculate(ease, time, ease?.customCurve);

        #endregion Ease Evaluation

        #region Ease Calculation

        public static float Calculate(Easing ease, float t, AnimationCurve custom = null) => ease switch
        {
            Easing.Linear => t,
            Easing.QuadIn => t * t,
            Easing.QuadOut => t * (2f - t),
            Easing.QuadInOut => t < 0.5f ? 2f * t * t : -1f + ((4f - (2f * t)) * t),
            Easing.CubicIn => t * t * t,
            Easing.CubicOut => ((t - 1f) * t * t) + 1f,
            Easing.CubicInOut => t < 0.5f ? 4f * t * t * t : ((t - 1f) * ((2f * t) - 2f) * ((2 * t) - 2)) + 1f,
            Easing.QuartIn => t * t * t * t,
            Easing.QuartOut => 1f - ((t - 1f) * t * t * t),
            Easing.QuartInOut => t < 0.5f ? 8f * t * t * t * t : 1f - (8f * (t - 1f) * t * t * t),
            Easing.QuintIn => t * t * t * t * t,
            Easing.QuintOut => 1f - ((t - 1f) * t * t * t),
            Easing.QuintInOut => t < 0.5f ? 16f * t * t * t * t * t : 1f + (16f * (t - 1f) * t * t * t * t),
            Easing.BounceIn => 1f - BounceOut(1f - t),
            Easing.BounceOut => t < 0.363636374f ? 7.5625f * t * t : t < 0.727272749f ? (7.5625f * (t -= 0.545454562f) * t) + 0.75f : t < 0.909090936f ? (7.5625f * (t -= 0.8181818f) * t) + 0.9375f : (7.5625f * (t -= 21f / 22f) * t) + (63f / 64f),
            Easing.BounceInOut => t < 0.5f ? BounceIn(t * 2f) * 0.5f : (BounceOut((t * 2f) - 1f) * 0.5f) + 0.5f,
            Easing.ElasticIn => -(Mathf.Pow(2, 10 * (--t)) * Mathf.Sin((t - (0.3f / 4f)) * (2 * Mathf.PI) / 0.3f)),
            Easing.ElasticOut => t == 1f ? 1f : 1f - ElasticIn(1f - t),
            Easing.ElasticInOut => (t *= 2f) == 2f ? 1f : t < 1f ? -0.5f * (Mathf.Pow(2f, 10f * (--t)) * Mathf.Sin((t - 0.1125f) * (2f * Mathf.PI) / 0.45f)) : ((Mathf.Pow(2f, -10f * (--t)) * Mathf.Sin((t - 0.1125f) * (2f * Mathf.PI) / 0.45f) * 0.5f) + 1f),
            Easing.CircularIn => -(Mathf.Sqrt(1 - (t * t)) - 1),
            Easing.CircularOut => Mathf.Sqrt(1f - ((--t) * t)),
            Easing.CircularInOut => (t *= 2f) < 1f ? -1f / 2f * (Mathf.Sqrt(1f - (t * t)) - 1f) : 0.5f * (Mathf.Sqrt(1 - ((t -= 2) * t)) + 1),
            Easing.SinusIn => -Mathf.Cos(t * (Mathf.PI * 0.5f)) + 1f,
            Easing.SinusOut => Mathf.Sin(t * (Mathf.PI * 0.5f)),
            Easing.SinusInOut => -0.5f * (Mathf.Cos(Mathf.PI * t) - 1f),
            Easing.ExponentialIn => Mathf.Pow(2f, 10f * (t - 1f)),
            Easing.ExponentialOut => Mathf.Sin(t * (Mathf.PI * 0.5f)),
            Easing.ExponentialInOut => -0.5f * (Mathf.Cos(Mathf.PI * t) - 1f),
            Easing.Custom => custom.Evaluate(t),
            _ => throw new System.NotImplementedException(),
        };

        public static float BounceOut(float t) => t < 0.363636374f ? 7.5625f * t * t : t < 0.727272749f ? (7.5625f * (t -= 0.545454562f) * t) + 0.75f : t < 0.909090936f ? (7.5625f * (t -= 0.8181818f) * t) + 0.9375f : (7.5625f * (t -= 21f / 22f) * t) + (63f / 64f);
        public static float BounceIn(float t) => 1f - BounceOut(1f - t);
        public static float ElasticIn(float t) => -(Mathf.Pow(2, 10 * (--t)) * Mathf.Sin((t - (0.3f / 4f)) * (2 * Mathf.PI) / 0.3f));
    }
    #endregion Ease Calculation
}
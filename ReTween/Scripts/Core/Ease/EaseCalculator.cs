using UnityEngine;

namespace ReTween
{
    #region Ease Evaluation

    public partial class EaseCalculator
    {
        private const float C1 = 1.70158f; // backward easing overshoot constant
        private const float C2 = C1 * 1.525f; // backward easing length constant
        private const float TSST = 7.5625f; // 2.75^2 / bounce easing overshoot constant 

        public static float Evaluate(float time, AnimationCurve ease = default)
            => ease.Evaluate(time);

        public static float Evaluate(float time, EaseType ease = default)
            => Calculate(ease, time);

        public static float Evaluate(float time, Ease ease = null)
            => Calculate(ease, time, ease?.customCurve);

        #endregion Ease Evaluation

        #region Ease Calculation

        public static float Calculate(EaseType ease, float t, AnimationCurve custom = null) => ease switch
        {
            EaseType.Linear => t,
            EaseType.QuadIn => t * t,
            EaseType.QuadOut => t * (2f - t),
            EaseType.QuadInOut => t < 0.5f ? 2f * t * t : -1f + ((4f - (2f * t)) * t),
            EaseType.CubicIn => t * t * t,
            EaseType.CubicOut => ((t - 1f) * t * t) + 1f,
            EaseType.CubicInOut => t < 0.5f ? 4f * t * t * t : ((t - 1f) * ((2f * t) - 2f) * ((2 * t) - 2)) + 1f,
            EaseType.QuartIn => t * t * t * t,
            EaseType.QuartOut => 1f - ((t - 1f) * t * t * t),
            EaseType.QuartInOut => t < 0.5f ? 8f * t * t * t * t : 1f - (8f * (t - 1f) * t * t * t),
            EaseType.QuintIn => t * t * t * t * t,
            EaseType.QuintOut => 1f - ((t - 1f) * t * t * t),
            EaseType.QuintInOut => t < 0.5f ? 16f * t * t * t * t * t : 1f + (16f * (t - 1f) * t * t * t * t),
            EaseType.BounceIn => 1f - BounceOut(1f - t),
            EaseType.BounceOut => t < 0.363636374f ? 7.5625f * t * t : t < 0.727272749f ? (7.5625f * (t -= 0.545454562f) * t) + 0.75f : t < 0.909090936f ? (7.5625f * (t -= 0.8181818f) * t) + 0.9375f : (7.5625f * (t -= 21f / 22f) * t) + (63f / 64f),
            EaseType.BounceInOut => t < 0.5f ? BounceIn(t * 2f) * 0.5f : (BounceOut((t * 2f) - 1f) * 0.5f) + 0.5f,
            EaseType.ElasticIn => -(Mathf.Pow(2, 10 * (--t)) * Mathf.Sin((t - (0.3f / 4f)) * (2 * Mathf.PI) / 0.3f)),
            EaseType.SlowElasticIn => -(Mathf.Pow(2, 7 * (--t)) * Mathf.Sin((t - (0.4f / 2f)) * (1 * Mathf.PI) / 0.4f)),
            EaseType.ElasticOut => t == 1f ? 1f : 1f - ElasticIn(1f - t),
            EaseType.ElasticInOut => (t *= 2f) == 2f ? 1f : t < 1f ? -0.5f * (Mathf.Pow(2f, 10f * (--t)) * Mathf.Sin((t - 0.1125f) * (2f * Mathf.PI) / 0.45f)) : ((Mathf.Pow(2f, -10f * (--t)) * Mathf.Sin((t - 0.1125f) * (2f * Mathf.PI) / 0.45f) * 0.5f) + 1f),
            EaseType.CircularIn => -(Mathf.Sqrt(1 - (t * t)) - 1),
            EaseType.CircularOut => Mathf.Sqrt(1f - ((--t) * t)),
            EaseType.CircularInOut => (t *= 2f) < 1f ? -1f / 2f * (Mathf.Sqrt(1f - (t * t)) - 1f) : 0.5f * (Mathf.Sqrt(1 - ((t -= 2) * t)) + 1),
            EaseType.SinusIn => -Mathf.Cos(t * (Mathf.PI * 0.5f)) + 1f,
            EaseType.SinusOut => Mathf.Sin(t * (Mathf.PI * 0.5f)),
            EaseType.SinusInOut => -0.5f * (Mathf.Cos(Mathf.PI * t) - 1f),
            EaseType.ExponentialIn => Mathf.Pow(2f, 10f * (t - 1f)),
            EaseType.ExponentialOut => Mathf.Sin(t * (Mathf.PI * 0.5f)),
            EaseType.ExponentialInOut => -0.5f * (Mathf.Cos(Mathf.PI * t) - 1f),
            EaseType.BackwardIn => Mathf.Pow(2f * t, 2f) * ((C2 + 1f) * 2f * t - C2) / 2f,
            EaseType.BackwardOut => (Mathf.Pow(2f * t - 2f, 2f) * ((C2 + 1f) * (t * 2f - 2f) + C2) + 2f) / 2f,
            EaseType.BackwardInOut => t < 0.5f ? BackwardIn(t) : BackwardOut(t),
            EaseType.BackwardInOutHalf => t < 0.5f ? BackwardIn(t, 0.5f) : BackwardOut(t, 0.5f),
            EaseType.Custom => custom.Evaluate(t),
            _ => throw new System.NotImplementedException(),
        };
        public static float BackwardIn(float t, float mod = 1) => Mathf.Pow(2f * t, 2f) * ((C2 * mod + 1f) * 2f * t - C2 * mod) / 2f;
        public static float BackwardOut(float t, float mod = 1) => (Mathf.Pow(2f * t - 2f, 2f) * ((C2 * mod + 1f) * (t * 2f - 2f) + C2 * mod) + 2f) / 2f;
        public static float BounceOut(float t) => t < 0.363636374f ? 7.5625f * t * t : t < 0.727272749f ? (7.5625f * (t -= 0.545454562f) * t) + 0.75f : t < 0.909090936f ? (7.5625f * (t -= 0.8181818f) * t) + 0.9375f : (7.5625f * (t -= 21f / 22f) * t) + (63f / 64f);
        public static float BounceIn(float t) => 1f - BounceOut(1f - t);
        public static float ElasticIn(float t) => -(Mathf.Pow(2, 10 * (--t)) * Mathf.Sin((t - (0.3f / 4f)) * (2 * Mathf.PI) / 0.3f));
    }
    #endregion Ease Calculation
}
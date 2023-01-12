using UnityEngine;

namespace ReTween
{
    [System.Serializable]
    public class Ease
    {
        public string name;
        public AnimationCurve curve;

        public static Ease Default = InOut;
        public static Ease Linear = AnimationCurve.Linear(0f, 0f, 1f, 1f);
        public static Ease InOut = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);
        public static Ease Constant = AnimationCurve.Constant(0f, 1f, 1f);

        public Ease(AnimationCurve source, string name = default) => (this.curve, this.name) = (source, name);

        public static Ease Get(string name) => Easing.Get(name);

        public static implicit operator AnimationCurve(Ease curve) => curve.curve;
        public static implicit operator Ease(AnimationCurve curve) => new Ease(curve);
    }
}
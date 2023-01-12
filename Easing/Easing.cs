using System.Collections.Generic;
using ReTween.Utilities;
using UnityEngine;

namespace ReTween
{
    [System.Serializable]
    public class Easing : AutoBehaviour<Easing>
    {
        #region Custom Eases

        public List<Ease> customEaseSet = new List<Ease>();

        #endregion Custom Eases

        #region Eases Management

        public static void SetDefault(AnimationCurve target) => Ease.Default = target;

        public static float Evaluate(float time, Ease ease = default) => ((AnimationCurve)ease ?? Ease.Default).Evaluate(time);

        public static float EvaluateClamped(float time, Ease ease = default) => Mathf.Clamp01(((AnimationCurve)ease ?? Ease.Default).Evaluate(time));

        public static void Add(Ease ease)
            => Instance.customEaseSet.Add(ease);

        public static void Add(string name, AnimationCurve ease)
            => Instance.customEaseSet.Add(new Ease(ease, name));

        public static void Add(string name, Ease ease)
            => Instance.customEaseSet.Add(new Ease(ease, name));

        public static void Remove(string name) => Instance.customEaseSet.RemoveAll(e => e.name == name);

        public static void Clear() => Instance.customEaseSet.Clear();

        public static Ease Get(string name)
        {
            Ease ease = Instance.customEaseSet.Find(e => e.name == name);

            if (ease == null)
            {
                Debug.LogError($"Ease {name} not found! Using default ease.");
                return Ease.Default;
            }
            else
            {
                return ease;
            }
        }

        #endregion Eases Management
    }
}
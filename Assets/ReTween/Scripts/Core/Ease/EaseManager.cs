using System;
using System.Collections.Generic;
using ReTween.Utilities;
using UnityEngine;

namespace ReTween
{
    [Serializable]
    public partial class EaseCalculator : AutoBehaviour<EaseCalculator>
    {
        #region Custom Eases
        public Dictionary<string, Ease> customEases = new Dictionary<string, Ease>();

        #endregion Custom Eases

        #region Eases Management

        public static Ease Default = new Ease(Easing.QuadIn, "Default");

        public static void SetDefault(Ease target) => Default = target;

        public static void Add(Ease ease)
            => Instance.customEases.Add(ease.easeName, ease);

        public static void Add(string name, AnimationCurve ease)
            => Instance.customEases.Add(name, new Ease(ease, name));

        public static void Add(string name, Easing ease)
            => Instance.customEases.Add(name, new Ease(ease, name));

        public static void Clear() => Instance.customEases.Clear();

        public static void Remove(string name)
        {
#if UNITY_EDITOR
            if (Instance.customEases.ContainsKey(name))
            {
                Debug.Log($"Ease named [{name}] removed successfully.");
            }
            else
            {
                Debug.LogError($"Ease named [{name}] not found! Can't remove it.");
            }
#endif

            Instance.customEases.Remove(name);
        }

        public static Ease SetCustom(string name, AnimationCurve curve, bool unique = false)
        {
#if UNITY_EDITOR
            bool existing = Instance.customEases.TryGetValue(name, out Ease ease);

            if (existing && !unique)
            {
                Debug.LogError($"Ease named [{name}] already exist! Use another name.");
            }
            else
#endif
            {
                if (unique)
                {
                    name = $"{name} [Auto: {Time.realtimeSinceStartup}|{UnityEngine.Random.Range(0f, 10000f)}]";
                }

                ease = new Ease(curve, name);
                Instance.customEases.Add(name, ease);
            }

            return ease;
        }

        public static Ease GetCustom(string name)
        {
            bool existing = Instance.customEases.TryGetValue(name, out Ease ease);

#if UNITY_EDITOR
            if (!existing)
            {
                Debug.LogError($"Ease {name} not found! Using default ease.");
                return Ease.Default;
            }
            else
#endif
            {
                return ease;
            }
        }

        #endregion Eases Management
    }
}
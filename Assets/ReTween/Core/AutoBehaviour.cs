using System;
using UnityEngine;

namespace ReTween.Utilities
{
    public class AutoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instance;
        public static T Instance => instance ??= AutoInitialize();

        private const string PARENT_NAME = "AutoBehaviours";

        public static T AutoInitialize()
        {
            if (instance == null)
            {
                GameObject autoObject = GameObject.Find(PARENT_NAME) ?? new GameObject(PARENT_NAME).gameObject;
                instance = autoObject.AddComponent<T>();
                (instance as AutoBehaviour<T>)?.OnInitialized();

                DontDestroyOnLoad(autoObject);
            }

            return instance;
        }

        public virtual void OnInitialized() { }
    }
}
using UnityEngine;

namespace ReTween.Utilities
{
    public class AutoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance;

        [RuntimeInitializeOnLoadMethod]
        private static void InitializeOnLoad()
        {
            if (Instance == null)
            {
                GameObject autoObject = new GameObject("AutoBehaviours").gameObject;
                Instance = autoObject.AddComponent<T>();
                DontDestroyOnLoad(autoObject);
            }
        }

        public virtual void OnInitialized() { }
    }
}
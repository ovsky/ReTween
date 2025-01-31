using UnityEditor;
using UnityEngine;

namespace ReTween.Editor.Utilities
{
    [CustomEditor(typeof(ReTweenPreviewUtility)), CanEditMultipleObjects]
    public class ReTweenPreviewUtility : EditorWindow
    {
        [SerializeField]
        private Ease ease = Ease.Default;

        private static SerializedObject serializedWindow;

        private const string TITLE = "ReTween Utility";
        private const string REPOSITORY_URL = "https://github.com/ovsky/ReTween/";
        private const string MENU_ITEM_PATH = "Tools/ReTween/Easing Preview";
        private const string EASING_INFO = "*ReTween* gives you the ability to use ~60 different, pure-math-based easing functions, to animate your game. You can preview the ease curve by selecting one of the predefined options or by creating custom - the last option.";

        [MenuItem(MENU_ITEM_PATH, priority = 0)]
        public static void ShowWindow()
        {
            ReTweenPreviewUtility window = GetWindow<ReTweenPreviewUtility>(TITLE);
            window.Show();
        }

        private void OnGUI()
        {
            serializedWindow = new SerializedObject(this);

            // ReTween Header
            GUILayout.BeginVertical(GUI.skin.box);
            GUILayout.Space(10);
            GUILayout.Label("ReTween", EditorStyles.centeredGreyMiniLabel);
            GUILayout.Space(10);
            GUILayout.EndVertical();

            // Ease Curve Preview
            GUILayout.BeginVertical(GUI.skin.box);
            GUILayout.Label("Ease Curve Preview", EditorStyles.centeredGreyMiniLabel);
            SerializedProperty easeProperty = serializedWindow.FindProperty("ease");
            EditorGUILayout.PropertyField(easeProperty);
            GUILayout.EndVertical();

            // Ease Curve Info
            GUILayout.BeginVertical(GUI.skin.box);
            GUILayout.Label("Easing Methods", EditorStyles.centeredGreyMiniLabel);
            GUILayout.Label(EASING_INFO, EditorStyles.wordWrappedMiniLabel);
            GUILayout.EndVertical();

            // GitHub Repository URL
            GUILayout.BeginVertical(GUI.skin.box);
            GUILayout.Label("GitHub Repository", EditorStyles.centeredGreyMiniLabel);
            if (GUILayout.Button(REPOSITORY_URL, EditorStyles.centeredGreyMiniLabel))
            {
                Application.OpenURL(REPOSITORY_URL);

            }
            GUILayout.EndVertical();
        }
    }
}

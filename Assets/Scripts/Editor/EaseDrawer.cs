using UnityEditor;
using UnityEngine;

namespace ReTween.Editor
{
    [CustomPropertyDrawer(typeof(Ease))]
    public class EaseDrawer : PropertyDrawer
    {
        const float PREVIEW_HEIGHT = 50f;
        const float BUTTON_WIDTH = 30f;

        SerializedProperty target;
        SerializedProperty easeType;
        SerializedProperty customCurve;
        SerializedProperty easeName;

        public void Initialize(SerializedProperty property)
        {
            target = property;
            easeType = property.FindPropertyRelative("easeType");
            easeName = property.FindPropertyRelative("easeName");
            customCurve = property.FindPropertyRelative("customCurve");
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (easeType == null)
            {
                Initialize(property);
            }

            Draw(easeType, customCurve, easeName, position, property, label);
        }

        public static void Draw(Rect position, SerializedProperty property, GUIContent label)
        {
            SerializedProperty easeType = property.FindPropertyRelative("easeType");
            SerializedProperty easeName = property.FindPropertyRelative("easeName");
            SerializedProperty customCurve = property.FindPropertyRelative("customCurve");

            Draw(easeType, customCurve, easeName, position, property, label);
        }

        public static void Draw(SerializedProperty easeType, SerializedProperty customCurve, SerializedProperty easeName, Rect position, SerializedProperty property, GUIContent label)
        {
            GUILayout.Space(-20);

            EaseTypeDrawer.SetName(property.displayName);
            EditorGUILayout.PropertyField(easeType);

            if (easeType.isExpanded && easeType.enumValueFlag == (int)EaseType.Custom)
            {
                EditorGUILayout.PropertyField(easeName, new GUIContent("Custom Easing Name:"));
                EditorGUILayout.HelpBox("Custom curves are way slower than selectable easings. Select one of the predefined calculations if you can.", MessageType.Info);
                customCurve.animationCurveValue = EditorGUILayout.CurveField(customCurve.animationCurveValue, GUILayout.Height(PREVIEW_HEIGHT));
            }
        }
    }
}
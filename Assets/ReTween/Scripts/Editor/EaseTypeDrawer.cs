using UnityEditor;
using UnityEngine;

namespace ReTween.Editor
{
    [CustomPropertyDrawer(typeof(Easing))]
    public class EaseTypeDrawer : PropertyDrawer
    {
        [SerializeField] AnimationCurve curve;
        [SerializeField] int lastType = -1;

        const float ACCURACY = 100f;
        const float BUTTON_WIDTH = 30f;
        const float PREVIEW_HEIGHT = 50f;

        const string LEFT_ARROW = "◀";
        const string RIGHT_ARROW = "▶";

        private static string customName;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            GUILayout.Space(-20);

            EditorGUI.BeginProperty(position, label, property);
            EditorGUILayout.BeginHorizontal();

            property.isExpanded = EditorGUILayout.Foldout(property.isExpanded, new GUIContent(customName ?? label.text), true);

            EditorGUILayout.PropertyField(property, GUIContent.none);

            if (GUILayout.Button(LEFT_ARROW, GUILayout.Width(BUTTON_WIDTH)) && property.enumValueIndex > 0)
                property.enumValueIndex--;

            if (GUILayout.Button(RIGHT_ARROW, GUILayout.Width(BUTTON_WIDTH)) && property.enumValueIndex < property.enumDisplayNames.Length - 1)
                property.enumValueIndex++;

            EditorGUILayout.EndHorizontal();

            DrawPreview(property);

            EditorGUI.EndProperty();
        }

        public static void SetName(string name)
        {
            customName = name;
        }

        private void DrawPreview(SerializedProperty property)
        {
            if (property.isExpanded && (property.enumValueIndex != (int)Easing.Custom))
            {
                if (lastType != property.enumValueIndex)
                {
                    curve = new AnimationCurve();

                    for (int i = 0; i < ACCURACY; i++)
                    {
                        float x = EaseCalculator.Calculate((Easing)property.enumValueIndex, i / ACCURACY);
                        Keyframe key = new Keyframe(i / ACCURACY, x);

                        if (i > 0)
                        {
                            key.inTangent = curve.keys[i - 1].value;
                            key.outTangent = curve.keys[i - 1].value;
                        }

                        curve.AddKey(key);
                    }
                    lastType = property.enumValueIndex;
                }
                EditorGUILayout.CurveField(curve, GUILayout.Height(PREVIEW_HEIGHT));
            }
        }
    }
}
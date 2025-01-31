using UnityEditor;
using UnityEngine;

namespace ReTween.Editor
{
    [CustomPropertyDrawer(typeof(EaseType))]
    public class EaseTypeDrawer : PropertyDrawer
    {
        [SerializeField] AnimationCurve curve;
        [SerializeField] int lastType = -1;

        const float ACCURACY = 50f;
        const float BUTTON_WIDTH = 30f;
        const float PREVIEW_HEIGHT = 50f;

        const string LEFT_ARROW = "◀";
        const string RIGHT_ARROW = "▶";

        private static string customName;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            GUILayout.Space(-20);

            // Check the depth of the property, the 'Ease' class has a depth of 1 and the 'EaseType' has a depth of 0 (the root).
            // So we can simply check if the user is trying to draw the EaseType directly and warn him about it. 

            // This is a temporary solution, I will try to find a better way to handle this. 
            // I'm not sure that the depth will be 0 at the most situations in this type of GUI drawing... 
            // ...but probably it will be beacuse it will be the root.
            if (property.depth == 0)
            {
                EditorGUILayout.PrefixLabel($"{property.displayName} [EaseType : {property.propertyPath}]");
                EditorGUILayout.HelpBox("Drawing the raw EaseType is currently disabled to avoid architectural misunderstandings. If you are looking for a class that has a pretty interface for easing, try to use the 'Ease' instead of 'EaseType', beacise it is the major type used for simple easing setups.", MessageType.Error);
                return;
            }

            EditorGUI.BeginProperty(position, label, property);
            EditorGUILayout.BeginHorizontal();

            property.isExpanded = EditorGUILayout.Foldout(property.isExpanded, new GUIContent(customName ?? label.text), true);

            EditorGUILayout.PropertyField(property, GUIContent.none);

            if (GUILayout.Button(LEFT_ARROW, GUILayout.Width(BUTTON_WIDTH)) && property.enumValueIndex > 0)
                property.enumValueIndex--;

            if (GUILayout.Button(RIGHT_ARROW, GUILayout.Width(BUTTON_WIDTH)) && property.enumValueIndex < property.enumDisplayNames.Length - 1)
                property.enumValueIndex++;

            if (property.enumValueIndex == property.enumDisplayNames.Length - 1)
                property.enumValueFlag = (int)EaseType.Custom;

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
            if (property.isExpanded && (property.enumValueFlag != (int)EaseType.Custom))
            {
                if (lastType != property.enumValueFlag)
                {
                    curve = new AnimationCurve();

                    for (int i = 0; i < ACCURACY; i++)
                    {
                        float y = EaseCalculator.Calculate((EaseType)property.enumValueIndex, i / ACCURACY);
                        Keyframe key = new Keyframe(i / ACCURACY, y);

                        curve.AddKey(key);
                        curve.SmoothTangents(i, 1f);
                    }
                    lastType = property.enumValueFlag;
                }
                EditorGUILayout.CurveField(curve, GUILayout.Height(PREVIEW_HEIGHT));
                EditorGUILayout.Separator();
            }
        }
    }
}
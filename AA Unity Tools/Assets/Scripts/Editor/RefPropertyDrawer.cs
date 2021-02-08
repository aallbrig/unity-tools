using ScriptableObjects.Refs;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomPropertyDrawer(typeof(StringRef))]
    [CustomPropertyDrawer(typeof(FloatRef))]
    [CustomPropertyDrawer(typeof(IntRef))]
    [CustomPropertyDrawer(typeof(BoolRef))]
    [CustomPropertyDrawer(typeof(Vector3Ref))]
    [CustomPropertyDrawer(typeof(GameObjectRef))]
    [CustomPropertyDrawer(typeof(ColorRef))]
    public class RefPropertyDrawer : PropertyDrawer
    {
        private readonly string[] _popupOptions = {"Use Constant", "Use Variable"};
        private GUIStyle _popupStyle;

        public override void OnGUI(Rect position, SerializedProperty property,
            GUIContent label)
        {
            if (_popupStyle == null)
                _popupStyle = new GUIStyle(GUI.skin.GetStyle("PaneOptions")) {imagePosition = ImagePosition.ImageOnly};

            label = EditorGUI.BeginProperty(position, label, property);
            position = EditorGUI.PrefixLabel(position, label);

            EditorGUI.BeginChangeCheck();

            // Properties
            var useConstantProp = property.FindPropertyRelative("useConstant");
            var constantValue = property.FindPropertyRelative("constantValue");
            var variableValue = property.FindPropertyRelative("var");

            // Rect calculations
            var buttonRect = new Rect(position);
            buttonRect.yMin += _popupStyle.margin.top;
            buttonRect.width = _popupStyle.fixedWidth + _popupStyle.margin.right;
            position.xMin = buttonRect.xMax;

            var indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            var result = EditorGUI.Popup(buttonRect, useConstantProp.boolValue ? 0 : 1, _popupOptions, _popupStyle);

            useConstantProp.boolValue = result == 0;

            EditorGUI.PropertyField(
                position,
                useConstantProp.boolValue ? constantValue : variableValue,
                GUIContent.none
            );

            if (EditorGUI.EndChangeCheck())
                property.serializedObject.ApplyModifiedProperties();

            EditorGUI.indentLevel = indent;
            EditorGUI.EndProperty();
        }
    }
}
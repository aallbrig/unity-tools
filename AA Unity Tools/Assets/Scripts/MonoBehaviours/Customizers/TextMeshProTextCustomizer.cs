using ScriptableObjects.Refs;
using TMPro;
using UnityEngine;

namespace MonoBehaviours.Customizers
{
    [ExecuteInEditMode]
    public class TextMeshProTextCustomizer : Customizer
    {
        public StringRef text;
        public ColorRef fontColor;
        public IntRef fontSize;
        private TextMeshProUGUI _text;

        private void Start() => _text = GetComponent<TextMeshProUGUI>();

        protected override void Customize()
        {
            _text.text = text.Value;
            _text.fontSize = fontSize.Value;
            _text.color = fontColor.Value;
        }
    }
}
using ScriptableObjects.Refs;
using UnityEngine;
using UnityEngine.UI;

namespace MonoBehaviours.Customizers
{
    [RequireComponent(typeof(Button))]
    [ExecuteInEditMode]
    public class ButtonCustomizer : Customizer
    {
        public ColorRef normalColor;
        public ColorRef highlightedColor;
        public ColorRef pressedColor;
        public ColorRef selectedColor;
        public ColorRef disabledColor;

        private Button _button;

        private void Start()
        {
            _button = GetComponent<Button>();
            Customize();
        }

        protected override void Customize()
        {
            var colors = _button.colors;

            colors.normalColor = normalColor.Value;
            colors.highlightedColor = highlightedColor.Value;
            colors.pressedColor = pressedColor.Value;
            colors.selectedColor = selectedColor.Value;
            colors.disabledColor = disabledColor.Value;

            _button.colors = colors;
        }
    }
}
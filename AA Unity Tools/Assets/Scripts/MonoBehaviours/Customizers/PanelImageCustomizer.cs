using ScriptableObjects.Refs;
using UnityEngine;
using UnityEngine.UI;

namespace MonoBehaviours.Customizers
{
    [RequireComponent(typeof(RectTransform))]
    [RequireComponent(typeof(Image))]
    [ExecuteInEditMode]
    public class PanelImageCustomizer : Customizer
    {
        public FloatRef margin;
        public ColorRef colorRef;
        private Image _image;

        private RectTransform _rectTransform;

        private void Start()
        {
            _rectTransform = GetComponent<RectTransform>();
            _image = GetComponent<Image>();

            Customize();
        }

        public void CustomizeColor(Color color) => _image.color = color;

        protected override void Customize()
        {
            CustomizeColor(colorRef.Value);

            _rectTransform.offsetMin = new Vector2(margin.Value, margin.Value);
            _rectTransform.offsetMax = new Vector2(-margin.Value, -margin.Value);
        }
    }
}
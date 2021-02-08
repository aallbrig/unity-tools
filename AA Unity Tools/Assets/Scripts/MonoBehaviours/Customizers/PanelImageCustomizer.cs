using Interfaces;
using ScriptableObjects.Refs;
using UnityEngine;
using UnityEngine.UI;

namespace MonoBehaviours.Customizers
{
    [RequireComponent(typeof(RectTransform))]
    [RequireComponent(typeof(Image))]
    [ExecuteInEditMode]
    public class PanelImageCustomizer : MonoBehaviour, IColorCustomizable
    {
        public FloatRef margin;
        public ColorRef colorRef;

        [Tooltip("Update at runtime (useful when actively changing)")]
        public BoolRef updateAtRuntime;

        private RectTransform _rectTransform;
        private Image _image;

        public void CustomizeColor(Color color) => _image.color = color;

        private void CustomizePanelImage()
        {
            CustomizeColor(colorRef.Value);

            _rectTransform.offsetMin = new Vector2(margin.Value, margin.Value);
            _rectTransform.offsetMax = new Vector2(-margin.Value, -margin.Value);
        }

        private void Start()
        {
            _rectTransform = GetComponent<RectTransform>();
            _image = GetComponent<Image>();

            CustomizePanelImage();
        }

        private void Update()
        {
            if (!updateAtRuntime.Value) return;

            CustomizePanelImage();
        }
    }
}
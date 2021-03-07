using UnityEngine;

namespace ScriptableObjects.Vars
{
    [CreateAssetMenu(fileName = "new color var", menuName = "AATools/Vars/ColorVar", order = 0)]
    public class ColorVar : ScriptableObject
    {
        public Color value = Color.white;
    }
}
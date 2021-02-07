using UnityEngine;

namespace ScriptableObjects.Vars
{
    [CreateAssetMenu(fileName = "new float var", menuName = "AATools/Vars/FloatVar", order = 0)]
    public class FloatVar : Var<float> {}
}
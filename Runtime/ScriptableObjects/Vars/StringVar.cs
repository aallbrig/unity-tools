using UnityEngine;

namespace ScriptableObjects.Vars
{
    [CreateAssetMenu(fileName = "new string var", menuName = "AATools/ScriptableObjects/Vars/StringVar", order = 0)]
    public class StringVar : Var<string> {}
}
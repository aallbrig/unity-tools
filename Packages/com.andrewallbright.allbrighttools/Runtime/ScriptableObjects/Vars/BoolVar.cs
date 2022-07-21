using UnityEngine;

namespace ScriptableObjects.Vars
{
    [CreateAssetMenu(fileName = "new bool var", menuName = "AATools/ScriptableObjects/Vars/BoolVar", order = 0)]
    public class BoolVar : Var<bool> {}
}
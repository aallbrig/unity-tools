using UnityEngine;

namespace ScriptableObjects.Vars
{
    [CreateAssetMenu(fileName = "new int var", menuName = "AATools/Vars/IntVar", order = 0)]
    public class IntVar : Var<int> {}
}
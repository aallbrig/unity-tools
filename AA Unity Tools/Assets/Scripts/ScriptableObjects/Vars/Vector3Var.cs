using UnityEngine;

namespace ScriptableObjects.Vars
{
    [CreateAssetMenu(fileName = "new Vector3 var", menuName = "AATools/Vars/Vector3Var", order = 0)]
    public class Vector3Var : Var<Vector3> {}
}
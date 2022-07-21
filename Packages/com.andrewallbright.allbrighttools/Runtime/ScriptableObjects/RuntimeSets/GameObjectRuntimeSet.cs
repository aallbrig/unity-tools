using UnityEngine;

namespace ScriptableObjects.RuntimeSets
{
    [CreateAssetMenu(fileName = "new game object runtime set", menuName = "AATools/ScriptableObjects/RuntimeSets/GameObject")]
    public class GameObjectRuntimeSet : RuntimeSet<GameObject> {}
}
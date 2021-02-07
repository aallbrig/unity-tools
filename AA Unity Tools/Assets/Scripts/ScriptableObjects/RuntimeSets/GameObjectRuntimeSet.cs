using UnityEngine;

namespace ScriptableObjects.RuntimeSets
{
    [CreateAssetMenu(fileName = "new game object runtime set", menuName = "AATools/RuntimeSets/GameObject")]
    public class GameObjectRuntimeSet : RuntimeSet<GameObject> {}
}
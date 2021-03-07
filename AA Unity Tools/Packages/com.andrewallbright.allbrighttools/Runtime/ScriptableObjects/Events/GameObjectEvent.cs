using UnityEngine;

namespace ScriptableObjects.Events
{
    [CreateAssetMenu(fileName = "New game object event", menuName = "AATools/Events/GameObjectEvent")]
    public class GameObjectEvent : OneObjectEvent<GameObject> {}
}
﻿using UnityEngine;

namespace ScriptableObjects.Vars
{
    [CreateAssetMenu(fileName = "new game object var", menuName = "AATools/ScriptableObjects/Vars/GameObjectVar", order = 0)]
    public class GameObjectVar : Var<GameObject> {}
}
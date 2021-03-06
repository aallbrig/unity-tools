﻿using Interfaces;
using UnityEngine;

namespace ScriptableObjects.FiniteStateMachines.GamePlayCoreFSM
{
    public abstract class Action : ScriptableObject
    {
        public abstract void Act(IFiniteStateMachineContext<State> context);
    }
}
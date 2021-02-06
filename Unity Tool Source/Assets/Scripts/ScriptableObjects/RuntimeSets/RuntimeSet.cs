using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects.RuntimeSets
{
	public abstract class RuntimeSet<T> : ScriptableObject
	{
		public List<T> list = new List<T>();

		public void Add(T controller)
		{
			if (!list.Contains(controller)) list.Add(controller);
		}

		public void Remove(T controller)
		{
			if (list.Contains(controller)) list.Remove(controller);
		}

		private void Awake() => list.Clear();
		private void OnEnable() => list.Clear();
		private void OnDisable() => list.Clear();
		private void OnDestroy() => list.Clear();
	}
}
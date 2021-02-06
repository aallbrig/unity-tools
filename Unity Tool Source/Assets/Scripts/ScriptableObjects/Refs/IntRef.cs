using System;
using ScriptableObjects.Vars;
using UnityEngine;

namespace ScriptableObjects.Refs
{
	[Serializable]
	public class IntRef
	{
		public bool useConstant;
		public IntVar constantValue;
		public int var;

		public int Value => useConstant ? constantValue.value : var;
	}
}
using System;
using ScriptableObjects.Vars;
using UnityEngine;

namespace ScriptableObjects.Refs
{
	[Serializable]
	public class FloatRef
	{
		public bool useConstant;
		public FloatVar constantValue;
		public float var;

		public float Value => useConstant ? constantValue.value : var;
	}
}
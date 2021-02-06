using UnityEngine;

namespace ScriptableObjects.Vars
{
	[CreateAssetMenu(fileName = "new float var", menuName = "AATools/Vars/IntVar", order = 0)]
	public class IntVar : ScriptableObject
	{
		public int value;
	}
}
using UnityEngine;

namespace GameObjects
{
	public class Chunk : MonoBehaviour
	{
		[SerializeField] private Transform end;

		public Transform End => end;
	}
}

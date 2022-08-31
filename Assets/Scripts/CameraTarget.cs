using System;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{
	private Transform _cameraMain;
	[SerializeField] private Vector2 offset = Vector2.left * 2;

	public static CameraTarget Target { get; private set; }

	private void Start()
	{
		if (Target != null)
			Destroy(Target);
		Target = this;
		
		if (Camera.main != null)
			_cameraMain = Camera.main.transform;
		else Destroy(this);
	}

	private void Update()
	{
		var position = _cameraMain.position;
		position = new Vector3(transform.position.x, position.y, position.z);
		_cameraMain.position = position - (Vector3)offset;
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject target;
	private Vector3 offset;

	private void Start()
	{
		offset = transform.position - target.transform.position;

	}
	void LateUpdate() {
		transform.position = new Vector3(target.transform.position.x + offset.x, transform.position.y, transform.position.z);

	}
}

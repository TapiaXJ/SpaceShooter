using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {

	public float tumble;
	private Rigidbody2D rb2d;
	void Start ()
	{
		rb2d = GetComponent<Rigidbody2D>();

		rb2d.angularVelocity = Random.Range(-200, 200);
	}
}

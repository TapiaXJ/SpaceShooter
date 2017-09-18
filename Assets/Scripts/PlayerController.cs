using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public int speed;

	private Rigidbody2D rb2d;

	public float yMin, yMax;
	public float fireDelta = 0.5F;

	public GameObject shot;
	public Transform shotSpawn;

	private float myTime = 0.0F;
	private float nextFire = 0.5F;


	void Start ()
	{
		rb2d = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		myTime = myTime + Time.deltaTime;

		if (Input.GetButton("Fire1") && myTime > nextFire)
		{
			nextFire = myTime + fireDelta;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			nextFire = nextFire - myTime;
			myTime = 0.0F;

		}
	}

	private void FixedUpdate()
	{
		float moveVertical = Input.GetAxis("Vertical") * speed;
		float moveHorizontal = Input.GetAxis("Horizontal") * speed;

		if(moveHorizontal < 0)
		{
			moveHorizontal *= -1;
		}

		rb2d.velocity = new Vector2(moveHorizontal, moveVertical);

		rb2d.position = new Vector2(rb2d.position.x, Mathf.Clamp(rb2d.position.y, yMin, yMax));
	}
}

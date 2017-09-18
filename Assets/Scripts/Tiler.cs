using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiler : MonoBehaviour {

	public int offsetX = 2;
	private bool hasRightTile = false;
	private bool hasLeftTile = false;


	private float spriteWidth;
	private Camera cam;

	// Use this for initialization
	private void Awake()
	{
		cam = Camera.main;
	}

	private void Start()
	{
		SpriteRenderer sRenderer = GetComponent<SpriteRenderer>();
		spriteWidth = sRenderer.sprite.bounds.size.x;
	}

	// Update is called once per frame
	private void Update () {
		if(hasLeftTile == false || hasRightTile == false)
		{
			float camHorizontalExtend = cam.orthographicSize * Screen.width / Screen.height;

			float edgeVisiblePositionRight = (transform.position.x + spriteWidth / 2) - camHorizontalExtend;
			float edgeVisiblePositionLeft = (transform.position.x + spriteWidth / 2) + camHorizontalExtend;


			if(cam.transform.position.x >= edgeVisiblePositionRight - offsetX && hasRightTile == false)
			{
				MakeTile(1);
				hasRightTile = true;
			}
		}
	}

	private void MakeTile(int rightOrLeft)
	{
		Vector3 newPosition = new Vector3(transform.position.x + spriteWidth * rightOrLeft, transform.position.y, transform.position.z);
		Transform newTile = (Transform)Instantiate(transform, newPosition, transform.rotation);

		newTile.parent = transform;

		if (rightOrLeft > 0)
		{
			newTile.GetComponent<Tiler>().hasLeftTile = true;
		}
		else
		{
			newTile.GetComponent<Tiler>().hasRightTile = true;

		}
	}
}

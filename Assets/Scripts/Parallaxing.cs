using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxing : MonoBehaviour {

	public Transform[] backgrounds;
	private float[] parrallaxScales;
	public float smoothing = 10f;

	private Transform cam;
	private Vector3 previousCamPos;

	private void Awake()
	{
		cam = Camera.main.transform;
	}

	private void Start ()
	{
		previousCamPos = cam.position;

		parrallaxScales = new float[backgrounds.Length];
		for(int i = 0; i < backgrounds.Length; i++)
		{
			parrallaxScales[i] = backgrounds[i].position.z * -1;
		}
	}
	
	private void Update ()
	{
		for (int i = 0; i < backgrounds.Length; i++)
		{
			float parallax = (previousCamPos.x - cam.position.x) * parrallaxScales[i];

			float backgroundTargetPosX = backgrounds[i].position.x + parallax;

			Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

			backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
		}

		previousCamPos = cam.position;
	}
}

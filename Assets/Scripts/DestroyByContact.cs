using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

	public GameObject explosion;
	private GameController gameController;
	public int scoreValue;

	private void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag("GameController");
		if(gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent<GameController>();
		}
		if(gameController == null)
		{
			Debug.Log("Cannot find 'GameController' script");
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag == "Boundry")
		{
			return;
		}
		if(collision.tag == "Player")
		{
			gameController.GameOver();
		}

		Instantiate(explosion, transform.position, transform.rotation);

		gameController.AddScore(scoreValue);

		Destroy(collision.gameObject);
		Destroy(gameObject);
	}
}

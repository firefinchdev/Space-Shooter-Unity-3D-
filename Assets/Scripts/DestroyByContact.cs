﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	private GameController gameController;

	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("Boundry") || other.CompareTag ("Enemy"))
		{
			return;
		}

		if (explosion != null)
		{
			Instantiate(explosion, transform.position, transform.rotation);
			//OR Destroy(Instantiate(explosion, transform.position, transform.rotation),5f);
		}
		if (other.tag == "Player")
		{
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation); //EITHER DO THIS OR ONDESTROY() 
																								//OF PLAYERCONTROLLER.CS
			gameController.GameOver ();
		}
		//gameController.AddScore (scoreValue);
		Destroy (other.gameObject);
		Destroy (gameObject);

	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundry
{
	public float xMin,xMax,zMin,zMax;
}

public class PlayerController : MonoBehaviour {
	
	private Rigidbody rb;
	public float speed;
	public float tilt;
	//public float f;

	public Boundry boundary;
	public GameObject shot;
	public Transform shotSpawn;
	public GameObject playerExplosion;
	public float fireRate;
	private float nextFire = 0.0f;

	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	void Update(){
		//Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
		if (Input.GetButton("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			//Instantiate(shot, gameObject.transform.position, gameObject.transform.rotation,gameObject.transform); Last paramter is parent
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			// OR use the follwing if u want a reference also to the instantiated gamobject
			//GameObject clone = Instantiate(shot, shotSpawn.position, shotSpawn.rotation) as GameObject;
			GetComponent<AudioSource>().Play();
		}
	}

	void FixedUpdate () {
		//float moveHorizontal = Input.GetAxis ("Horizontal");
		//float moveVertical = Input.GetAxis ("Vertical");
		//Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		Vector3 acceleration = Input.acceleration;
		Vector3 movement = new Vector3 (acceleration.x, 0.0f, acceleration.y);
		rb.velocity = movement * speed;
		rb.position = new Vector3 
			(
				Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax), 
				transform.position.y, 
				Mathf.Clamp (rb.position.z, boundary.zMin, boundary.zMax)
			);

		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * -tilt);
		/*tilt+=f;
		if (tilt > 360)
			tilt -= 360;
		rb.rotation = Quaternion.Euler (0.0f, 0.0f, tilt);*/

	}
	void OnDestroy()
	{
		//Instantiate(playerExplosion, transform.position, transform.rotation);
		//OR Destroy(Instantiate(playerExplosion, transform.position, transform.rotation),5f);
	}
}

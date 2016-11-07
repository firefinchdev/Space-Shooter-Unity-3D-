using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {
	Transform rb;

	public float tumble;
	void Start () {
		//rb = GetComponent<Transform> ();
		GetComponent<Rigidbody> ().angularVelocity = Random.insideUnitSphere * tumble; //LINE 1

	}
	void Update(){
		//INSTEAD OF LINE 1 WE CAN USE THIS:
		//rb.Rotate (new Vector3 (rb.rotation.x + 2f, rb.rotation.y + 2f, rb.rotation.z + 2f));
	}

}

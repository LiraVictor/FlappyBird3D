using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

	void Start () {
		GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -5.0f);
	}
	
	void Update () {
		if(transform.position.z < -30f)
		{
			Destroy(this.gameObject);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour {

	void Start () {
		Invoke("DestroyObjeto", 1.5f);
	}

	void DestroyObjeto () {
		Destroy(this.gameObject);
	}
}
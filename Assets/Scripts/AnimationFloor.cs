using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationFloor : MonoBehaviour {

	[SerializeField] private Material materialPiso;
	private float velocidade = 0.75f;

	void Update () {
		float offSet = Time.time * velocidade;
		materialPiso.SetTextureOffset("_MainTex", new Vector2(offSet, 0));
	}
}

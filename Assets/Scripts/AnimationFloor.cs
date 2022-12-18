using UnityEngine;

public class AnimationFloor : MonoBehaviour {

	[SerializeField] private Material materialFloor;
	private float velocity = 0.75f;

	void Update () {
		float offSet = Time.time * velocity;
		materialFloor.SetTextureOffset("_MainTex", new Vector2(offSet, 0));
	}
}

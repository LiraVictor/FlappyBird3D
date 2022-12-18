using UnityEngine;

public class CharacterFuzzy : MonoBehaviour {

    [SerializeField] private GameObject mainCamera;
    [SerializeField] private AudioClip sfxHit;
    [SerializeField] private AudioClip sfxScore;
    [SerializeField] private AudioClip sfxFly;

    void OnTriggerEnter (Collider obstacles) {
		if(obstacles.gameObject.tag == "Finish")
		{
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 8.5f, -10.0f);
            GetComponent<Rigidbody>().AddTorque(new Vector3(-100.0f, -100.0f, -100.0f));

            mainCamera.SendMessage("EndOfTheGame");
            GetComponent<AudioSource>().PlayOneShot(sfxHit);
        }
	}
	
	void OnTriggerExit (Collider obstacles) {
        if (obstacles.gameObject.tag == "GameController")
        {
			Destroy(obstacles.gameObject);
            mainCamera.SendMessage("MarkPoint");
            GetComponent<AudioSource>().PlayOneShot(sfxScore);
        }
    }

    void SoundForFly()
    {
        GetComponent<AudioSource>().PlayOneShot(sfxFly);
    }
}

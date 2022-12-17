using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFuzzy : MonoBehaviour {

    [SerializeField] private GameObject cameraPrincipal;
    [SerializeField] private AudioClip sfxHit;
    [SerializeField] private AudioClip sfxScore;
    [SerializeField] private AudioClip sfxFly;

    void OnTriggerEnter (Collider objeto) {
		if(objeto.gameObject.tag == "Finish")
		{
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 8.5f, -10.0f);
            GetComponent<Rigidbody>().AddTorque(new Vector3(-100.0f, -100.0f, -100.0f));

			cameraPrincipal.SendMessage("FimDeJogo");
            GetComponent<AudioSource>().PlayOneShot(sfxHit);
        }
	}
	
	void OnTriggerExit (Collider objeto) {
        if (objeto.gameObject.tag == "GameController")
        {
			Destroy(objeto.gameObject);
            cameraPrincipal.SendMessage("MarcaPonto");
            GetComponent<AudioSource>().PlayOneShot(sfxScore);
        }
    }

    void SomVoa()
    {
        GetComponent<AudioSource>().PlayOneShot(sfxFly);
    }
}

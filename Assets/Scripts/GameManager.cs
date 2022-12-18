using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    [SerializeField] private GameObject fence;
    [SerializeField] private GameObject bush;
    [SerializeField] private GameObject cloud;
    [SerializeField] private GameObject pipe;
    [SerializeField] private GameObject stone;
    [SerializeField] private GameObject characterFuzzy;
    [SerializeField] private Text textoScore;
    [SerializeField] private GameObject particulas;
    private bool started;
    private bool finished;
    private int score;

    void Start ()
    {
        Physics.gravity = new Vector3(0, -25.0f, 0);
        textoScore.fontSize = 30;
        textoScore.text = "Touch for started!";
    }

    void Update () {
        if (Input.anyKeyDown)
        {
            if (!finished)
            {
                if (!started)
                {
                    started = true;
                    InvokeRepeating("CreatesFences", 1, 0.4f);
                    InvokeRepeating("CreatesObjects", 1, 0.75f);

                    characterFuzzy.GetComponent<Rigidbody>().useGravity = true;
                    characterFuzzy.GetComponent<Rigidbody>().isKinematic = false;

                    textoScore.text = score.ToString();
                    textoScore.fontSize = 70;
                }
                FlyFelpudo();
            }
        }
        characterFuzzy.transform.rotation = Quaternion.Euler(characterFuzzy.GetComponent<Rigidbody>().velocity.y * -3, 0, 0);
	}
	
	void CreatesFences () {
		Instantiate(fence);
	}

    void CreatesObjects ()
    {
        int raffleObject = Random.Range(1, 5);
        float positionXrandom = Random.Range(-1.3f, 2.5f);
        float positionYrandom = Random.Range(1.25f, 4.5f);
        float rotationYrandom = Random.Range(0.0f, 360.0f);

        GameObject newObject = new GameObject();

        switch (raffleObject)
        {
            case 1: newObject = Instantiate(bush); positionYrandom = newObject.transform.position.y;  break;
            case 2: newObject = Instantiate(stone); positionYrandom = newObject.transform.position.y; break;
            case 3: newObject = Instantiate(cloud); break;
            case 4: newObject = Instantiate(pipe); positionYrandom = Random.Range(-2.0f, 0.1f); positionXrandom = newObject.transform.position.x; break;
            default: break;
        }

        newObject.transform.position = new Vector3(positionXrandom, positionYrandom, newObject.transform.position.z);
        newObject.transform.rotation = Quaternion.Euler(newObject.transform.rotation.x, rotationYrandom, newObject.transform.rotation.y);
    }

    void FlyFelpudo ()
    {
        GameObject novaParticula = Instantiate(particulas);
        novaParticula.transform.position = characterFuzzy.transform.position;

        characterFuzzy.GetComponent<Rigidbody>().velocity = Vector3.zero;
        characterFuzzy.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 10.0f, 0.0f);
        characterFuzzy.SendMessage("SoundForFly");
    }

    void MarkPoint()
    {
        score++;
        textoScore.text = score.ToString();
    }
    void EndOfTheGame()
    {
        finished = true;
        CancelInvoke("CreatesFences");
        CancelInvoke("CreatesObjects");
        Invoke("ReloadScene", 1);
    }

    void ReloadScene()
    {
        Application.LoadLevel("SCNGame");
    }
}

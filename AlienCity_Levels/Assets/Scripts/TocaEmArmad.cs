using UnityEngine;
using System.Collections;

public class TocaEmArmad : MonoBehaviour {

	public GameObject player;
	public GameObject camO;
	public bool dead;



	// Use this for initialization
	void Start () {

		player.SetActive (true);
		camO.SetActive (false);
		dead = false;
	
	}
	
	// Update is called once per frame
	void Update () {

		if(dead == true && Input.GetKeyDown(KeyCode.R))
		{
			camO.SetActive (false);
			player.SetActive (true);

			Application.LoadLevel (Application.loadedLevel);			
		}
	
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Player")) 
		{
			player.SetActive (false);
			camO.SetActive (true);
			dead = true;

		}

	}
}

using UnityEngine;
using System.Collections;

public class AtivaArmadilha : MonoBehaviour {


	public GameObject estalag;
	public GameObject player;

	// Use this for initialization
	void Start () {

		player.SetActive (true);
	
	}
	
	// Update is called once per frame
	void Update () {

	
	}

	void OnColissionEnter(Collider other){

		if (other.gameObject.CompareTag ("Player")) 
		{
			player.SetActive (false);
			estalag.GetComponent<Rigidbody>().useGravity = true;

		}
	}
}

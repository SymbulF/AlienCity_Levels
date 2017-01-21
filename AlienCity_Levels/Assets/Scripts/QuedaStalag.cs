using UnityEngine;
using System.Collections;

public class QuedaStalag : MonoBehaviour {

	public GameObject player;
	public GameObject estalags;


	void Start(){


	}

	void OnTriggerEnter(Collider other){

		if (other.gameObject.CompareTag ("Player")) 
		{

			estalags.GetComponent<Rigidbody> ().useGravity = true;


		}

	}

}

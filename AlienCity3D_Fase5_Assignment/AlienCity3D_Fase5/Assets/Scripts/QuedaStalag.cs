using UnityEngine;
using System.Collections;

public class QuedaStalag : MonoBehaviour {

	public GameObject player;


	void Start(){


	}

	void OnTriggerEnter(Collider other){

		if (other.gameObject.CompareTag ("Player")) 
		{

			GameObject.FindWithTag ("Estalags1").GetComponent<Rigidbody> ().useGravity = true;
			GameObject.FindWithTag ("Estalags2").GetComponent<Rigidbody> ().useGravity = true;
			GameObject.FindWithTag ("Estalags3").GetComponent<Rigidbody> ().useGravity = true;
			GameObject.FindWithTag ("Estalags4").GetComponent<Rigidbody> ().useGravity = true;
			GameObject.FindWithTag ("Estalags5").GetComponent<Rigidbody> ().useGravity = true;


		}

	}

}

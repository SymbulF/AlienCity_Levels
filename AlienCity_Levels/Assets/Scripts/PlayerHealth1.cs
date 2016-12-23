using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth1 : MonoBehaviour
{
	public int startingHealth = 100;                            // Vida inicial do jogador
	public int currentHealth;                                   // Vida que o jogador tem em um dado momento
	public Slider healthSlider;                                 // Referencia À barra de vida



	public GameObject camO;
	public GameObject camP;
	public GameObject player;


	Animator anim;

	[HideInInspector]public bool isDead = false;
	[HideInInspector]public int damage;
                               
                                          


	void Awake ()
	{
		// Setting up the references.
		anim = GetComponent <Animator> ();

		// Determina a saude inicial
		camO.SetActive(false);
		camP.SetActive (true);
		currentHealth = startingHealth;
		healthSlider.value = currentHealth;

	}


	void Update ()
	{
		if(isDead && Input.GetKeyDown(KeyCode.R))
		{
			camO.SetActive (false);
			camP.SetActive (true);
			isDead = false;
			currentHealth = 100;

			Application.LoadLevel (Application.loadedLevel);			

		}


	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Estalags1") || other.gameObject.CompareTag ("Estalags2") || other.gameObject.CompareTag ("Estalags3") ||
			other.gameObject.CompareTag ("Estalags4") || other.gameObject.CompareTag ("Estalags5")) 
		{
			damage = 15;
			this.TakeDamage (damage);

		}
		else if(other.gameObject.CompareTag ("Espinho") || other.gameObject.CompareTag ("Lava") || other.gameObject.CompareTag ("Parede"))
		{
			damage = 100;
			this.TakeDamage(damage);

		}

	}

	//marcador de dano
	public void TakeDamage (int amount)
	{

		// Se a vida chegou a zero
		if ((currentHealth <= 0) || amount <= 100) {
			// ... it should die.
			Death ();
		} else {


			// Reduce the current health by the damage amount.
			currentHealth -= amount;

			// mostra mudança na barra de vida
			healthSlider.value = currentHealth;

		}


	
	}


	public void Death ()
	{
		// Set the death flag so this function won't be called again.
		healthSlider.value = currentHealth;
		camP.SetActive(false);
		camO.SetActive (true);
		isDead = true;


	}


}
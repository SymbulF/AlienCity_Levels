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

	public Image heart1;
	public Image heart2;
	public Image heart3;


	[HideInInspector]public bool isDead = false;
	[HideInInspector]public int damage;
	[HideInInspector]public int lifes;
                               
                                          


	void Awake ()
	{
		// Setting up the references.

		// Determina a saude inicial
		camO.SetActive(false);
		camP.SetActive (true);
		currentHealth = startingHealth;
		healthSlider.value = currentHealth;

		lifes = 3;

	}


	void Update ()
	{
		if(isDead && Input.GetKeyDown(KeyCode.R))
		{
			camO.SetActive (false);
			camP.SetActive (true);
			isDead = false;
			currentHealth = 100;
			heart1.enabled = true;
			heart2.enabled = true;
			heart3.enabled = true;

			lifes = 3;

			Application.LoadLevel (Application.loadedLevel);			

		}


	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Estalags1") || other.gameObject.CompareTag("Estalags2") || 
			other.gameObject.CompareTag("Estalags3") || other.gameObject.CompareTag("Estalags4") || 
			other.gameObject.CompareTag("Estalags5")) {
			damage = 15;
			this.TakeDamage (damage);

		} else if (other.gameObject.CompareTag ("Espinho")) {
			damage = 70;
			this.TakeDamage (damage);

		} else if (other.gameObject.CompareTag ("Lava") || other.gameObject.CompareTag ("Parede")) {
		
		
			Death ();
		
		
		}

	}

	//marcador de dano
	public void TakeDamage (int amount)
	{

		// Se a vida chegou a zero
		if ((currentHealth <= 0)) {

			healthSlider.value -= amount;
			Death ();
		} else {


			currentHealth -= amount;

			// mostra mudança na barra de vida
			healthSlider.value = currentHealth;

		}


	
	}


	public void Death ()
	{

		if (lifes > 0) {

			if (lifes == 3) {
				heart3.enabled = false;
				lifes -= 1;
				player.transform.TransformVector (-1, 0, -48);
				currentHealth = startingHealth;
				healthSlider.value = currentHealth;
			} else if (lifes == 2) {
				heart2.enabled = false;
				lifes -= 1;
				player.transform.TransformVector (-1, 0, -48);
				currentHealth = startingHealth;
				healthSlider.value = currentHealth;
			} else if (lifes == 1) {
				heart1.enabled = false;
				lifes -= 1;
				player.transform.TransformVector (-1, 0, -48);
				currentHealth = startingHealth;
				healthSlider.value = currentHealth;
			}



		} else if (lifes == 0) {

			camP.SetActive(false);
			camO.SetActive (true);
			isDead = true;

		}


	}


}
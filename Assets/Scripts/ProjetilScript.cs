using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjetilScript : MonoBehaviour {

	public float velocidade;
	public float tempoDeVida;
	public GameObject explosaoPrefab;

	// Use this for initialization
	void Start () {
		// Configura tempo de vida do projetil
		Destroy(gameObject, tempoDeVida);
	}
	
	// Update is called once per frame
	void Update () {
		// Move o projetil
		transform.Translate(Vector2.up * velocidade * Time.deltaTime);
	}

	void OnCollisionEnter2D (Collision2D c) {
		// Destroi o projetil por colisão
		if (c.gameObject.tag == "Inimigo") {
			Instantiate (explosaoPrefab, transform.position, transform.rotation);
			PlacarScript.pontos++;
			Destroy (c.gameObject);
			Destroy (gameObject);
		}
		if (c.gameObject.tag == "Boss") {
			BossScript.vidaBoss--;
			Destroy (gameObject);
			if (BossScript.vidaBoss < 1) {
				Instantiate (explosaoPrefab, transform.position, transform.rotation);
				Destroy (c.gameObject);
				PlacarScript.pontos+=10;
			}
		}

	}
}

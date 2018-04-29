using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JogadorScript : MonoBehaviour {
	
	public float velocidade;
	public float limiteEsquerdo, limiteDireito, limiteBaixo, limiteCima;
	public GameObject explosaoPrefab;

	void Start () {
		PlacarScript.pontos = 0;
	}
	
	void Update () {
		Mover ();
	}

	void Mover() {
		// Mover
		float move_x = Input.GetAxisRaw ("Horizontal") * velocidade * Time.deltaTime;
		float move_y = Input.GetAxisRaw ("Vertical") * velocidade * Time.deltaTime;
		transform.Translate (move_x, move_y, 0.0f);

		// Wrap
		if (transform.position.x < limiteEsquerdo || transform.position.x > limiteDireito) {
			transform.position = new Vector2 (transform.position.x * -1, transform.position.y);
		}

		//Limitar vertical
		if (transform.position.y < limiteBaixo) {
			transform.position = new Vector2 (transform.position.x, limiteBaixo);
		}
		if (transform.position.y > limiteCima) {
			transform.position = new Vector2 (transform.position.x, limiteCima);
		}
			
	}

	void OnCollisionEnter2D (Collision2D c) {
		if (c.gameObject.tag == "Inimigo") {
			PlacarScript.vidas--;
			Instantiate (explosaoPrefab, transform.position, transform.rotation);
			Destroy (c.gameObject);
		}

		if (c.gameObject.tag == "Boss") {
			PlacarScript.vidas--;
		}

		if (c.gameObject.tag == "BossAtaque"){
			PlacarScript.vidas--;
			Destroy (c.gameObject);
		}

		if (PlacarScript.vidas <= 0) {
			Destroy (gameObject);
			Instantiate (explosaoPrefab, transform.position, transform.rotation);
			SceneManager.LoadScene ("start");
		}

	}
}

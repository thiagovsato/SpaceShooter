using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PisoScript : MonoBehaviour {

	void OnCollisionEnter2D (Collision2D c) {
		if (c.gameObject.tag == "Inimigo") {
			PlacarScript.vidas--;
			Destroy (c.gameObject);
			if (PlacarScript.vidas <= 0) {
				Destroy (gameObject);
				SceneManager.LoadScene ("start");
			}
		}
	}
}

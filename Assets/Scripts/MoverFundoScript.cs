using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverFundoScript : MonoBehaviour {

	public float limiteY;
	public float velocidade;

	void Update () {
		// Move para baixo
		transform.Translate (Vector2.down * velocidade * Time.deltaTime);

		// Retorna o fundo para posição
		if (transform.position.y <= limiteY) {
			transform.position = new Vector2 (0.0f, limiteY * -1);
		}
	}
}

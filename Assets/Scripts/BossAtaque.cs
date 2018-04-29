using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAtaque : MonoBehaviour {

	public float tempoDeVida=2;
	public float velocidade=3;

	// Use this for initialization
	void Start () {
		Destroy(gameObject, tempoDeVida);
	}

	void Update() {
		transform.Translate(Vector2.down * velocidade * Time.deltaTime);
	}
}

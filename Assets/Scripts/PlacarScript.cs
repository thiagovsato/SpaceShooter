using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class PlacarScript : MonoBehaviour {

	public Text txtPontuacao;
	public static int pontos;
	public Text txtVidas;
	public static int vidas;

	// Use this for initialization
	void Start () {
		vidas = 3;
	}
	
	// Update is called once per frame
	void Update () {
		txtPontuacao.text = "Placar: " + pontos.ToString ();
		txtVidas.text = "Vidas: " + vidas.ToString ();
	}
}

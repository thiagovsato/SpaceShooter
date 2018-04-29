using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour {

	// Use this for initialization
	public static int vidaBoss;
	public float velocidade;
	public float limiteEsquerdo, limiteDireito, limiteCima, limiteBaixo;
	Vector2 novaPosicao;
	public GameObject bossAtaque, bossAtaque2, bossAtaque3;

	private float tempo = 0;
	public float tempoTiro = 1.0f;

	// Use this for initialization
	void Start () {
		vidaBoss = 20;

		MudarPosicao();
	}

	void MudarPosicao()
	{
		novaPosicao = new Vector2(Random.Range(limiteEsquerdo, limiteDireito), Random.Range(limiteBaixo, limiteCima));
	}

	void Update () {
		tempo += Time.deltaTime;
		MoveBoss ();
	}

	void MoveBoss()
	{
		if (Vector2.Distance (transform.position, novaPosicao) < 1) {
			AtacaBoss ();
		}
		transform.position=Vector2.Lerp(transform.position,novaPosicao,Time.deltaTime*velocidade);
	}

	void AtacaBoss ()
	{
		if (tempo >= tempoTiro) {
			Instantiate (bossAtaque, new Vector2 (transform.position.x, transform.position.y - 0.5f), transform.rotation);
			Instantiate (bossAtaque2, new Vector2 (transform.position.x - 0.5f, transform.position.y - 0.5f), transform.rotation * Quaternion.Euler(0, 0, -45));
			Instantiate (bossAtaque3, new Vector2 (transform.position.x + 0.5f, transform.position.y - 0.5f), transform.rotation * Quaternion.Euler(0, 0, 45));
			tempo = 0;
		}
		MudarPosicao ();
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerarInimigosScript : MonoBehaviour {

	public GameObject inimigo;
	public GameObject boss;
	public float limiteEsquerdo, limiteDireito;
	public float tempoInicial, tempoFinal;
	public float numeroInimigos;
	bool bossVivo;

	IEnumerator Start () {
		float i = 0;
		float round = 1;
		bossVivo = false;
		do {
			// Aguarda para criação de um inimigo
			yield return new WaitForSeconds (Random.Range (tempoInicial / (1 + i * 0.1f), tempoFinal / (1 + i * 0.1f)));

			// Sorteia posição em X para instanciar o inimigo
			if (!bossVivo){
				// Instancia o inimigo
				for (int j=0; j < round; j++){
					Vector2 posicao = new Vector2 (Random.Range (limiteEsquerdo, limiteDireito), transform.position.y);	
					Instantiate (inimigo, posicao, transform.rotation);
				}
				i++;

				if (i != 1 && i % numeroInimigos == 0) {
					yield return new WaitForSeconds (3);
					for (int j=0; j < round; j++){
						Vector2 posicao = new Vector2 (Random.Range (limiteEsquerdo, limiteDireito), transform.position.y);	
						Instantiate (boss, posicao, transform.rotation);
					}
				}

				if (i == numeroInimigos*2)
				{
					i=0;
					round++;
				}
			}

		} while (true);
	}

	void Update () {
		GameObject spawnBoss = GameObject.FindGameObjectWithTag ("Boss");

		if (spawnBoss == null) {
			bossVivo = false;
		} else {
			bossVivo = true;
		}

	}
}

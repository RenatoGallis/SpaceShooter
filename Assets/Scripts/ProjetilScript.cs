using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjetilScript : MonoBehaviour {

	public float velocidade;
	public float tempoDeVida;
	public GameObject explosaoPrefab;

	void Start () {
		// Configura tempo de vida do projetil
		Destroy(gameObject, tempoDeVida);
	}

	void Update () {
		// Move o projetil
		transform.Translate(Vector2.up * velocidade * Time.deltaTime);
	}

	void OnCollisionEnter2D(Collision2D c) {
		// Destroi o projetil por colisao
		if (c.gameObject.tag == "Inimigo") {
			Instantiate (explosaoPrefab, transform.position, transform.rotation);
			Destroy (c.gameObject);
			Destroy (gameObject);
			PrincipalScript.pontos++;
		}
	}
}

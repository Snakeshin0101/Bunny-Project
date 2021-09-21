using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour {

	bool isCollected = false;

	void ShowCarrot () {

		this.GetComponent<SpriteRenderer> ().enabled = true;
		this.GetComponent<PolygonCollider2D> ().enabled = true;
		isCollected = false;	

	}

	void HideCarrot () {

		this.GetComponent<SpriteRenderer> ().enabled = false;
		this.GetComponent<PolygonCollider2D> ().enabled = false;

	}

	void CollectCarrot () {

		isCollected = true;
		HideCarrot ();

		// Notificar al manager que agarramos una zanahoria para poder sumar los puntos
		GameManager.sharedInstance.CollectCarrot ();
		

	}

	void OnTriggerEnter2D(Collider2D otherCollider) {
		
		if (otherCollider.tag == "Player") 

		{
			CollectCarrot ();
		}

	}

}

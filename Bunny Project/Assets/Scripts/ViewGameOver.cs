using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewGameOver : MonoBehaviour {

	public static ViewGameOver sharedInstance;

	public Text  carrotLabel;
	public Text scoreLabel;

	private void Awake() {
		sharedInstance = this;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}		

	public void UpdateUI () {

			if (GameManager.sharedInstance.currentGameState == GameState.gameOver)
			{
				carrotLabel.text = GameManager.sharedInstance.collectedCarrots.ToString ();
				scoreLabel.text = PlayerController.shareInstance.GetDistance ().ToString ("f0");
			}

	}
}

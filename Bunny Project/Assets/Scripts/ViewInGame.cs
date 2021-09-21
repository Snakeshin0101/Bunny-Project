using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewInGame : MonoBehaviour {

	public static ViewInGame sharedInstance;

	public Text  carrotLabel;
	public Text scoreLabel;
	public Text highScoreLabel;

	private void Awake() {
		
		sharedInstance = this;

	}
	
	// Update is called once per frame
	void Update () {
		
		if (GameManager
		.sharedInstance.currentGameState == GameState.inTheGame)
		{			
			scoreLabel.text = PlayerController.shareInstance.GetDistance ().ToString ("f0");			
		}

	}

	public void UpdateHighScoreLabel () {

		if (GameManager.sharedInstance.currentGameState == GameState.inTheGame)
		{
			highScoreLabel.text = PlayerPrefs.GetFloat ("highScore", 0).ToString("f0");
		}

	}

	public void UpdateCarrotsLabel () {

		if (GameManager.sharedInstance.currentGameState == GameState.inTheGame)
		{
			carrotLabel.text = GameManager.sharedInstance.collectedCarrots.ToString ();
		}

	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState {

	menu,
	inTheGame,
	gameOver
}

public class GameManager : MonoBehaviour {

	public static GameManager sharedInstance;

	public GameState currentGameState = GameState.menu;

	public Canvas menuCanvas;
	public Canvas gameCanvas;
	public Canvas gameOverCanvas;

	public int collectedCarrots = 0;
	


	private void Awake() {
		
		sharedInstance = this;

	}

	void Start() {
		
		currentGameState = GameState.menu;
		menuCanvas.enabled = true;
		gameCanvas.enabled = false;	
		gameOverCanvas.enabled = false;

	}

	private void Update() {
		/*
		if (Input.GetButtonDown ("Submit"))
		{
			if (currentGameState != GameState.inTheGame)
			{
				StartGame ();
			}
		}
		*/
	}

	// Usar esto para iniciar el juego
	public void StartGame () {

		PlayerController.shareInstance.StartGame ();
		LevelGenerator.sharedInstance.GenerateInitialBlocks ();
		ChangeGameState (GameState.inTheGame);
		ViewInGame.sharedInstance.UpdateHighScoreLabel ();
			
		
	}
	
	// Cuando el jugador muere
	public void GameOver () {

		LevelGenerator.sharedInstance.RemoveAllTheBlocks ();
		ChangeGameState (GameState.gameOver);
		ViewGameOver.sharedInstance.UpdateUI ();

	}

	// Para que te reinicie la partida o volver al menu
	public void BackToMainMenu () {

		ChangeGameState (GameState.menu);

	}

	void ChangeGameState (GameState newGameState) {

		if (newGameState == GameState.menu)	{
			// La escena de unity debe mostrar el menu principal del juego
			menuCanvas.enabled = true;
			//Debug.Log(gameCanvas.enabled);
			gameCanvas.enabled = false;
			gameOverCanvas.enabled = false;
			
		} else if (newGameState == GameState.inTheGame) {
			// La escena de unity debe mostrar el gameplay
			menuCanvas.enabled = false;
			//Debug.Log(gameCanvas.enabled);
			gameCanvas.enabled = true;
			gameOverCanvas.enabled = false;
			

		}else if (newGameState == GameState.gameOver) {
			// La escena de unity debe mostrar el gameover o fin de partida
			menuCanvas.enabled = false;
			//Debug.Log(gameCanvas.enabled);
			gameCanvas.enabled = false;
			gameOverCanvas.enabled = true;
			
		}

		currentGameState = newGameState;

	}

	public void CollectCarrot () {

		collectedCarrots ++;
		ViewInGame.sharedInstance.UpdateCarrotsLabel ();

		//Debug.Log("Zanahorias adequiridas: " + collectedCarrots);

	}
	
}

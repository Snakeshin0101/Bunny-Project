using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

	/*
		Variables publicas de nuestro generador de niveles
	*/

	// Instancia compartida para solo tener un generador de niveles
	public static LevelGenerator sharedInstance;

	// Lista que contiene todos los niveles que se han creado
	public List <LevelBlock> allTheLevelBlocks = new List<LevelBlock> ();

	// Lista de los bloques que tenemos en pantalla
	public List <LevelBlock> currentLevelBlocks = new List<LevelBlock> ();

	// Donde se iniciara el primer nivel de todos o zona cero
	public Transform levelInitialPoint;

	private bool isGeneratingInitialBlocks = false;

	private void Awake() {
		
		sharedInstance = this;		

	}

	// Use this for initialization
	void Start () {
		
		GenerateInitialBlocks ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GenerateInitialBlocks () {

		isGeneratingInitialBlocks = true;

		for (int i = 0; i < 3; i++)
		{
			AddNewBlock ();
		}

		isGeneratingInitialBlocks = false;

	}

	public void AddNewBlock (){

		// selecciona un bloque aleatorio entre los que tenemos disponibles
		int randomIndex = Random.Range(0, allTheLevelBlocks.Count);

		if (isGeneratingInitialBlocks)
		{
			randomIndex = 0;
		}

		// Crea una copia de las que existen en allthelevelblocks
		LevelBlock block = (LevelBlock) Instantiate (allTheLevelBlocks [randomIndex]);
		block.transform.SetParent (this.transform, false);

		//Posicion del bloque
		Vector3 blockPosition = Vector3.zero;

		if (currentLevelBlocks.Count == 0) 
		{
			
			//Colocar el primer bloque en pantalla
			blockPosition = levelInitialPoint.position;

		} else
		{
			// Ya hay bloques en pantalla entonces lo asigno al ultimo disponible
			blockPosition = currentLevelBlocks	[currentLevelBlocks.Count-1].exitPoint.position;
		}

		block.transform.position = blockPosition;
		currentLevelBlocks.Add (block);

	}

	public void RemoveOldBlock () {

		LevelBlock block = currentLevelBlocks [0];
		currentLevelBlocks.Remove (block);
		Destroy (block.gameObject);

	}

	public void RemoveAllTheBlocks () {

		while (currentLevelBlocks.Count > 0)
		{
			RemoveOldBlock ();
		}

	}

}

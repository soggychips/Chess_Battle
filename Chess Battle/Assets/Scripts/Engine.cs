using UnityEngine;
using System.Collections;

public class Engine : MonoBehaviour {
	public GameObject gameState_prefab, turnState_prefab, board_prefab;

	private GameState gameState;
	private TurnState turnState;
	private Board board;

	void Awake(){
		InstantiateGameComponents();
		GatherGameComponentScripts();

	}

	void InstantiateGameComponents(){
		Instantiate(gameState_prefab,Vector3.zero,Quaternion.identity);
		Instantiate(turnState_prefab,Vector3.zero,Quaternion.identity);
		Instantiate(board_prefab,Vector3.zero,Quaternion.identity);
	}

	void GatherGameComponentScripts(){
		gameState = GameObject.FindWithTag("GameState").GetComponent<GameState>();
		turnState = GameObject.FindWithTag("TurnState").GetComponent<TurnState>();
		board 	  = GameObject.FindWithTag("Board").GetComponent<Board>();
	}

}

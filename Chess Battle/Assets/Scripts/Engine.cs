using UnityEngine;
using System.Collections;

public class Engine : MonoBehaviour {
	public GameObject gameState_prefab, turnState_prefab, board_prefab;

	private GameState gameState;
	private TurnState turnState;
	private Board board;

	void Awake(){
		InstantiateGameComponents();
	}

	void InstantiateGameComponents(){
		Instantiate(gameState_prefab,Vector3.zero,Quaternion.identity);
		Instantiate(turnState_prefab,Vector3.zero,Quaternion.identity);

		InstantiateAndGatherBoard();
		GatherStateScripts();
	}

	void InstantiateAndGatherBoard(){
		Instantiate(board_prefab,Vector3.zero,Quaternion.identity);
		board = GameObject.FindWithTag("Board").GetComponent<Board>();
	}

	void GatherStateScripts(){
		gameState = GameObject.FindWithTag("GameState").GetComponent<GameState>();
		turnState = GameObject.FindWithTag("TurnState").GetComponent<TurnState>();
	}

	void Start(){

	}

}

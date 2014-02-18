using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {

	public enum States: int{Begin, White, Black, GameOver};
	private int currentState;

	public int CurrentState{
		get{return currentState;}
		set{currentState = value;}
	}

	void Start(){
		currentState = (int)States.Begin;
	}

	//don't call NextPlayer from GameOver
	public void NextPlayer(){
		if(currentState == (int)States.White) currentState = (int)States.Black;
		else currentState = (int)States.White;
	}

	public void EndGame(){
		currentState = (int)States.GameOver;
	}
}

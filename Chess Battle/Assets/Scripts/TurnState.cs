using UnityEngine;
using System.Collections;

public class TurnState : MonoBehaviour {

	public enum States: int{Neutral, Selected, Confirm, End};
	private int currentState;
	
	public int CurrentState{
		get{return currentState;}
		set{currentState = value;}
	}
	
	void Start(){
		currentState = (int)States.Neutral;
	}
	
	public void SelectPiece(){
		currentState = (int)States.Selected;
	}

	public void Confirm(){
		currentState = (int)States.Confirm;
	}
	
	public void EndTurn(){
		currentState = (int)States.End;
	}
}

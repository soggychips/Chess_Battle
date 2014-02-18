using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Piece : MonoBehaviour {
	public Material[] materialTypes_white;
	public Material[] materialTypes_black;

	public enum Type : int{President,General,Officer,Recon,Sniper,Soldier};
	public enum State : int{Normal, Selected, Highlighted};
	public enum Team : int{White, Black};

	public int type, state, team, health;
	private Vector2 tileLocation, generalsExtraTileLocation;
	private bool typeChange;

	private Board board;

	private Vector3 charZStack = new Vector3(0,0,-.5f);


	void Awake(){
		board = GameObject.FindWithTag("Board").GetComponent<Board>();
		type = (int)Type.Soldier;
		team = (int)Team.White;
		state = (int)State.Normal;
		typeChange = true;
		generalsExtraTileLocation = new Vector2(-1,-1);
	}

	void Update(){
		if(typeChange){
			typeChange = false;
			SetMaterial();
		}
	}

	void SetMaterial(){
		if(team == (int)Team.White){
			renderer.material = materialTypes_white[type];
		}else{
			renderer.material = materialTypes_black[type];
		}
		if(board.Tiles[(int)tileLocation.x,(int)tileLocation.y].color == (int)Tile.Colors.grey) renderer.material.color = Tile.greyColor;
		if(type==(int)Type.General) renderer.material.color = Tile.whiteColor;
	}

	public void CreateGeneral(Vector2 tile, int whichTeam){
		SetType ((int)Type.General);
		SetTeam(whichTeam);
		SetLocations (tile,Vector2.right);

	}

	public void CreatePiece(Vector2 tile, int whichTeam, int whichType){
		SetLocation((int)tile.x,(int)tile.y);
		SetTeam(whichTeam);
		SetType(whichType);
	}

	public void SetLocation(int x, int y){
		tileLocation = new Vector2(x,y);
		transform.position = new Vector3(x*Tile.spacing,y*Tile.spacing,0) + charZStack;
	}

	//for use with The General
	public void SetLocations(Vector2 tile, Vector2 direction){
		tileLocation = tile;
		generalsExtraTileLocation = tile+direction;
		transform.position = new Vector3(tile.x*Tile.spacing,tile.y*Tile.spacing,0) + (.5f * new Vector3(direction.x*Tile.spacing,direction.y*Tile.spacing,0)) + charZStack;
	}

	public void SetTeam(int t){
		team = t;
	}

	public void SetType(int t){
		type = t;
		typeChange = true;
	}

	public List<Vector2> GetPossibleMoveLocations(Vector2 position){
		int[,] currentBoardLayout = board.BoardSpaces;
		List<Vector2> moves = new List<Vector2>();
		switch(type){
		case (int)Type.President:
			foreach(Vector2 space in GetPresidentMovementVectors()){
				if(currentBoardLayout[(int)space.x,(int)space.y] != team) moves.Add(space);
			}
			break;
		case (int)Type.General:
			break;
		case (int)Type.Officer:
			break;
		case (int)Type.Recon:
			break;
		case (int)Type.Sniper:
			break;
		case (int)Type.Soldier:
			foreach(Vector2 space in GetSoldierMovementVectors()){
				if(currentBoardLayout[(int)space.x,(int)space.y] != team) moves.Add(space);
			}
			break;
		}

		return moves;
	}

	public List<Vector2> GetPresidentMovementVectors(){ //1 unit in all 8 directions
		List<Vector2> moves = new List<Vector2>();
		moves.Add(Vector2.right);
		moves.Add(new Vector2(1,1));
		moves.Add(Vector2.up);
		moves.Add(new Vector2(-1,1));
		moves.Add(-Vector2.right);
		moves.Add(new Vector2(-1,-1));
		moves.Add(-Vector2.up);
		moves.Add(new Vector2(1,-1));
		return moves;
	}

	public List<Vector2> GetSoldierMovementVectors(){ //one unit in all directions except left and right
		List<Vector2> moves = new List<Vector2>();
		moves.Add(new Vector2(1,1));
		moves.Add(Vector2.up);
		moves.Add(new Vector2(-1,1));
		moves.Add(new Vector2(-1,-1));
		moves.Add(-Vector2.up);
		moves.Add(new Vector2(1,-1));
		return moves;
	}

}

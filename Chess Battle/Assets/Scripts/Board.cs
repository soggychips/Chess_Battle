using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Board : MonoBehaviour {
	public enum Spaces{White,Black,Open};

	public GameObject tile_prefab, piece_prefab;
	private List<Piece> whiteTeam, blackTeam;
	private int[,] boardSpaces;
	private Tile[,] tiles;

	public int[,] BoardSpaces{
		get{return boardSpaces;}
	}

	public Tile[,] Tiles{
		get{return tiles;}
	}

	public List<Piece> WhiteTeam{
		get{return whiteTeam;}
	}

	public List<Piece> BlackTeam{
		get{return blackTeam;}
	}

	void Start(){
		SetupBoard();
		CreatePieces();
	}

	void SetupBoard(){
		tiles = new Tile[8,8];
		boardSpaces = new int[8,8];
		for(int i=0;i<8;i++){
			for(int j=0;j<8;j++){
				//instantiate
				Vector3 location = new Vector3(i,j,0)*Tile.spacing;
				GameObject tile = Instantiate(tile_prefab,location,Quaternion.AngleAxis(-90.0f,Vector3.right)) as GameObject;
				tile.transform.parent= this.transform;
				tiles[i,j] = tile.GetComponent<Tile>();
				boardSpaces[i,j] = (int)Spaces.Open;
			}
		}
	}

	void CreatePieces(){
		whiteTeam = new List<Piece>();
		blackTeam = new List<Piece>();
	//white team
		//left to right, bottom to top
		CreatePiece(Vector2.zero,(int)Piece.Team.White,(int)Piece.Type.Officer);
		CreatePiece(new Vector2(1,0),(int)Piece.Team.White,(int)Piece.Type.Recon);
		CreatePiece(new Vector2(2,0),(int)Piece.Team.White,(int)Piece.Type.Sniper);
		CreatePiece(new Vector2(3,0),(int)Piece.Team.White,(int)Piece.Type.President);
		CreatePiece(new Vector2(3,1),(int)Piece.Team.White,(int)Piece.Type.General);
		CreatePiece(new Vector2(5,0),(int)Piece.Team.White,(int)Piece.Type.Sniper);
		CreatePiece(new Vector2(6,0),(int)Piece.Team.White,(int)Piece.Type.Recon);
		CreatePiece(new Vector2(7,0),(int)Piece.Team.White,(int)Piece.Type.Officer);
		//pawns
		CreatePiece(new Vector2(0,1),(int)Piece.Team.White,(int)Piece.Type.Soldier);
		CreatePiece(new Vector2(1,2),(int)Piece.Team.White,(int)Piece.Type.Soldier);
		CreatePiece(new Vector2(2,2),(int)Piece.Team.White,(int)Piece.Type.Soldier);
		CreatePiece(new Vector2(3,3),(int)Piece.Team.White,(int)Piece.Type.Soldier);
		CreatePiece(new Vector2(4,3),(int)Piece.Team.White,(int)Piece.Type.Soldier);
		CreatePiece(new Vector2(5,2),(int)Piece.Team.White,(int)Piece.Type.Soldier);
		CreatePiece(new Vector2(6,2),(int)Piece.Team.White,(int)Piece.Type.Soldier);
		CreatePiece(new Vector2(7,1),(int)Piece.Team.White,(int)Piece.Type.Soldier);

	//black team
		//left to right, top to bottom
		CreatePiece(new Vector2(0,7),(int)Piece.Team.Black,(int)Piece.Type.Officer);
		CreatePiece(new Vector2(1,7),(int)Piece.Team.Black,(int)Piece.Type.Recon);
		CreatePiece(new Vector2(2,7),(int)Piece.Team.Black,(int)Piece.Type.Sniper);
		CreatePiece(new Vector2(3,7),(int)Piece.Team.Black,(int)Piece.Type.President);
		CreatePiece(new Vector2(3,6),(int)Piece.Team.Black,(int)Piece.Type.General);
		CreatePiece(new Vector2(5,7),(int)Piece.Team.Black,(int)Piece.Type.Sniper);
		CreatePiece(new Vector2(6,7),(int)Piece.Team.Black,(int)Piece.Type.Recon);
		CreatePiece(new Vector2(7,7),(int)Piece.Team.Black,(int)Piece.Type.Officer);
		//pawns
		CreatePiece(new Vector2(0,6),(int)Piece.Team.Black,(int)Piece.Type.Soldier);
		CreatePiece(new Vector2(1,5),(int)Piece.Team.Black,(int)Piece.Type.Soldier);
		CreatePiece(new Vector2(2,5),(int)Piece.Team.Black,(int)Piece.Type.Soldier);
		CreatePiece(new Vector2(3,4),(int)Piece.Team.Black,(int)Piece.Type.Soldier);
		CreatePiece(new Vector2(4,4),(int)Piece.Team.Black,(int)Piece.Type.Soldier);
		CreatePiece(new Vector2(5,5),(int)Piece.Team.Black,(int)Piece.Type.Soldier);
		CreatePiece(new Vector2(6,5),(int)Piece.Team.Black,(int)Piece.Type.Soldier);
		CreatePiece(new Vector2(7,6),(int)Piece.Team.Black,(int)Piece.Type.Soldier);


	}

	void CreatePiece(Vector2 tileLocation, int team, int type){
		if(team == (int)Piece.Team.White)
			boardSpaces[(int)tileLocation.x,(int)tileLocation.y] = (int)Spaces.White;
		else if(team == (int)Piece.Team.Black)
			boardSpaces[(int)tileLocation.x,(int)tileLocation.y] = (int)Spaces.Black;
		GameObject piece = Instantiate(piece_prefab,Vector3.zero,Quaternion.AngleAxis(-90.0f,Vector3.right)) as GameObject;
		piece.transform.RotateAround(transform.position,Vector3.forward,180.0f);
		piece.transform.parent = this.transform;
		Piece pieceScript = piece.GetComponent<Piece>();
		if(type==(int)Piece.Type.General)
			pieceScript.CreateGeneral(tileLocation,team);
		else
			pieceScript.CreatePiece(tileLocation,team,type);
		if(team==(int)Piece.Team.White)
			whiteTeam.Add(pieceScript);
		else
			blackTeam.Add (pieceScript);
	}
}

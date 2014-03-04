using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Board : MonoBehaviour {
	public GameObject tile_prefab, piece_prefab;
	private List<PieceScript> whiteTeam, blackTeam;

	private Tile[,] tiles;

	public Tile[,] Tiles{
		get{return tiles;}
	}

	public List<PieceScript> WhiteTeam{
		get{return whiteTeam;}
	}

	public List<PieceScript> BlackTeam{
		get{return blackTeam;}
	}

	void Start(){
		SetupBoard();
		CreatePieces();
	}

	void SetupBoard(){
		tiles = new Tile[8,8];
		for(int i=0;i<8;i++){
			for(int j=0;j<8;j++){
				//instantiate
				Vector3 location = new Vector3(i,j,0)*Tile.spacing;
				GameObject tile = Instantiate(tile_prefab,location,Quaternion.AngleAxis(-90.0f,Vector3.right)) as GameObject;
				tile.transform.parent= this.transform;
				tiles[i,j] = tile.GetComponent<Tile>();
			}
		}
	}

	void CreatePieces(){
		whiteTeam = new List<PieceScript>();
		blackTeam = new List<PieceScript>();
	//white team
		//left to right, bottom to top
		CreatePiece(Vector2.zero,(int)PieceScript.Team.White,(int)PieceScript.Type.Officer);
		CreatePiece(new Vector2(1,0),(int)PieceScript.Team.White,(int)PieceScript.Type.Recon);
		CreatePiece(new Vector2(2,0),(int)PieceScript.Team.White,(int)PieceScript.Type.Sniper);
		CreatePiece(new Vector2(3,0),(int)PieceScript.Team.White,(int)PieceScript.Type.President);
		CreatePiece(new Vector2(3,1),(int)PieceScript.Team.White,(int)PieceScript.Type.General);
		CreatePiece(new Vector2(5,0),(int)PieceScript.Team.White,(int)PieceScript.Type.Sniper);
		CreatePiece(new Vector2(6,0),(int)PieceScript.Team.White,(int)PieceScript.Type.Recon);
		CreatePiece(new Vector2(7,0),(int)PieceScript.Team.White,(int)PieceScript.Type.Officer);
		//pawns
		CreatePiece(new Vector2(0,1),(int)PieceScript.Team.White,(int)PieceScript.Type.Soldier);
		CreatePiece(new Vector2(1,2),(int)PieceScript.Team.White,(int)PieceScript.Type.Soldier);
		CreatePiece(new Vector2(2,2),(int)PieceScript.Team.White,(int)PieceScript.Type.Soldier);
		CreatePiece(new Vector2(3,3),(int)PieceScript.Team.White,(int)PieceScript.Type.Soldier);
		CreatePiece(new Vector2(4,3),(int)PieceScript.Team.White,(int)PieceScript.Type.Soldier);
		CreatePiece(new Vector2(5,2),(int)PieceScript.Team.White,(int)PieceScript.Type.Soldier);
		CreatePiece(new Vector2(6,2),(int)PieceScript.Team.White,(int)PieceScript.Type.Soldier);
		CreatePiece(new Vector2(7,1),(int)PieceScript.Team.White,(int)PieceScript.Type.Soldier);

	//black team
		//left to right, top to bottom
		CreatePiece(new Vector2(0,7),(int)PieceScript.Team.Black,(int)PieceScript.Type.Officer);
		CreatePiece(new Vector2(1,7),(int)PieceScript.Team.Black,(int)PieceScript.Type.Recon);
		CreatePiece(new Vector2(2,7),(int)PieceScript.Team.Black,(int)PieceScript.Type.Sniper);
		CreatePiece(new Vector2(3,7),(int)PieceScript.Team.Black,(int)PieceScript.Type.President);
		CreatePiece(new Vector2(3,6),(int)PieceScript.Team.Black,(int)PieceScript.Type.General);
		CreatePiece(new Vector2(5,7),(int)PieceScript.Team.Black,(int)PieceScript.Type.Sniper);
		CreatePiece(new Vector2(6,7),(int)PieceScript.Team.Black,(int)PieceScript.Type.Recon);
		CreatePiece(new Vector2(7,7),(int)PieceScript.Team.Black,(int)PieceScript.Type.Officer);
		//pawns
		CreatePiece(new Vector2(0,6),(int)PieceScript.Team.Black,(int)PieceScript.Type.Soldier);
		CreatePiece(new Vector2(1,5),(int)PieceScript.Team.Black,(int)PieceScript.Type.Soldier);
		CreatePiece(new Vector2(2,5),(int)PieceScript.Team.Black,(int)PieceScript.Type.Soldier);
		CreatePiece(new Vector2(3,4),(int)PieceScript.Team.Black,(int)PieceScript.Type.Soldier);
		CreatePiece(new Vector2(4,4),(int)PieceScript.Team.Black,(int)PieceScript.Type.Soldier);
		CreatePiece(new Vector2(5,5),(int)PieceScript.Team.Black,(int)PieceScript.Type.Soldier);
		CreatePiece(new Vector2(6,5),(int)PieceScript.Team.Black,(int)PieceScript.Type.Soldier);
		CreatePiece(new Vector2(7,6),(int)PieceScript.Team.Black,(int)PieceScript.Type.Soldier);


	}

	void CreatePiece(Vector2 tileLocation, int team, int type){

		GameObject piece = Instantiate(piece_prefab,Vector3.zero,Quaternion.AngleAxis(-90.0f,Vector3.right)) as GameObject;
		piece.transform.RotateAround(transform.position,Vector3.forward,180.0f);
		piece.transform.parent = this.transform;
		PieceScript pieceScript = piece.GetComponent<PieceScript>();
		if(type==(int)PieceScript.Type.General)
			pieceScript.CreateGeneral(tileLocation,team);
		else
			pieceScript.CreatePiece(tileLocation,team,type);
		if(team==(int)PieceScript.Team.White)
			whiteTeam.Add(pieceScript);
		else
			blackTeam.Add (pieceScript);
	}
}

using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {
	public enum Colors{white,grey};

	public Material grey, white;
	public int color;
	public static Color greyColor, whiteColor;
	public const int spacing = 10;
	public Vector2 tileLocation;

	void Awake(){
		greyColor = grey.color;
		whiteColor = white.color;
	}

	void Start(){
		tileLocation = new Vector2(transform.position.x/Tile.spacing,transform.position.y/Tile.spacing);
		if(tileLocation.y%2==0){ //even rows
			if(tileLocation.x%2==0){
				renderer.material = grey;
				color = (int)Colors.grey;
			}else{
				renderer.material = white;
				color = (int)Colors.white;
			}
		}else{
			if(tileLocation.x%2==0){
				renderer.material = white;
				color = (int)Colors.white;
			}else{
				renderer.material = grey;
				color = (int)Colors.grey;
			}
		}
	}

}

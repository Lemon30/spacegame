using UnityEngine;
using System.Collections;

public class ShipyardMenuScript : MonoBehaviour {

	public void closeMenu(){
		GameObject menu = GameObject.FindGameObjectWithTag ("ShipyardPanel");
		menu.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0, -1000);
	}
	
	public bool checkResources(int t, int m, int l){
		if (GameMaster.gameMaster.titaniumVal >= t &&
			GameMaster.gameMaster.mineralVal >= m &&
			GameMaster.gameMaster.luminiteVal >= l)
			return true;
		else
			return false;
	}

	public void build(string newName){
		Debug.Log ("Cannot build ships because a certain team member did not do his job!");
	}
}

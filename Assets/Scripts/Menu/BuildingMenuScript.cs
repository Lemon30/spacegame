using UnityEngine;
using System.Collections;

public class BuildingMenuScript : MonoBehaviour {

	public void closeMenu(){
		GameObject menu = GameObject.FindGameObjectWithTag ("BuildingPanel");
		menu.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0, -334);
	}

	public bool checkResources(int t, int m, int l){
		if (GameMaster.gameMaster.titaniumVal >= t &&
		    GameMaster.gameMaster.mineralVal >= m &&
		    GameMaster.gameMaster.luminiteVal >= l)
			return true;
		else
			return false;
	}

	public void build(string buildingName){
		int buildingTitaniumCost = 999999;
		int buildingMineralCost = 999999;
		int buildingLuminiteCost = 999999;
		switch (buildingName) {
		case "titaniumMine":
			buildingTitaniumCost = 10;
			buildingMineralCost = 5;
			buildingLuminiteCost = 0;
			break;
		case "mineralMine":
			buildingTitaniumCost = 20;
			buildingMineralCost = 10;
			buildingLuminiteCost = 0;
			break;
		case "luminiteMine":
			buildingTitaniumCost = 30;
			buildingMineralCost = 15;
			buildingLuminiteCost = 0;
			break;
		default:
			Debug.Log ("Invalid building selection. Boo!");
			break;
		}
		if (buildingTitaniumCost != null && buildingMineralCost != null && buildingLuminiteCost != null) {
			if (checkResources (buildingTitaniumCost, buildingMineralCost, buildingLuminiteCost)) {
				Debug.Log ("Building! T: "+buildingTitaniumCost+" M: "+buildingMineralCost+" L: "+buildingLuminiteCost);
				GameMaster.gameMaster.titaniumVal -= buildingTitaniumCost;
				GameMaster.gameMaster.mineralVal -= buildingMineralCost;
				GameMaster.gameMaster.luminiteVal -= buildingLuminiteCost;
				closeMenu ();
			}
		} else {
			//Check again
		}
	}
}
